namespace CLXTerminal
{
    partial class frmCLXTerminal
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
            this.grpComs = new System.Windows.Forms.GroupBox();
            this.btnConnectRemote = new System.Windows.Forms.Button();
            this.txtRemoteHost = new System.Windows.Forms.TextBox();
            this.grpReceived = new System.Windows.Forms.GroupBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.chkNewLine = new System.Windows.Forms.CheckBox();
            this.dgvResponses = new System.Windows.Forms.DataGridView();
            this.cExpected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResponseEn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cResponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radHexData = new System.Windows.Forms.RadioButton();
            this.radText = new System.Windows.Forms.RadioButton();
            this.lblSend = new System.Windows.Forms.Label();
            this.btnClearReceived = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendCom = new System.Windows.Forms.TextBox();
            this.grpAutoResponse = new System.Windows.Forms.GroupBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblAutoResponse = new System.Windows.Forms.Label();
            this.txtAutoResponse = new System.Windows.Forms.TextBox();
            this.chkEnableAutoResponse = new System.Windows.Forms.CheckBox();
            this.ethernetIPforCLXCom1 = new AdvancedHMIDrivers.EthernetIPforCLXCom(this.components);
            this.grpComs.SuspendLayout();
            this.grpReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.grpSend.SuspendLayout();
            this.grpAutoResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ethernetIPforCLXCom1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpComs
            // 
            this.grpComs.BackColor = System.Drawing.SystemColors.Desktop;
            this.grpComs.Controls.Add(this.btnConnectRemote);
            this.grpComs.Controls.Add(this.txtRemoteHost);
            this.grpComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComs.ForeColor = System.Drawing.SystemColors.Control;
            this.grpComs.Location = new System.Drawing.Point(3, 3);
            this.grpComs.Name = "grpComs";
            this.grpComs.Size = new System.Drawing.Size(629, 64);
            this.grpComs.TabIndex = 0;
            this.grpComs.TabStop = false;
            this.grpComs.Text = "Serial Ports";
            // 
            // btnConnectRemote
            // 
            this.btnConnectRemote.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnectRemote.Location = new System.Drawing.Point(175, 22);
            this.btnConnectRemote.Name = "btnConnectRemote";
            this.btnConnectRemote.Size = new System.Drawing.Size(97, 23);
            this.btnConnectRemote.TabIndex = 8;
            this.btnConnectRemote.Text = "Connect!";
            this.btnConnectRemote.UseVisualStyleBackColor = true;
            this.btnConnectRemote.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtRemoteHost
            // 
            this.txtRemoteHost.Location = new System.Drawing.Point(13, 22);
            this.txtRemoteHost.Name = "txtRemoteHost";
            this.txtRemoteHost.Size = new System.Drawing.Size(156, 20);
            this.txtRemoteHost.TabIndex = 7;
            this.txtRemoteHost.Text = "192.168.23.132";
            // 
            // grpReceived
            // 
            this.grpReceived.Controls.Add(this.txtReceived);
            this.grpReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceived.Location = new System.Drawing.Point(3, 73);
            this.grpReceived.Name = "grpReceived";
            this.grpReceived.Size = new System.Drawing.Size(629, 258);
            this.grpReceived.TabIndex = 1;
            this.grpReceived.TabStop = false;
            this.grpReceived.Text = "ReceivedText";
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
            this.txtReceived.Size = new System.Drawing.Size(623, 239);
            this.txtReceived.TabIndex = 0;
            // 
            // chkNewLine
            // 
            this.chkNewLine.AutoSize = true;
            this.chkNewLine.Location = new System.Drawing.Point(154, 59);
            this.chkNewLine.Name = "chkNewLine";
            this.chkNewLine.Size = new System.Drawing.Size(118, 17);
            this.chkNewLine.TabIndex = 8;
            this.chkNewLine.Text = "Use \\n \\r New Line";
            this.chkNewLine.UseVisualStyleBackColor = true;
            // 
            // dgvResponses
            // 
            this.dgvResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cExpected,
            this.cResponseEn,
            this.cResponse});
            this.dgvResponses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResponses.Location = new System.Drawing.Point(0, 0);
            this.dgvResponses.Name = "dgvResponses";
            this.dgvResponses.Size = new System.Drawing.Size(482, 534);
            this.dgvResponses.TabIndex = 0;
            // 
            // cExpected
            // 
            this.cExpected.HeaderText = "Expected";
            this.cExpected.Name = "cExpected";
            this.cExpected.Width = 200;
            // 
            // cResponseEn
            // 
            this.cResponseEn.HeaderText = "Enable Response";
            this.cResponseEn.Name = "cResponseEn";
            this.cResponseEn.Width = 50;
            // 
            // cResponse
            // 
            this.cResponse.HeaderText = "Response";
            this.cResponse.Name = "cResponse";
            this.cResponse.Width = 200;
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
            this.btnClearReceived.Click += new System.EventHandler(this.btnClearReceived_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tlpMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.dgvResponses);
            this.splitContainer1.Size = new System.Drawing.Size(1121, 534);
            this.splitContainer1.SplitterDistance = 635;
            this.splitContainer1.TabIndex = 5;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.grpComs, 0, 0);
            this.tlpMain.Controls.Add(this.grpReceived, 0, 1);
            this.tlpMain.Controls.Add(this.grpSend, 0, 2);
            this.tlpMain.Controls.Add(this.grpAutoResponse, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.Size = new System.Drawing.Size(635, 534);
            this.tlpMain.TabIndex = 3;
            // 
            // grpSend
            // 
            this.grpSend.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grpSend.Controls.Add(this.chkNewLine);
            this.grpSend.Controls.Add(this.radHexData);
            this.grpSend.Controls.Add(this.radText);
            this.grpSend.Controls.Add(this.lblSend);
            this.grpSend.Controls.Add(this.btnClearReceived);
            this.grpSend.Controls.Add(this.btnSend);
            this.grpSend.Controls.Add(this.txtSendCom);
            this.grpSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSend.Location = new System.Drawing.Point(3, 337);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(629, 94);
            this.grpSend.TabIndex = 2;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "Command";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(401, 16);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(62, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendCom
            // 
            this.txtSendCom.Location = new System.Drawing.Point(98, 16);
            this.txtSendCom.Multiline = true;
            this.txtSendCom.Name = "txtSendCom";
            this.txtSendCom.Size = new System.Drawing.Size(297, 36);
            this.txtSendCom.TabIndex = 0;
            // 
            // grpAutoResponse
            // 
            this.grpAutoResponse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpAutoResponse.Controls.Add(this.numTimeout);
            this.grpAutoResponse.Controls.Add(this.lblAutoResponse);
            this.grpAutoResponse.Controls.Add(this.txtAutoResponse);
            this.grpAutoResponse.Controls.Add(this.chkEnableAutoResponse);
            this.grpAutoResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAutoResponse.Location = new System.Drawing.Point(3, 437);
            this.grpAutoResponse.Name = "grpAutoResponse";
            this.grpAutoResponse.Size = new System.Drawing.Size(629, 94);
            this.grpAutoResponse.TabIndex = 3;
            this.grpAutoResponse.TabStop = false;
            this.grpAutoResponse.Text = "Auto Response";
            // 
            // numTimeout
            // 
            this.numTimeout.Location = new System.Drawing.Point(456, 32);
            this.numTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTimeout.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(120, 20);
            this.numTimeout.TabIndex = 6;
            this.numTimeout.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblAutoResponse
            // 
            this.lblAutoResponse.AutoSize = true;
            this.lblAutoResponse.Location = new System.Drawing.Point(10, 39);
            this.lblAutoResponse.Name = "lblAutoResponse";
            this.lblAutoResponse.Size = new System.Drawing.Size(82, 13);
            this.lblAutoResponse.TabIndex = 5;
            this.lblAutoResponse.Text = "Send Command";
            // 
            // txtAutoResponse
            // 
            this.txtAutoResponse.Location = new System.Drawing.Point(98, 35);
            this.txtAutoResponse.Multiline = true;
            this.txtAutoResponse.Name = "txtAutoResponse";
            this.txtAutoResponse.Size = new System.Drawing.Size(297, 36);
            this.txtAutoResponse.TabIndex = 4;
            // 
            // chkEnableAutoResponse
            // 
            this.chkEnableAutoResponse.AutoSize = true;
            this.chkEnableAutoResponse.Location = new System.Drawing.Point(26, 19);
            this.chkEnableAutoResponse.Name = "chkEnableAutoResponse";
            this.chkEnableAutoResponse.Size = new System.Drawing.Size(59, 17);
            this.chkEnableAutoResponse.TabIndex = 0;
            this.chkEnableAutoResponse.Text = "Enable";
            this.chkEnableAutoResponse.UseVisualStyleBackColor = true;
            // 
            // ethernetIPforCLXCom1
            // 
            this.ethernetIPforCLXCom1.CIPConnectionSize = 508;
            this.ethernetIPforCLXCom1.DisableMultiServiceRequest = false;
            this.ethernetIPforCLXCom1.DisableSubscriptions = false;
            this.ethernetIPforCLXCom1.IniFileName = "";
            this.ethernetIPforCLXCom1.IniFileSection = null;
            this.ethernetIPforCLXCom1.IPAddress = "192.168.0.10";
            this.ethernetIPforCLXCom1.PollRateOverride = 500;
            this.ethernetIPforCLXCom1.Port = 44818;
            this.ethernetIPforCLXCom1.ProcessorSlot = 1;
            this.ethernetIPforCLXCom1.RoutePath = null;
            this.ethernetIPforCLXCom1.Timeout = 4000;
            this.ethernetIPforCLXCom1.Disposed += new System.EventHandler(this.ethernetIPforCLXCom1_Disposed);
            this.ethernetIPforCLXCom1.DataReceived += new System.EventHandler<MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs>(this.ethernetIPforCLXCom1_DataReceived);
            this.ethernetIPforCLXCom1.ComError += new System.EventHandler<MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs>(this.ethernetIPforCLXCom1_ComError);
            this.ethernetIPforCLXCom1.ConnectionEstablished += new System.EventHandler(this.ethernetIPforCLXCom1_ConnectionEstablished);
            this.ethernetIPforCLXCom1.ConnectionClosed += new System.EventHandler(this.ethernetIPforCLXCom1_ConnectionClosed);
            // 
            // frmCLXTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 534);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCLXTerminal";
            this.Text = "CLX Terminal";
            this.grpComs.ResumeLayout(false);
            this.grpComs.PerformLayout();
            this.grpReceived.ResumeLayout(false);
            this.grpReceived.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponses)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.grpSend.ResumeLayout(false);
            this.grpSend.PerformLayout();
            this.grpAutoResponse.ResumeLayout(false);
            this.grpAutoResponse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ethernetIPforCLXCom1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpComs;
        private System.Windows.Forms.Button btnConnectRemote;
        private System.Windows.Forms.TextBox txtRemoteHost;
        private System.Windows.Forms.GroupBox grpReceived;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.CheckBox chkNewLine;
        private System.Windows.Forms.DataGridView dgvResponses;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExpected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cResponseEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResponse;
        private System.Windows.Forms.RadioButton radHexData;
        private System.Windows.Forms.RadioButton radText;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button btnClearReceived;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendCom;
        private System.Windows.Forms.GroupBox grpAutoResponse;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label lblAutoResponse;
        private System.Windows.Forms.TextBox txtAutoResponse;
        private System.Windows.Forms.CheckBox chkEnableAutoResponse;
        private AdvancedHMIDrivers.EthernetIPforCLXCom ethernetIPforCLXCom1;
    }
}

