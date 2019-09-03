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

namespace CLXTerminal
{
    public partial class frmCLXTerminal : Form
    {
        public frmCLXTerminal()
        {
            InitializeComponent();
            CreateContextMenus();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ethernetIPforCLXCom1.IPAddress = txtRemoteHost.Text;
            string response = ethernetIPforCLXCom1.Read("OP_Write");

            EnableConnectionGUI(true);
            ethernetIPforCLXCom1.Subscribe("data_to_send", 1, 10, ethernetIPforCLXCom1_DataReceived);
        }

        private void EnableConnectionGUI(bool en)
        {
            btnSend.Enabled = en;
        }

        private void btnClearReceived_Click(object sender, EventArgs e)
        {
            txtReceived.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SendString(txtSendCom.Text);
            }
            catch (Exception comException)
            {
                MessageBox.Show("Error : " + comException.Message, "Error Device Disconnected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
                //Application.Exit();
                //Environment.Exit(1);
            }
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
                if (chkNewLine.Checked)
                {
                    SendString(txtAutoResponse.Text + "\r");
                }
                else
                {
                    SendString(txtAutoResponse.Text);
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
            for (int i = 0; i < dgvResponses.RowCount; i++)
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
                                SendString(response + "\r");
                            }
                            else
                            {
                                SendString(response);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void SendString(string input)
        {
            //byte[] arr = new byte[4 + 4096];
            //byte[] len = BitConverter.GetBytes((int)input.Length);
            //byte[] data = ASCIIEncoding.ASCII.GetBytes(input);
            //Array.Copy(len, 0, arr, 0, 4);
            //Array.Copy(data, 0, arr, 4, data.Length);

            //ethernetIPforCLXCom1.WriteRaw("OP_Read", 1, arr);
            ethernetIPforCLXCom1.WriteCustomString("OP_Read", input, 4096);
            ethernetIPforCLXCom1.Write("data_ready", "1");
        }

        private string DecodeString(string input)
        {
            if (input.Length < 8)
                return input;
            string index = input.Substring(0, 8);
            int len = 0;
            for (int i = 0; i < 4; i++)
            {
                string byte_a = input[(i * 2) + 0].ToString() + input[(i * 2) + 1];
                int intValue = int.Parse(byte_a, System.Globalization.NumberStyles.HexNumber);
                byte b = (byte)intValue;
                len |= (b << ((i - 4) * 8));
            }

            byte[] asscii = new byte[len];
            for (int i = 0; i< len; i++)
            {
                string byte_a = input[(i * 2) + 8].ToString() + input[(i * 2) + 9];
                int intValue = int.Parse(byte_a, System.Globalization.NumberStyles.HexNumber);
                byte b = (byte)intValue;
                asscii[i] = b;
            }

            return ASCIIEncoding.ASCII.GetString(asscii);
        }

        private void ethernetIPforCLXCom1_ComError(object sender, MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs e)
        {
            Action a = () => txtReceived.AppendText("Error Client " + e.ErrorMessage + "\r\n");
            this.Invoke(a);
        }

        private void ethernetIPforCLXCom1_ConnectionClosed(object sender, EventArgs e)
        {
            Action a = () => txtReceived.AppendText("Connection Closed Client " + "\r\n");
            this.Invoke(a);
        }

        private void ethernetIPforCLXCom1_ConnectionEstablished(object sender, EventArgs e)
        {
            Action a = () => txtReceived.AppendText("Connection Opened " + "\r\n");
            this.Invoke(a);
        }

        private void ethernetIPforCLXCom1_DataReceived(object sender, MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs e)
        {
            if (e.PlcAddress.Contains("data_to_send"))
            {
                if (e.Values[0].Contains("1"))
                {
                    string response = ethernetIPforCLXCom1.Read("OP_Write");
                    ethernetIPforCLXCom1.Write("data_to_send", "0");
                }
                
            }
            else
            {
                string d = DecodeString(e.Values[0]);
                Action a = () => txtReceived.AppendText(d);
                this.Invoke(a);
            }
        }

        private void ethernetIPforCLXCom1_Disposed(object sender, EventArgs e)
        {
            Action a = () => txtReceived.AppendText("Connection Disposed " + "\r\n");
            this.Invoke(a);
        }

        #region Contextmenu
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

                using (FileStream fs = new FileStream(dia.FileName, FileMode.Create))
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
        #endregion

        
    }
}
