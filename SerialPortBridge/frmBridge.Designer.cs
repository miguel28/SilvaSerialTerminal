namespace SerialPortBridge
{
    partial class frmBridge
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
            this.chkNewLine = new System.Windows.Forms.CheckBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnSendFF = new System.Windows.Forms.Button();
            this.chkUse0xFF = new System.Windows.Forms.CheckBox();
            this.radHexData = new System.Windows.Forms.RadioButton();
            this.radText = new System.Windows.Forms.RadioButton();
            this.lblSend = new System.Windows.Forms.Label();
            this.btnClearReceived = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendCom = new System.Windows.Forms.TextBox();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.grpReceived = new System.Windows.Forms.GroupBox();
            this.cboxBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboxComPorts = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpComs = new System.Windows.Forms.GroupBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cboxBaudRate2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxComPorts2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.grpSend.SuspendLayout();
            this.grpReceived.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpComs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkNewLine
            // 
            this.chkNewLine.AutoSize = true;
            this.chkNewLine.Location = new System.Drawing.Point(164, 77);
            this.chkNewLine.Name = "chkNewLine";
            this.chkNewLine.Size = new System.Drawing.Size(118, 17);
            this.chkNewLine.TabIndex = 8;
            this.chkNewLine.Text = "Use \\r \\n New Line";
            this.chkNewLine.UseVisualStyleBackColor = true;
            // 
            // serialPort
            // 
            this.serialPort.ReadBufferSize = 512;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btnSendFF
            // 
            this.btnSendFF.Location = new System.Drawing.Point(401, 59);
            this.btnSendFF.Name = "btnSendFF";
            this.btnSendFF.Size = new System.Drawing.Size(75, 23);
            this.btnSendFF.TabIndex = 7;
            this.btnSendFF.Text = "button1";
            this.btnSendFF.UseVisualStyleBackColor = true;
            // 
            // chkUse0xFF
            // 
            this.chkUse0xFF.AutoSize = true;
            this.chkUse0xFF.Location = new System.Drawing.Point(164, 59);
            this.chkUse0xFF.Name = "chkUse0xFF";
            this.chkUse0xFF.Size = new System.Drawing.Size(145, 17);
            this.chkUse0xFF.TabIndex = 6;
            this.chkUse0xFF.Text = "Use 0xFF 0xFF New Line";
            this.chkUse0xFF.UseVisualStyleBackColor = true;
            // 
            // radHexData
            // 
            this.radHexData.AutoSize = true;
            this.radHexData.Location = new System.Drawing.Point(78, 58);
            this.radHexData.Name = "radHexData";
            this.radHexData.Size = new System.Drawing.Size(70, 17);
            this.radHexData.TabIndex = 5;
            this.radHexData.Text = "Hex Data";
            this.radHexData.UseVisualStyleBackColor = true;
            // 
            // radText
            // 
            this.radText.AutoSize = true;
            this.radText.Checked = true;
            this.radText.Location = new System.Drawing.Point(26, 58);
            this.radText.Name = "radText";
            this.radText.Size = new System.Drawing.Size(46, 17);
            this.radText.TabIndex = 4;
            this.radText.TabStop = true;
            this.radText.Text = "Text";
            this.radText.UseVisualStyleBackColor = true;
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(10, 20);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(82, 13);
            this.lblSend.TabIndex = 3;
            this.lblSend.Text = "Send Command";
            // 
            // btnClearReceived
            // 
            this.btnClearReceived.Location = new System.Drawing.Point(482, 16);
            this.btnClearReceived.Name = "btnClearReceived";
            this.btnClearReceived.Size = new System.Drawing.Size(94, 36);
            this.btnClearReceived.TabIndex = 2;
            this.btnClearReceived.Text = "Clear Received";
            this.btnClearReceived.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(401, 16);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(46, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtSendCom
            // 
            this.txtSendCom.Location = new System.Drawing.Point(98, 16);
            this.txtSendCom.Multiline = true;
            this.txtSendCom.Name = "txtSendCom";
            this.txtSendCom.Size = new System.Drawing.Size(297, 36);
            this.txtSendCom.TabIndex = 0;
            // 
            // grpSend
            // 
            this.grpSend.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grpSend.Controls.Add(this.chkNewLine);
            this.grpSend.Controls.Add(this.btnSendFF);
            this.grpSend.Controls.Add(this.chkUse0xFF);
            this.grpSend.Controls.Add(this.radHexData);
            this.grpSend.Controls.Add(this.radText);
            this.grpSend.Controls.Add(this.lblSend);
            this.grpSend.Controls.Add(this.btnClearReceived);
            this.grpSend.Controls.Add(this.btnSend);
            this.grpSend.Controls.Add(this.txtSendCom);
            this.grpSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSend.Location = new System.Drawing.Point(3, 329);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(924, 94);
            this.grpSend.TabIndex = 2;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "Command";
            // 
            // txtReceived
            // 
            this.txtReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceived.Location = new System.Drawing.Point(3, 16);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceived.Size = new System.Drawing.Size(918, 188);
            this.txtReceived.TabIndex = 0;
            // 
            // grpReceived
            // 
            this.grpReceived.Controls.Add(this.txtReceived);
            this.grpReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceived.Location = new System.Drawing.Point(3, 116);
            this.grpReceived.Name = "grpReceived";
            this.grpReceived.Size = new System.Drawing.Size(924, 207);
            this.grpReceived.TabIndex = 1;
            this.grpReceived.TabStop = false;
            this.grpReceived.Text = "ReceivedText";
            // 
            // cboxBaudRate
            // 
            this.cboxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaudRate.FormattingEnabled = true;
            this.cboxBaudRate.Items.AddRange(new object[] {
            "9600",
            "4800",
            "2400",
            "19200",
            "115200"});
            this.cboxBaudRate.Location = new System.Drawing.Point(421, 18);
            this.cboxBaudRate.Name = "cboxBaudRate";
            this.cboxBaudRate.Size = new System.Drawing.Size(78, 21);
            this.cboxBaudRate.TabIndex = 6;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.BackColor = System.Drawing.Color.Transparent;
            this.lblBaudRate.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBaudRate.Location = new System.Drawing.Point(357, 20);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(67, 13);
            this.lblBaudRate.TabIndex = 5;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // btnConnect
            // 
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnect.Location = new System.Drawing.Point(212, 72);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(97, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect!";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefresh.Location = new System.Drawing.Point(124, 72);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboxComPorts
            // 
            this.cboxComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxComPorts.FormattingEnabled = true;
            this.cboxComPorts.Location = new System.Drawing.Point(78, 18);
            this.cboxComPorts.Name = "cboxComPorts";
            this.cboxComPorts.Size = new System.Drawing.Size(273, 21);
            this.cboxComPorts.TabIndex = 1;
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.BackColor = System.Drawing.Color.Transparent;
            this.lblComPort.ForeColor = System.Drawing.SystemColors.Control;
            this.lblComPort.Location = new System.Drawing.Point(23, 21);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(58, 13);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "Com Port";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpComs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpReceived, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpSend, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 426);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // grpComs
            // 
            this.grpComs.BackColor = System.Drawing.SystemColors.Highlight;
            this.grpComs.Controls.Add(this.cboxBaudRate2);
            this.grpComs.Controls.Add(this.label1);
            this.grpComs.Controls.Add(this.cboxComPorts2);
            this.grpComs.Controls.Add(this.label2);
            this.grpComs.Controls.Add(this.cboxBaudRate);
            this.grpComs.Controls.Add(this.lblBaudRate);
            this.grpComs.Controls.Add(this.btnConnect);
            this.grpComs.Controls.Add(this.btnRefresh);
            this.grpComs.Controls.Add(this.cboxComPorts);
            this.grpComs.Controls.Add(this.lblComPort);
            this.grpComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComs.ForeColor = System.Drawing.SystemColors.Control;
            this.grpComs.Location = new System.Drawing.Point(3, 3);
            this.grpComs.Name = "grpComs";
            this.grpComs.Size = new System.Drawing.Size(924, 107);
            this.grpComs.TabIndex = 0;
            this.grpComs.TabStop = false;
            this.grpComs.Text = "Serial Ports";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cboxBaudRate2
            // 
            this.cboxBaudRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaudRate2.FormattingEnabled = true;
            this.cboxBaudRate2.Items.AddRange(new object[] {
            "9600",
            "4800",
            "2400",
            "19200",
            "115200"});
            this.cboxBaudRate2.Location = new System.Drawing.Point(421, 45);
            this.cboxBaudRate2.Name = "cboxBaudRate2";
            this.cboxBaudRate2.Size = new System.Drawing.Size(78, 21);
            this.cboxBaudRate2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(357, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Baud Rate";
            // 
            // cboxComPorts2
            // 
            this.cboxComPorts2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxComPorts2.FormattingEnabled = true;
            this.cboxComPorts2.Location = new System.Drawing.Point(78, 45);
            this.cboxComPorts2.Name = "cboxComPorts2";
            this.cboxComPorts2.Size = new System.Drawing.Size(273, 21);
            this.cboxComPorts2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Com Port";
            // 
            // serialPort2
            // 
            this.serialPort2.ReadBufferSize = 512;
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // frmBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmBridge";
            this.Text = "frmBridge";
            this.grpSend.ResumeLayout(false);
            this.grpSend.PerformLayout();
            this.grpReceived.ResumeLayout(false);
            this.grpReceived.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpComs.ResumeLayout(false);
            this.grpComs.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkNewLine;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnSendFF;
        private System.Windows.Forms.CheckBox chkUse0xFF;
        private System.Windows.Forms.RadioButton radHexData;
        private System.Windows.Forms.RadioButton radText;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button btnClearReceived;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendCom;
        private System.Windows.Forms.GroupBox grpSend;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.GroupBox grpReceived;
        private System.Windows.Forms.ComboBox cboxBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboxComPorts;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpComs;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox cboxBaudRate2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxComPorts2;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort2;
    }
}