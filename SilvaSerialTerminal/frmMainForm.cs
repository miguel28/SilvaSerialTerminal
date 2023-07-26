using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;   

namespace SilvaSerialTerminal
{
    public partial class frmMainForm : Form
    {
        
        public frmMainForm()
        {
            InitializeComponent();
            RefreshPortList();

            if (cboxBaudRate.Items.Count > 0)
                cboxBaudRate.SelectedIndex = 0;
        }

        private void RefreshPortList()
        {
            cboxComPorts.Items.Clear();
            foreach (string port in GetPortNames())
            {
                cboxComPorts.Items.Add(port);
            }
            if (cboxComPorts.Items.Count > 0)
                cboxComPorts.SelectedIndex = 0;
        }
        private List<string> GetPortNames()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames
                             join p in ports on n equals p["DeviceID"].ToString()
                             select n + " - " + p["Caption"]).ToList();

                foreach(string port in portnames)
                {
                    bool founded = false;
                    foreach (string iport in tList)
                    {
                        if (iport.Contains(port))
                        {
                            founded = true;
                        }
                    }  
                    if(!founded)
                    {
                        tList.Add(port);
                        continue;
                    }

                }

                return tList;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPortList();
        }
        private void txtBaudRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
            {
                serialPort.Close();
                btnConnect.Text = "Connect!";
                //timerReader.Enabled = false;
                EnableConnectionGUI(true);
            }
            else 
            {
                serialPort.BaudRate = GetBaudRate();
                serialPort.PortName = GetPortName();
                serialPort.Handshake = Handshake.None;

                serialPort.Open();

                if (serialPort.IsOpen)
                {
                    btnConnect.Text = "Disconnect!";
                    //timerReader.Enabled = true;
                    EnableConnectionGUI(false);
                }
                else
                    MessageBox.Show("Couldn't open Serial port " + serialPort.PortName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void EnableConnectionGUI(bool en)
        {
            cboxBaudRate.Enabled = en;
            cboxComPorts.Enabled = en;
            btnRefresh.Enabled = en;
            btnSend.Enabled = !en;
        }
        private int GetBaudRate()
        {
            string temp = cboxBaudRate.Items[cboxBaudRate.SelectedIndex] as string;
            int ret = int.Parse(temp);
            return ret;
        }
        private string GetPortName()
        {
            string temp = cboxComPorts.Items[cboxComPorts.SelectedIndex] as string;
            temp += ' ';
            return temp.Substring(0, temp.IndexOf(' '));
        }

        private void timerReader_Tick(object sender, EventArgs e)
        {
            ProcessIncommingData();
        }

        private void btnClearReceived_Click(object sender, EventArgs e)
        {
            txtReceived.Text = "";
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if(serialPort.IsOpen)
                {
                    if (chkNewLine.Checked)
                    {
                        string dd = txtSendCom.Text + "\x0d";
                        serialPort.Write(dd);
                    }
                    else
                    {
                        if (radHexData.Checked)
                        {
                            string[] splited = txtSendCom.Text.Split('-');
                            byte[] data = new byte[splited.Length];
                            if (data.Length > 0)
                            {
                                for(int i = 0; i < data.Length; i++)
                                {
                                    data[i] = (byte)Convert.ToInt32(splited[i], 16);
                                }
                                serialPort.Write(data, 0, data.Length);
                            }
                        }
                        else
                        {
                            serialPort.Write(txtSendCom.Text);
                        }
                    }
                    
                }
                    
            }
            catch(Exception comException)
            {
                MessageBox.Show("Error : " + comException.Message, "Error Device Disconnected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
                Application.Exit();
                //Environment.Exit(1);
            }
        }
        private void txtSendCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if ((int)e.KeyChar == (int)Keys.Enter)
                btnSend_Click(sender, e);*/
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
            serialPort.Write(b,0,12);
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Action a = () => ProcessIncommingData();
            this.Invoke(a);
        }

        private void ProcessIncommingData()
        {
            if (txtReceived.Text.Length > 10000)
                txtReceived.Text = txtReceived.Text.Substring(10000);

            if (radText.Checked)
            {
                string strReceived = serialPort.ReadExisting();
                txtReceived.Text += strReceived;
            }
            else if (radHexData.Checked)
            {
                byte[] data = new byte[serialPort.BytesToRead];
                serialPort.Read(data, 0, data.Length);
                string strReceived = BitConverter.ToString(data);

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
                if (serialPort.IsOpen)
                {
                    if (chkNewLine.Checked)
                    {
                        serialPort.Write(txtAutoResponse.Text + "\r");
                    }
                    else
                    {
                        serialPort.Write(txtAutoResponse.Text);
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
