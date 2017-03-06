using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.ComponentModel;
using System.Management;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DC_Load_UI
{
    public static class Serial
    {
        public static SerialPort serialPort = new SerialPort();
        public static DeviceManager myComPorts = new DeviceManager();

        public static string ReadSerial()
        {
            bool closeSerial = false;
            if (null != serialPort && !serialPort.IsOpen)
            {
                Open_SerialPort();
                closeSerial = true;
            }
            string message = string.Empty;
            try
            {
                message = serialPort.ReadTo(Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message );
            }
            if (closeSerial)
            {
                Close_SerialPort();
            }
            return message;
        }
        public static string WriteSerial(string message)
        {
            bool closeSerial = false;
            if (null != serialPort && !serialPort.IsOpen)
            {
                Open_SerialPort();
                closeSerial = true;
            }
            try
            {
                serialPort.WriteLine(message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (closeSerial)
            {
                Close_SerialPort();
            }
            return message;
        }
        public static void Open_SerialPort()
        {
            if (null != serialPort && !serialPort.IsOpen)
            {
                serialPort.ReadTimeout = 500;
                serialPort.WriteTimeout = 500;
                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public static void Close_SerialPort()
        {
            if (null != serialPort && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
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
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
