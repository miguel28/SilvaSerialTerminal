using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IPCLib;

namespace SilvaTCPTerminal
{
    public partial class frmTCPTerminal : Form
    {
        private TCPServer m_server;
        private TCPClient m_client;

        public frmTCPTerminal()
        {
            InitializeComponent();
            CreateContextMenus();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (m_server != null)
            {
                m_server.StopServer();
                m_server = null;
                btnConnect.Text = "Connect as Server!";
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

                if (m_client != null && m_client.IsRunning)
                {
                    byte[] data = null;
                    if (chkNewLine.Checked)
                    {
                        string d = "\x13" + txtSendCom.Text + "\n\x11";
                        data = ASCIIEncoding.Default.GetBytes(d);
                    }
                    else
                    {
                        string d = txtSendCom.Text;
                        data = ASCIIEncoding.Default.GetBytes(d);
                    }
                    m_client.SendMessage(data);
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
                CheckForAutoResponsesGrid(strReceived);
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

                if (m_client != null && m_client.IsRunning)
                {
                    byte[] d;
                    if (chkNewLine.Checked)
                    {
                        d = ASCIIEncoding.Default.GetBytes(txtAutoResponse.Text + "\r");
                        m_client.SendMessage(d);
                    }
                    else
                    {
                        d = ASCIIEncoding.Default.GetBytes(txtAutoResponse.Text);
                        m_client.SendMessage(d);
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

        private void CheckForAutoResponsesGrid(string input)
        {
            for(int i = 0; i < dgvResponses.RowCount; i++)
            {
                if (dgvResponses.Rows[i].IsNewRow)
                    continue;

                string expected = dgvResponses.Rows[i].Cells[0].Value as string;
                bool enabled = (bool)dgvResponses.Rows[i].Cells[1].Value;
                if (!string.IsNullOrEmpty(expected) && enabled)
                {
                    if (input.Contains(expected))
                    {
                        string response = dgvResponses.Rows[i].Cells[2].Value as string;
                        if (!string.IsNullOrEmpty(response))
                        {
                            if (chkNewLine.Checked)
                            {
                                m_server.SendMessageToAllClients(response + "\r");
                            }
                            else
                            {
                                m_server.SendMessageToAllClients(response);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private ContextMenu menu = new ContextMenu();
        private void CreateContextMenus()
        {
            menu.MenuItems.Add("Load", LoadResponses);
            menu.MenuItems.Add("Save", SaveResponses);
        }

        private void LoadResponses(object sender, EventArgs args)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "(*.txt)|*.txt";
            DialogResult result = dia.ShowDialog();
            if (result == DialogResult.OK)
            {

                dgvResponses.Rows.Clear();
                string[] lines = File.ReadAllLines(dia.FileName);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    dgvResponses.Rows.Add(new object[] { data[0], data[1].ToLower().Contains("true"), data[2] });
                }
            }
        }

        private void SaveResponses(object sender, EventArgs args)
        {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Filter = "(*.txt)|*.txt";
            DialogResult result = dia.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (File.Exists(dia.FileName))
                    File.Delete(dia.FileName);

                using (FileStream fs = new FileStream(dia.FileName,FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < dgvResponses.RowCount; i++)
                        {
                            if (dgvResponses.Rows[i].IsNewRow)
                                continue;
                            string data = string.Format("{0},{1},{2}",
                                dgvResponses.Rows[i].Cells[0].Value as String,
                                (dgvResponses.Rows[i].Cells[1].Value).ToString(),
                                dgvResponses.Rows[i].Cells[2].Value as String
                                );
                            sw.WriteLine(data);
                        }
                    }
                }
            }
        }

        private void dgvResponses_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                menu.Show(dgvResponses, e.Location);
        }

        private void dgvResponses_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                menu.Show(dgvResponses, e.Location);
        }

        private void btnConnectRemote_Click(object sender, EventArgs e)
        {
            if (m_client != null)
            {
                m_client.Stop();
                m_client = null;
                btnConnectRemote.Text = "Connect!";
                EnableConnectionGUI(true);
            }
            else
            {
                try
                {
                    m_client = TCPClient.CreateApplicationClient(txtRemoteHost.Text, (int)numPort.Value);
                   
                    m_client.MessageReceived += M_server_MessageReceived;
                    m_client.Connected += M_client_Connected;
                    m_client.Disconnected += M_client_Disconnected;
                    m_client.Start();

                    btnConnectRemote.Text = "Disconnect!";
                    EnableConnectionGUI(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't create tcp server: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void M_client_Disconnected(object sender, EventArgs e)
        {
            Action a = () => txtReceived.AppendText("Disconnected Client " +  "\r\n");
            this.Invoke(a);

        }

        private void M_client_Connected(object sender, EventArgs e)
        {
            Action a = () => txtReceived.AppendText("Connected Client " +"\r\n");
            this.Invoke(a);
        }

        private void frmTCPTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_server != null)
                m_server.StopServer();

            if (m_client != null)
                m_client.Stop();
        }
    }
}
