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
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(463, 170);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(327, 232);
            this.txtConsole.TabIndex = 2;
            this.txtConsole.Text = "";
            // 
            // comPorts
            // 
            this.comPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comPorts.FormattingEnabled = true;
            this.comPorts.Location = new System.Drawing.Point(80, 12);
            this.comPorts.Name = "comPorts";
            this.comPorts.Size = new System.Drawing.Size(598, 33);
            this.comPorts.TabIndex = 3;
            
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
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "ADCs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "DAC1";
            // 
            // txtDACValue
            // 
            this.txtDACValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDACValue.Location = new System.Drawing.Point(80, 170);
            this.txtDACValue.Name = "txtDACValue";
            this.txtDACValue.Size = new System.Drawing.Size(224, 31);
            this.txtDACValue.TabIndex = 11;
            // 
            // setDAC
            // 
            this.setDAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDAC.Location = new System.Drawing.Point(310, 168);
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
            this.readADC.Location = new System.Drawing.Point(310, 218);
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
            this.txtADCResponse.Location = new System.Drawing.Point(80, 218);
            this.txtADCResponse.Name = "txtADCResponse";
            this.txtADCResponse.Size = new System.Drawing.Size(224, 156);
            this.txtADCResponse.TabIndex = 14;
            this.txtADCResponse.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Console Messages";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(802, 414);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtADCResponse);
            this.Controls.Add(this.readADC);
            this.Controls.Add(this.setDAC);
            this.Controls.Add(this.txtDACValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshID);
            this.Controls.Add(this.deviceID);
            this.Controls.Add(this.sdfsadf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPorts);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.RefreshPorts);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "Form1";
            this.Text = "DC Load UI";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

