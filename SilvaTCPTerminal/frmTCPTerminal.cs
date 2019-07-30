using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPCLib;

namespace SilvaTCPTerminal
{
    public partial class frmTCPTerminal : Form
    {
        private TCPServer m_server;

        public frmTCPTerminal()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (m_server != null)
            {
                m_server.StopServer();
                m_server = null;
                btnConnect.Text = "Connect!";
                EnableConnectionGUI(true);
            }
            else
            {
                try
                {
                    m_server = new TCPServer((int)numPort.Value);
                    m_server.MessageReceived += M_server_MessageReceived;
                    m_server.ClientConnected += M_server_ClientConnected;
                    m_server.ClientDisconnected += M_server_ClientDisconnected;
                    m_server.StartServer();
                    btnConnect.Text = "Disconnect!";
                    EnableConnectionGUI(false);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Couldn't create tcp server: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        private void M_server_ClientDisconnected(TCPClient client)
        {
            Action a = () => txtReceived.AppendText("Disconnected Client " + client.ToString() + "\r\n");
            this.Invoke(a);
        }

        private void M_server_ClientConnected(TCPClient client)
        {
            Action a = () => txtReceived.AppendText("Connected Client " + client.ToString() + "\r\n");
            this.Invoke(a);
        }

        private void M_server_MessageReceived(TCPClient client, byte[] message)
        {
            Action a = () => ProcessIncommingData(message);
            this.Invoke(a);
        }

        private void EnableConnectionGUI(bool en)
        {
            numPort.Enabled = en;
            btnSend.Enabled = !en;
        }

        private void btnClearReceived_Click(object sender, EventArgs e)
        {
            txtReceived.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_server!= null && m_server.IsListening)
                {
                    if (chkNewLine.Checked)
                    {
                        m_server.SendMessageToAllClients(txtSendCom.Text + "\r");
                    }
                    else
                    {
                        m_server.SendMessageToAllClients(txtSendCom.Text);
                    }
                }
            }
            catch (Exception comException)
            {
                MessageBox.Show("Error : " + comException.Message, "Error Device Disconnected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
                Application.Exit();
                //Environment.Exit(1);
            }
        }

        private void btnSendFF_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[12];
            b[0] = (byte)0x00;
            b[1] = (byte)0x02;
            b[2] = (byte)0x80;
            b[3] = (byte)0x80;
            b[4] = (byte)0x80;
            b[5] = (byte)0x80;
            b[6] = (byte)0x80;
            b[7] = (byte)0x80;
            b[8] = (byte)0x80;
            b[9] = (byte)0x80;
            b[10] = (byte)0xff;
            b[11] = (byte)0xff;
            m_server?.SendMessageToAllClients(b);
        }

        private void ProcessIncommingData(byte[] msg)
        {
            if (txtReceived.Text.Length > 10000)
                txtReceived.Text = txtReceived.Text.Substring(10000);

            if (radText.Checked)
            {
                string strReceived = ASCIIEncoding.Default.GetString(msg);
                txtReceived.Text += strReceived;
            }
            else if (radHexData.Checked)
            {
                string strReceived = BitConverter.ToString(msg);

                if (chkUse0xFF.Checked)
                    strReceived = strReceived.Replace("FF", "\r\n");
                txtReceived.Text += strReceived;
            }
            txtReceived.SelectionStart = txtReceived.TextLength;
            txtReceived.ScrollToCaret();

            if (chkEnableAutoResponse.Checked && !string.IsNullOrEmpty(txtAutoResponse.Text))
            {
                Task.Delay((int)numTimeout.Value).ContinueWith(t => SendAutoResponse());
            }
        }

        private void SendAutoResponse()
        {
            try
            {
                if (m_server != null && m_server.IsListening)
                {
                    if (chkNewLine.Checked)
                    {
                        m_server.SendMessageToAllClients(txtAutoResponse.Text + "\r");
                    }
                    else
                    {
                        m_server.SendMessageToAllClients(txtAutoResponse.Text);
                    }
                }
            }
            catch (Exception comException)
            {
                MessageBox.Show("Error : " + comException.Message, "Error Device Disconnected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
                Application.Exit();
                //Environment.Exit(1);
            }
        }

    }
}
