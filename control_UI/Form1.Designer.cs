namespace Test
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOFF = new System.Windows.Forms.Button();
            this.btnCaculate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnON1 = new System.Windows.Forms.Button();
            this.btnOFF1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtCRCReceive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCRCSend = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(111, 30);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(121, 24);
            this.cboPort.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(694, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(102, 24);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(694, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 24);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(111, 130);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(483, 36);
            this.txtReceive.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Receive:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Baud rate:";
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.cboBaud.Location = new System.Drawing.Point(364, 27);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(121, 24);
            this.cboBaud.TabIndex = 1;
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(643, 169);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(75, 23);
            this.btnOn.TabIndex = 4;
            this.btnOn.Text = "ON";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOFF
            // 
            this.btnOFF.Location = new System.Drawing.Point(643, 214);
            this.btnOFF.Name = "btnOFF";
            this.btnOFF.Size = new System.Drawing.Size(75, 23);
            this.btnOFF.TabIndex = 4;
            this.btnOFF.Text = "OFF";
            this.btnOFF.UseVisualStyleBackColor = true;
            this.btnOFF.Click += new System.EventHandler(this.btnOFF_Click);
            // 
            // btnCaculate
            // 
            this.btnCaculate.Location = new System.Drawing.Point(238, 270);
            this.btnCaculate.Name = "btnCaculate";
            this.btnCaculate.Size = new System.Drawing.Size(191, 24);
            this.btnCaculate.TabIndex = 9;
            this.btnCaculate.Text = "Caculate CRC - Send";
            this.btnCaculate.UseVisualStyleBackColor = true;
            this.btnCaculate.Click += new System.EventHandler(this.btnCaculate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(659, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "D1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(786, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "D2";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnON1
            // 
            this.btnON1.Location = new System.Drawing.Point(772, 169);
            this.btnON1.Name = "btnON1";
            this.btnON1.Size = new System.Drawing.Size(75, 23);
            this.btnON1.TabIndex = 11;
            this.btnON1.Text = "ON";
            this.btnON1.UseVisualStyleBackColor = true;
            this.btnON1.Click += new System.EventHandler(this.btnON1_Click_1);
            // 
            // btnOFF1
            // 
            this.btnOFF1.Location = new System.Drawing.Point(772, 214);
            this.btnOFF1.Name = "btnOFF1";
            this.btnOFF1.Size = new System.Drawing.Size(75, 23);
            this.btnOFF1.TabIndex = 12;
            this.btnOFF1.Text = "OFF";
            this.btnOFF1.UseVisualStyleBackColor = true;
            this.btnOFF1.Click += new System.EventHandler(this.btnOFF1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Send:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(111, 86);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(483, 38);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // txtCRCReceive
            // 
            this.txtCRCReceive.Location = new System.Drawing.Point(111, 221);
            this.txtCRCReceive.Multiline = true;
            this.txtCRCReceive.Name = "txtCRCReceive";
            this.txtCRCReceive.Size = new System.Drawing.Size(483, 32);
            this.txtCRCReceive.TabIndex = 7;
            this.txtCRCReceive.TextChanged += new System.EventHandler(this.txtCRCReceive_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "CRC Receive:";
            // 
            // txtCRCSend
            // 
            this.txtCRCSend.Location = new System.Drawing.Point(111, 177);
            this.txtCRCSend.Multiline = true;
            this.txtCRCSend.Name = "txtCRCSend";
            this.txtCRCSend.Size = new System.Drawing.Size(483, 38);
            this.txtCRCSend.TabIndex = 8;
            this.txtCRCSend.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "CRC Send:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 315);
            this.Controls.Add(this.btnOFF1);
            this.Controls.Add(this.btnON1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCaculate);
            this.Controls.Add(this.txtCRCReceive);
            this.Controls.Add(this.txtCRCSend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOFF);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cboBaud);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label label3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnCaculate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnON1;
        private System.Windows.Forms.Button btnOFF1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtCRCReceive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCRCSend;
        private System.Windows.Forms.Label label6;
    }
}

