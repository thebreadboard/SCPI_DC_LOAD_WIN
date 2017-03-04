using System;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Diagnostics;


namespace DC_Load_UI
{

    public partial class Form1 : Form
    {
        String txtIDNQuery = "*IDN?";
        String txtDACWrite = "DEVE:DAC1";
        String txtADC1Query = "DEVE:ADC1?";
        String txtADC2Query = "DEVE:ADC2?";
        String txtADC3Query = "DEVE:ADC3?";
        String txtADC4Query = "DEVE:ADC4?";
        DeviceManager myComPorts = new DeviceManager();
        
        public Form1()
        {
            InitializeComponent();
            myComPorts.PropertyChanged += new  PropertyChangedEventHandler(comPorts_ListChanged);

        }
        List<String> tList = new List<String>();

        private void RefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshPortList();
        }
        private void RefreshPortList()
        {
            comPorts.SelectedIndexChanged -= comPorts_SelectedIndexChanged;
            comPorts.DataSource = new BindingSource(myComPorts.SerialPorts, null);
            comPorts.DisplayMember = "Key";
            comPorts.ValueMember = "Value";
            comPorts.Invoke(comPorts => comPorts.Refresh());
            comPorts.SelectedIndexChanged += new EventHandler(comPorts_SelectedIndexChanged);

        }
        private void readADC_Click(object sender, EventArgs e)
        {
            SerialPort serialPort = (SerialPort)comPorts.SelectedValue;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

            txtADCResponse.Clear();
            try
            {
                serialPort.Open();
                // Send an ID Query
                serialPort.WriteLine(txtADC1Query);
                string message = Read(serialPort);
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC1Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC1Query + " = " + message + Environment.NewLine); }
                serialPort.WriteLine(txtADC2Query);
                message = Read(serialPort);
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC2Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC2Query + " = " + message + Environment.NewLine); }
                serialPort.WriteLine(txtADC3Query);
                message = Read(serialPort);
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC3Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC3Query + " = " + message + Environment.NewLine); }
                serialPort.WriteLine(txtADC4Query);
                message = Read(serialPort);
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC4Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC4Query + " = " + message + Environment.NewLine); }

            }
            catch (Exception ex)
            {
                txtConsole.Clear();
                txtConsole.AppendText(ex.Message);
            }
            finally
            {
                serialPort.Close();
            }

        }

    private void refreshID_Click(object sender, EventArgs e)
        {
            refreshIDs();
        }
        private void refreshIDs()
        {
            txtConsole.Clear();
            SerialPort serialPort = (SerialPort)comPorts.SelectedValue;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
            try
            {
                serialPort.Open();
                // Send an ID Query
                serialPort.WriteLine(txtIDNQuery);
                string message = Read(serialPort);
                deviceID.Text = message;
            }
            catch (Exception ex)
            {
                txtConsole.Clear();
                txtConsole.AppendText(txtIDNQuery + " :- " + ex.Message);
            }
            finally
            {
                serialPort.Close();
            }
        }


    public string Read(SerialPort serial)
    {
       string message = string.Empty;

            try
            {
                message = serial.ReadLine();
                
            }
            catch (TimeoutException ex) {
                    txtConsole.Clear();
                    txtConsole.AppendText(ex.Message);
                }
            return message;
    }
    private void setDAC_Click(object sender, EventArgs e)
        {
            SerialPort serialPort = (SerialPort)comPorts.SelectedValue;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
            int valDAC;
            bool isNumeric = int.TryParse(txtDACValue.Text, out valDAC);
            txtConsole.Clear();
            if (isNumeric)
            {

                try
                {
                    serialPort.Open();
                    // Send an DAC Write
                    string sendmessage = txtDACWrite + " #H" + valDAC.ToString("X4"); ;
                    serialPort.WriteLine(sendmessage);
                    //string message = Read(serialPort);
                    //if (message == "Error") { txtConsole.AppendText(txtDACWrite + " Error" + Environment.NewLine); }
                    //else { txtConsole.AppendText(txtDACWrite + " = " + message + Environment.NewLine); }
                }
                catch (Exception ex)
                {
                    txtConsole.Clear();
                    txtConsole.AppendText(ex.Message);
                }
                finally
                {
                    serialPort.Close();
                }
            }
            else {
                txtConsole.Clear();
                txtConsole.AppendText("please provide an int between 0 and 65535");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPortList();
            //do this here so it does not trigger before the drop down is ready
            comPorts.SelectedIndexChanged += new EventHandler(comPorts_SelectedIndexChanged);
        }


        private void comPorts_ListChanged(object sender, EventArgs e)
        {
            RefreshPortList();
        }

        private void comPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshIDs();
        }
    }
    /// <summary>
    ///     Provides automated detection and initiation of serial devices.
    /// </summary>
    public sealed class DeviceManager : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        ///     A System Watcher to hook events from the WMI tree.
        /// </summary>
        private readonly ManagementEventWatcher _deviceWatcher = new ManagementEventWatcher(new WqlEventQuery(
            "SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3"));

        /// <summary>
        ///     A list of all dynamically found SerialPorts.
        /// </summary>
        private Dictionary<string, SerialPort> _serialPorts = new Dictionary<string, SerialPort>();

        /// <summary>
        ///     Initialises a new instance of the <see cref="DeviceManager"/> class.
        /// </summary>
        public DeviceManager()
        {
            // Attach an event listener to the device watcher.
            _deviceWatcher.EventArrived += _deviceWatcher_EventArrived;

            // Start monitoring the WMI tree for changes in SerialPort devices.
            _deviceWatcher.Start();

            // Initially populate the devices list.
            DiscoverDevices();
        }

        /// <summary>
        ///     Gets a list of all dynamically found SerialPorts.
        /// </summary>
        /// <value>A list of all dynamically found SerialPorts.</value>
        public Dictionary<string, SerialPort> SerialPorts
        {
            get { return _serialPorts; }
            private set
            {
                _serialPorts = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Stop the WMI monitors when this instance is disposed.
            _deviceWatcher.Stop();
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Handles the EventArrived event of the _deviceWatcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArrivedEventArgs"/> instance containing the event data.</param>
        private void _deviceWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            DiscoverDevices();
        }

        /// <summary>
        ///     Dynamically populates the SerialPorts property with relevant devices discovered from the WMI Win32_SerialPorts class.
        /// </summary>
        private void DiscoverDevices()
        {
            // Create a temporary dictionary to superimpose onto the SerialPorts property.
            var dict = new Dictionary<string, SerialPort>();

            try
            {
                // Scan through each SerialPort registered in the WMI.
                foreach (ManagementObject device in
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort").Get())
                {
                    // Create a SerialPort to add to the collection.
                    var port = new SerialPort();

                    // Gather related configuration details for the Arduino Device.
                    var config = device.GetRelated("Win32_SerialPortConfiguration")
                                       .Cast<ManagementObject>().ToList().FirstOrDefault();

                    // Set the SerialPort's PortName property.
                    port.PortName = device["DeviceID"].ToString();

                    // Set the SerialPort's BaudRate property. Use the devices maximum BaudRate as a fallback.
                    port.BaudRate = (config != null)
                                        ? int.Parse(config["BaudRate"].ToString())
                                        : int.Parse(device["MaxBaudRate"].ToString());

                    // Add the SerialPort to the dictionary.
                    dict.Add(device["Name"].ToString(), port);
                }

                // Return the dictionary.
                SerialPorts = dict;
            }
            catch (ManagementException mex)
            {
                // Send a message to debug.
                Debug.WriteLine(@"An error occurred while querying for WMI data: " + mex.Message);
            }
        }

        /// <summary>
        ///     Called when a property is set.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        //[NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public static class Extensions
    {
        public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del)
            where TControlType : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }
}
