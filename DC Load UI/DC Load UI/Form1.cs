using System;
using System.Text.RegularExpressions;

using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Diagnostics;
using System.Timers;
using System.IO.Ports;

namespace DC_Load_UI
{

    public partial class Form1 : Form
    {
        String txtIDNQuery =  "*IDN?";
        String txtDACWrite =  "DEVE:DAC1";
        String txtADC1Query = "DEVE:ADC1";
        String txtADC2Query = "DEVE:ADC2";
        String txtADC3Query = "DEVE:ADC3";
        String txtADC4Query = "DEVE:ADC4";
        String txtADCVolts =  ":VOLTage";
        String txtADCRAW =    ":RAW";
        String txtQuery =     "?";
        String txtErr =       "SYST:ERR";

        private System.Timers.Timer aTimer;
        private bool check_Errors = false;

        List<String> tList = new List<String>();

        public Form1()
        {
            InitializeComponent();
            Serial.myComPorts.PropertyChanged += new  PropertyChangedEventHandler(comPorts_ListChanged);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPortList();
            //do this here so it does not trigger before the drop down is ready
            // Create a timer with a ten second interval.
            aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }

        private void RefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshPortList();
        }
        private void RefreshPortList()
        {
            check_Errors = false; // stop probing for errors
            adcAuto.Checked = false; // Stop auto update of ADCs
            txtSelectedPort.Text = "";
            Serial.serialPort.Close(); // if it is open then close it
            if (Serial.myComPorts.SerialPorts.Count > 0)
            {
                comPorts.SelectedIndexChanged -= comPorts_SelectedIndexChanged;
                comPorts.DataSource = new BindingSource(Serial.myComPorts.SerialPorts, null);
                comPorts.DisplayMember = "Key";
                comPorts.ValueMember = "Value";
                comPorts.SelectedIndex = 0;
                comPorts.SelectedIndexChanged += new EventHandler(comPorts_SelectedIndexChanged);
                }
            else
            {
                
            }
        }
        private void readADC_Scheduled()
        {
            if (adcAuto.Checked)
            {
                this.Invoke((MethodInvoker)delegate {
                    readADCs();
                }); 
            }
        }
        private void readADC_Click(object sender, EventArgs e)
        {
            readADCs();
        }
        private void readADCs()
        {
            String txtFormat = (formatABS.Checked ? txtADCRAW : (formatVolts.Checked ? txtADCVolts : "") )+ txtQuery;
            txtADCResponse.Clear();
            txtADCResponse.AppendText(DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine); 
            string message;
            try
            {
                Serial.Open_SerialPort(); // keep the serial port open as were doing multiple operations
                Serial.WriteSerial(txtADC1Query + txtFormat) ;
                message = Serial.ReadSerial();
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC1Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC1Query + " = " + message + Environment.NewLine); }
                Serial.WriteSerial(txtADC2Query + txtFormat);
                message = Serial.ReadSerial();
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC2Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC2Query + " = " + message + Environment.NewLine); }
                Serial.WriteSerial(txtADC3Query + txtFormat);
                message = Serial.ReadSerial();
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC3Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC3Query + " = " + message + Environment.NewLine); }
                Serial.WriteSerial(txtADC4Query + txtFormat);
                message = Serial.ReadSerial();
                if (message == string.Empty) { txtADCResponse.AppendText(txtADC4Query + " Error" + Environment.NewLine); }
                else { txtADCResponse.AppendText(txtADC4Query + " = " + message + Environment.NewLine); }
                Check_Errors_Scheduled();
            }
            catch (Exception ex)
            {
                txtConsole.AppendText(DateTime.Now.ToString("HH:mm:ss") + " :- " + ex.Message + Environment.NewLine);
            }
            finally
            {
                Serial.Close_SerialPort();
            }
        }
        private void refreshID_Click(object sender, EventArgs e)
        {
            getIDN();
        }
        private void getIDN()
        {
            try
            {
                // Send an ID Query
                Serial.WriteSerial (txtIDNQuery);
                string message = Serial.ReadSerial();
                if (message != string.Empty)
                {
                    deviceID.Text = message;
                    check_Errors = true;
                }
                else
                {
                    check_Errors = false;
                    adcAuto.Checked = false;
                }
            }
            catch (Exception ex)
            {
                txtConsole.AppendText(DateTime.Now.ToString("HH:mm:ss") + " :- " + txtIDNQuery + " :- " + ex.Message + Environment.NewLine);
                check_Errors = false;
            }
        }

        private void setDAC_Click(object sender, EventArgs e)
        {
            int valDAC;
            bool isNumeric = int.TryParse(txtDACValue.Text, out valDAC);
            if (isNumeric)
            {
                try
                {
                    // Send an DAC Write
                    string sendmessage = txtDACWrite + " #H" + valDAC.ToString("X4"); ;
                    Serial.WriteSerial(sendmessage);
                }
                catch (Exception ex)
                {
                    txtConsole.AppendText(DateTime.Now.ToString("HH:mm:ss") + " :- " + ex.Message + Environment.NewLine);
                }
            }
            else {
                txtConsole.Clear();
                txtConsole.AppendText("please provide an int between 0 and 65535");
            }

        }


        private void Check_Errors_Scheduled()
        {
            if (check_Errors)
            {
               this.Invoke((MethodInvoker)delegate {
                   txtStatus.AppendText(Check_Errors());
               });
            }
        }
        private string Check_Errors()
        {
            string message = string.Empty;
                try
                {
                Serial.WriteSerial(txtErr + txtQuery );
                message = DateTime.Now.ToString("HH:mm:ss") + "   :-  " + Serial.ReadSerial()+ Environment.NewLine; // runs on UI thread
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate {
                    txtConsole.AppendText(DateTime.Now.ToString("HH:mm:ss") + " :- " + txtIDNQuery + " :- " + ex.Message + Environment.NewLine ); // runs on UI thread
                    });
                }
                return message;
        }
        // Specify what you want to happen when the Elapsed event is  
        // raised. 
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            readADC_Scheduled();
            Check_Errors_Scheduled();
        }

        public void comPorts_ListChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                RefreshPortList();
            });
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            txtStatus.SelectionStart = txtStatus.Text.Length;
            // scroll it automatically
            txtStatus.ScrollToCaret();
        }
        private void comPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serial.serialPort = (SerialPort)comPorts.SelectedValue;
            txtSelectedPort.Text = comPorts.Text;
            txtConsole.Clear();
            txtStatus.Clear();
            getIDN();
        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            txtConsole.SelectionStart = txtConsole.Text.Length;
            // scroll it automatically
            txtConsole.ScrollToCaret();
        }

        private void btmManual_Click(object sender, EventArgs e)
        {
           adcAuto.Checked = false; // Stop auto update of ADCs
            try
            {
                // Send an DAC Write
                string sendmessage = txtMessage.Text;
                Serial.WriteSerial(sendmessage);
                if (sendmessage.EndsWith("?"))
                {

                    string message = Serial.ReadSerial();
                    txtConsole.AppendText(DateTime.Now.ToString("HH:mm:ss") + " :- " + message + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                txtConsole.AppendText(DateTime.Now.ToString("HH:mm:ss") + " :- " + ex.Message + Environment.NewLine);
            }
}

        private void btnClearConsoole_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }
    }
}
