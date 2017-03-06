namespace DC_Load_UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dcLoadPort = new System.IO.Ports.SerialPort(this.components);
            this.RefreshPorts = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.comPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sdfsadf = new System.Windows.Forms.Label();
            this.deviceID = new System.Windows.Forms.TextBox();
            this.refreshID = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDACValue = new System.Windows.Forms.TextBox();
            this.setDAC = new System.Windows.Forms.Button();
            this.readADC = new System.Windows.Forms.Button();
            this.txtADCResponse = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.formatRaw = new System.Windows.Forms.RadioButton();
            this.formatVolts = new System.Windows.Forms.RadioButton();
            this.formatABS = new System.Windows.Forms.RadioButton();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btmManual = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adcAuto = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.asdasdasdfasdf = new System.Windows.Forms.Label();
            this.txtSelectedPort = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RefreshPorts
            // 
            this.RefreshPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshPorts.Location = new System.Drawing.Point(684, 12);
            this.RefreshPorts.Name = "RefreshPorts";
            this.RefreshPorts.Size = new System.Drawing.Size(106, 33);
            this.RefreshPorts.TabIndex = 1;
            this.RefreshPorts.Text = "Refresh";
            this.RefreshPorts.UseVisualStyleBackColor = true;
            this.RefreshPorts.Click += new System.EventHandler(this.RefreshPorts_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(72, 360);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(440, 124);
            this.txtConsole.TabIndex = 2;
            this.txtConsole.Text = "";
            this.txtConsole.TextChanged += new System.EventHandler(this.txtConsole_TextChanged);
            // 
            // comPorts
            // 
            this.comPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comPorts.FormattingEnabled = true;
            this.comPorts.Location = new System.Drawing.Point(80, 12);
            this.comPorts.Name = "comPorts";
            this.comPorts.Size = new System.Drawing.Size(598, 33);
            this.comPorts.TabIndex = 3;
            this.comPorts.SelectedIndexChanged += new System.EventHandler(this.comPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ports";
            // 
            // sdfsadf
            // 
            this.sdfsadf.AutoSize = true;
            this.sdfsadf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdfsadf.Location = new System.Drawing.Point(12, 59);
            this.sdfsadf.Name = "sdfsadf";
            this.sdfsadf.Size = new System.Drawing.Size(47, 25);
            this.sdfsadf.TabIndex = 6;
            this.sdfsadf.Text = "IDN";
            // 
            // deviceID
            // 
            this.deviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceID.Location = new System.Drawing.Point(80, 59);
            this.deviceID.Name = "deviceID";
            this.deviceID.Size = new System.Drawing.Size(598, 31);
            this.deviceID.TabIndex = 7;
            // 
            // refreshID
            // 
            this.refreshID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshID.Location = new System.Drawing.Point(684, 59);
            this.refreshID.Name = "refreshID";
            this.refreshID.Size = new System.Drawing.Size(106, 33);
            this.refreshID.TabIndex = 8;
            this.refreshID.Text = "Refresh";
            this.refreshID.UseVisualStyleBackColor = true;
            this.refreshID.Click += new System.EventHandler(this.refreshID_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "ADCs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "DAC1";
            // 
            // txtDACValue
            // 
            this.txtDACValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDACValue.Location = new System.Drawing.Point(72, 120);
            this.txtDACValue.Name = "txtDACValue";
            this.txtDACValue.Size = new System.Drawing.Size(224, 31);
            this.txtDACValue.TabIndex = 11;
            // 
            // setDAC
            // 
            this.setDAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDAC.Location = new System.Drawing.Point(302, 118);
            this.setDAC.Name = "setDAC";
            this.setDAC.Size = new System.Drawing.Size(106, 33);
            this.setDAC.TabIndex = 12;
            this.setDAC.Text = "SET";
            this.setDAC.UseVisualStyleBackColor = true;
            this.setDAC.Click += new System.EventHandler(this.setDAC_Click);
            // 
            // readADC
            // 
            this.readADC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readADC.Location = new System.Drawing.Point(518, 168);
            this.readADC.Name = "readADC";
            this.readADC.Size = new System.Drawing.Size(106, 33);
            this.readADC.TabIndex = 13;
            this.readADC.Text = "Refresh";
            this.readADC.UseVisualStyleBackColor = true;
            this.readADC.Click += new System.EventHandler(this.readADC_Click);
            // 
            // txtADCResponse
            // 
            this.txtADCResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtADCResponse.Location = new System.Drawing.Point(72, 168);
            this.txtADCResponse.Name = "txtADCResponse";
            this.txtADCResponse.Size = new System.Drawing.Size(440, 156);
            this.txtADCResponse.TabIndex = 14;
            this.txtADCResponse.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Console Messages";
            // 
            // formatRaw
            // 
            this.formatRaw.AutoSize = true;
            this.formatRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatRaw.Location = new System.Drawing.Point(518, 208);
            this.formatRaw.Name = "formatRaw";
            this.formatRaw.Size = new System.Drawing.Size(79, 29);
            this.formatRaw.TabIndex = 16;
            this.formatRaw.Text = "RAW";
            this.formatRaw.UseVisualStyleBackColor = true;
            // 
            // formatVolts
            // 
            this.formatVolts.AutoSize = true;
            this.formatVolts.Checked = true;
            this.formatVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatVolts.Location = new System.Drawing.Point(518, 258);
            this.formatVolts.Name = "formatVolts";
            this.formatVolts.Size = new System.Drawing.Size(85, 29);
            this.formatVolts.TabIndex = 17;
            this.formatVolts.TabStop = true;
            this.formatVolts.Text = "VOLT";
            this.formatVolts.UseVisualStyleBackColor = true;
            // 
            // formatABS
            // 
            this.formatABS.AutoSize = true;
            this.formatABS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatABS.Location = new System.Drawing.Point(518, 232);
            this.formatABS.Name = "formatABS";
            this.formatABS.Size = new System.Drawing.Size(72, 29);
            this.formatABS.TabIndex = 18;
            this.formatABS.Text = "ABS";
            this.formatABS.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(72, 68);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(598, 31);
            this.txtMessage.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Cmd";
            // 
            // btmManual
            // 
            this.btmManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmManual.Location = new System.Drawing.Point(684, 165);
            this.btmManual.Name = "btmManual";
            this.btmManual.Size = new System.Drawing.Size(106, 33);
            this.btmManual.TabIndex = 21;
            this.btmManual.Text = "Send";
            this.btmManual.UseVisualStyleBackColor = true;
            this.btmManual.Click += new System.EventHandler(this.btmManual_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(519, 360);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(263, 124);
            this.txtStatus.TabIndex = 22;
            this.txtStatus.Text = "";
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(524, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Status";
            // 
            // adcAuto
            // 
            this.adcAuto.AutoSize = true;
            this.adcAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adcAuto.Location = new System.Drawing.Point(631, 168);
            this.adcAuto.Name = "adcAuto";
            this.adcAuto.Size = new System.Drawing.Size(75, 29);
            this.adcAuto.TabIndex = 24;
            this.adcAuto.Text = "Auto";
            this.adcAuto.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.Controls.Add(this.asdasdasdfasdf);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSelectedPort);
            this.panel1.Controls.Add(this.adcAuto);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.formatABS);
            this.panel1.Controls.Add(this.formatVolts);
            this.panel1.Controls.Add(this.formatRaw);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtADCResponse);
            this.panel1.Controls.Add(this.readADC);
            this.panel1.Controls.Add(this.setDAC);
            this.panel1.Controls.Add(this.txtDACValue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtConsole);
            this.panel1.Location = new System.Drawing.Point(8, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 493);
            this.panel1.TabIndex = 25;
            // 
            // asdasdasdfasdf
            // 
            this.asdasdasdfasdf.AutoSize = true;
            this.asdasdasdfasdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asdasdasdfasdf.Location = new System.Drawing.Point(4, 18);
            this.asdasdasdfasdf.Name = "asdasdasdfasdf";
            this.asdasdasdfasdf.Size = new System.Drawing.Size(51, 25);
            this.asdasdasdfasdf.TabIndex = 26;
            this.asdasdasdfasdf.Text = "Port";
            // 
            // txtSelectedPort
            // 
            this.txtSelectedPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedPort.Location = new System.Drawing.Point(72, 12);
            this.txtSelectedPort.Name = "txtSelectedPort";
            this.txtSelectedPort.Size = new System.Drawing.Size(598, 31);
            this.txtSelectedPort.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(812, 593);
            this.Controls.Add(this.btmManual);
            this.Controls.Add(this.refreshID);
            this.Controls.Add(this.deviceID);
            this.Controls.Add(this.sdfsadf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPorts);
            this.Controls.Add(this.RefreshPorts);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "Form1";
            this.Text = "DC Load UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort dcLoadPort;
        private System.Windows.Forms.Button RefreshPorts;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.ComboBox comPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sdfsadf;
        private System.Windows.Forms.TextBox deviceID;
        private System.Windows.Forms.Button refreshID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDACValue;
        private System.Windows.Forms.Button setDAC;
        private System.Windows.Forms.Button readADC;
        private System.Windows.Forms.RichTextBox txtADCResponse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton formatRaw;
        private System.Windows.Forms.RadioButton formatVolts;
        private System.Windows.Forms.RadioButton formatABS;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btmManual;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox adcAuto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label asdasdasdfasdf;
        private System.Windows.Forms.TextBox txtSelectedPort;
    }
}

