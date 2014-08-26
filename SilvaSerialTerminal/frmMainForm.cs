using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                        break;
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
                timerReader.Enabled = false;
                EnableConnectionGUI(true);
            }
            else 
            {
                serialPort.BaudRate = GetBaudRate();
                serialPort.PortName = GetPortName();
                serialPort.Open();

                if (serialPort.IsOpen)
                {
                    btnConnect.Text = "Disconnect!";
                    timerReader.Enabled = true;
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
            if (txtReceived.Text.Length > 10000)
                txtReceived.Text = txtReceived.Text.Substring(10000);

            txtReceived.Text += serialPort.ReadExisting();
            if(radText.Checked)
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
                    serialPort.Write(txtSendCom.Text);
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
    }

}
