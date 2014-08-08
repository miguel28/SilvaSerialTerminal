namespace SilvaSerialTerminal
{
    partial class frmMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpComs = new System.Windows.Forms.GroupBox();
            this.grpReceived = new System.Windows.Forms.GroupBox();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.lblComPort = new System.Windows.Forms.Label();
            this.cboxComPorts = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cboxBaudRate = new System.Windows.Forms.ComboBox();
            this.timerReader = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpComs.SuspendLayout();
            this.grpReceived.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 464);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpComs
            // 
            this.grpComs.Controls.Add(this.cboxBaudRate);
            this.grpComs.Controls.Add(this.lblBaudRate);
            this.grpComs.Controls.Add(this.btnConnect);
            this.grpComs.Controls.Add(this.btnRefresh);
            this.grpComs.Controls.Add(this.cboxComPorts);
            this.grpComs.Controls.Add(this.lblComPort);
            this.grpComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComs.Location = new System.Drawing.Point(3, 3);
            this.grpComs.Name = "grpComs";
            this.grpComs.Size = new System.Drawing.Size(601, 79);
            this.grpComs.TabIndex = 0;
            this.grpComs.TabStop = false;
            this.grpComs.Text = "Serial Ports";
            // 
            // grpReceived
            // 
            this.grpReceived.Controls.Add(this.txtReceived);
            this.grpReceived.Location = new System.Drawing.Point(3, 88);
            this.grpReceived.Name = "grpReceived";
            this.grpReceived.Size = new System.Drawing.Size(601, 221);
            this.grpReceived.TabIndex = 1;
            this.grpReceived.TabStop = false;
            this.grpReceived.Text = "ReceivedText";
            // 
            // grpSend
            // 
            this.grpSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSend.Location = new System.Drawing.Point(3, 315);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(601, 146);
            this.grpSend.TabIndex = 2;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "Send";
            // 
            // txtReceived
            // 
            this.txtReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceived.Location = new System.Drawing.Point(3, 16);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceived.Size = new System.Drawing.Size(595, 202);
            this.txtReceived.TabIndex = 0;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(24, 20);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(50, 13);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "Com Port";
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(135, 47);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(216, 47);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect!";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(357, 20);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 5;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // cboxBaudRate
            // 
            this.cboxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaudRate.FormattingEnabled = true;
            this.cboxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "115200"});
            this.cboxBaudRate.Location = new System.Drawing.Point(421, 18);
            this.cboxBaudRate.Name = "cboxBaudRate";
            this.cboxBaudRate.Size = new System.Drawing.Size(95, 21);
            this.cboxBaudRate.TabIndex = 6;
            // 
            // timerReader
            // 
            this.timerReader.Interval = 10;
            this.timerReader.Tick += new System.EventHandler(this.timerReader_Tick);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainForm";
            this.Text = "Silva Serial Terminal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpComs.ResumeLayout(false);
            this.grpComs.PerformLayout();
            this.grpReceived.ResumeLayout(false);
            this.grpReceived.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpComs;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboxComPorts;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.GroupBox grpReceived;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.GroupBox grpSend;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cboxBaudRate;
        private System.Windows.Forms.Timer timerReader;
    }
}

