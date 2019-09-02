namespace SilvaTCPTerminal
{
    partial class frmTCPTerminal
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
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblAutoResponse = new System.Windows.Forms.Label();
            this.txtAutoResponse = new System.Windows.Forms.TextBox();
            this.chkEnableAutoResponse = new System.Windows.Forms.CheckBox();
            this.grpAutoResponse = new System.Windows.Forms.GroupBox();
            this.chkNewLine = new System.Windows.Forms.CheckBox();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.btnSendFF = new System.Windows.Forms.Button();
            this.chkUse0xFF = new System.Windows.Forms.CheckBox();
            this.radHexData = new System.Windows.Forms.RadioButton();
            this.radText = new System.Windows.Forms.RadioButton();
            this.lblSend = new System.Windows.Forms.Label();
            this.btnClearReceived = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendCom = new System.Windows.Forms.TextBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpComs = new System.Windows.Forms.GroupBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPortListen = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpReceived = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvResponses = new System.Windows.Forms.DataGridView();
            this.cExpected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResponseEn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cResponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemoteHost = new System.Windows.Forms.TextBox();
            this.btnConnectRemote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.grpAutoResponse.SuspendLayout();
            this.grpSend.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.grpComs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponses)).BeginInit();
            this.SuspendLayout();
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
            // grpAutoResponse
            // 
            this.grpAutoResponse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpAutoResponse.Controls.Add(this.numTimeout);
            this.grpAutoResponse.Controls.Add(this.lblAutoResponse);
            this.grpAutoResponse.Controls.Add(this.txtAutoResponse);
            this.grpAutoResponse.Controls.Add(this.chkEnableAutoResponse);
            this.grpAutoResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAutoResponse.Location = new System.Drawing.Point(3, 464);
            this.grpAutoResponse.Name = "grpAutoResponse";
            this.grpAutoResponse.Size = new System.Drawing.Size(665, 94);
            this.grpAutoResponse.TabIndex = 3;
            this.grpAutoResponse.TabStop = false;
            this.grpAutoResponse.Text = "Auto Response";
            // 
            // chkNewLine
            // 
            this.chkNewLine.AutoSize = true;
            this.chkNewLine.Location = new System.Drawing.Point(164, 77);
            this.chkNewLine.Name = "chkNewLine";
            this.chkNewLine.Size = new System.Drawing.Size(118, 17);
            this.chkNewLine.TabIndex = 8;
            this.chkNewLine.Text = "Use \\n \\r New Line";
            this.chkNewLine.UseVisualStyleBackColor = true;
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
            this.grpSend.Location = new System.Drawing.Point(3, 364);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(665, 94);
            this.grpSend.TabIndex = 2;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "Command";
            // 
            // btnSendFF
            // 
            this.btnSendFF.Location = new System.Drawing.Point(401, 59);
            this.btnSendFF.Name = "btnSendFF";
            this.btnSendFF.Size = new System.Drawing.Size(62, 29);
            this.btnSendFF.TabIndex = 7;
            this.btnSendFF.Text = "Send FF";
            this.btnSendFF.UseVisualStyleBackColor = true;
            this.btnSendFF.Click += new System.EventHandler(this.btnSendFF_Click);
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
            this.btnClearReceived.Click += new System.EventHandler(this.btnClearReceived_Click);
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
            // txtReceived
            // 
            this.txtReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceived.Location = new System.Drawing.Point(3, 16);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceived.Size = new System.Drawing.Size(659, 266);
            this.txtReceived.TabIndex = 0;
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
            this.tlpMain.Size = new System.Drawing.Size(671, 561);
            this.tlpMain.TabIndex = 3;
            // 
            // grpComs
            // 
            this.grpComs.BackColor = System.Drawing.SystemColors.Desktop;
            this.grpComs.Controls.Add(this.btnConnectRemote);
            this.grpComs.Controls.Add(this.txtRemoteHost);
            this.grpComs.Controls.Add(this.numPort);
            this.grpComs.Controls.Add(this.lblPortListen);
            this.grpComs.Controls.Add(this.btnConnect);
            this.grpComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComs.ForeColor = System.Drawing.SystemColors.Control;
            this.grpComs.Location = new System.Drawing.Point(3, 3);
            this.grpComs.Name = "grpComs";
            this.grpComs.Size = new System.Drawing.Size(665, 64);
            this.grpComs.TabIndex = 0;
            this.grpComs.TabStop = false;
            this.grpComs.Text = "Serial Ports";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(68, 24);
            this.numPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(80, 20);
            this.numPort.TabIndex = 6;
            this.numPort.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // lblPortListen
            // 
            this.lblPortListen.AutoSize = true;
            this.lblPortListen.BackColor = System.Drawing.Color.Transparent;
            this.lblPortListen.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPortListen.Location = new System.Drawing.Point(18, 26);
            this.lblPortListen.Name = "lblPortListen";
            this.lblPortListen.Size = new System.Drawing.Size(30, 13);
            this.lblPortListen.TabIndex = 5;
            this.lblPortListen.Text = "Port";
            // 
            // btnConnect
            // 
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnect.Location = new System.Drawing.Point(164, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(97, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect!";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpReceived
            // 
            this.grpReceived.Controls.Add(this.txtReceived);
            this.grpReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceived.Location = new System.Drawing.Point(3, 73);
            this.grpReceived.Name = "grpReceived";
            this.grpReceived.Size = new System.Drawing.Size(665, 285);
            this.grpReceived.TabIndex = 1;
            this.grpReceived.TabStop = false;
            this.grpReceived.Text = "ReceivedText";
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
            this.splitContainer1.Size = new System.Drawing.Size(1184, 561);
            this.splitContainer1.SplitterDistance = 671;
            this.splitContainer1.TabIndex = 4;
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
            this.dgvResponses.Size = new System.Drawing.Size(509, 561);
            this.dgvResponses.TabIndex = 0;
            this.dgvResponses.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResponses_CellMouseClick);
            this.dgvResponses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvResponses_MouseClick);
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
            // txtRemoteHost
            // 
            this.txtRemoteHost.Location = new System.Drawing.Point(316, 20);
            this.txtRemoteHost.Name = "txtRemoteHost";
            this.txtRemoteHost.Size = new System.Drawing.Size(100, 20);
            this.txtRemoteHost.TabIndex = 7;
            this.txtRemoteHost.Text = "192.168.1.7";
            // 
            // btnConnectRemote
            // 
            this.btnConnectRemote.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnectRemote.Location = new System.Drawing.Point(422, 20);
            this.btnConnectRemote.Name = "btnConnectRemote";
            this.btnConnectRemote.Size = new System.Drawing.Size(97, 23);
            this.btnConnectRemote.TabIndex = 8;
            this.btnConnectRemote.Text = "Connect!";
            this.btnConnectRemote.UseVisualStyleBackColor = true;
            this.btnConnectRemote.Click += new System.EventHandler(this.btnConnectRemote_Click);
            // 
            // frmTCPTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTCPTerminal";
            this.Text = "Silva TCP Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTCPTerminal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.grpAutoResponse.ResumeLayout(false);
            this.grpAutoResponse.PerformLayout();
            this.grpSend.ResumeLayout(false);
            this.grpSend.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.grpComs.ResumeLayout(false);
            this.grpComs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpReceived.ResumeLayout(false);
            this.grpReceived.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label lblAutoResponse;
        private System.Windows.Forms.TextBox txtAutoResponse;
        private System.Windows.Forms.CheckBox chkEnableAutoResponse;
        private System.Windows.Forms.GroupBox grpAutoResponse;
        private System.Windows.Forms.CheckBox chkNewLine;
        private System.Windows.Forms.GroupBox grpSend;
        private System.Windows.Forms.Button btnSendFF;
        private System.Windows.Forms.CheckBox chkUse0xFF;
        private System.Windows.Forms.RadioButton radHexData;
        private System.Windows.Forms.RadioButton radText;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button btnClearReceived;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendCom;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpComs;
        private System.Windows.Forms.Label lblPortListen;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpReceived;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvResponses;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExpected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cResponseEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResponse;
        private System.Windows.Forms.Button btnConnectRemote;
        private System.Windows.Forms.TextBox txtRemoteHost;
    }
}

