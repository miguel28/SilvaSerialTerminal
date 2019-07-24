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

namespace SerialPortBridge
{
    public partial class frmBridge : Form
    {
        public frmBridge()
        {
            InitializeComponent();
            RefreshPortList();

            if (cboxBaudRate.Items.Count > 0)
                cboxBaudRate.SelectedIndex = 0;
            if (cboxBaudRate2.Items.Count > 0)
                cboxBaudRate2.SelectedIndex = 0;
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

            cboxComPorts2.Items.Clear();
            foreach (string port in GetPortNames())
            {
                cboxComPorts2.Items.Add(port);
            }
            if (cboxComPorts2.Items.Count > 0)
                cboxComPorts2.SelectedIndex = 0;
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

                foreach (string port in portnames)
                {
                    bool founded = false;
                    foreach (string iport in tList)
                    {
                        if (iport.Contains(port))
                        {
                            founded = true;
                        }
                    }
                    if (!founded)
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
            if (serialPort.IsOpen || serialPort2.IsOpen)
            {
                serialPort.Close();
                serialPort2.Close();
                btnConnect.Text = "Connect!";
                EnableConnectionGUI(true);
            }
            else
            {
                serialPort.BaudRate = GetBaudRate();
                serialPort.PortName = GetPortName();
                serialPort.Open();

                serialPort2.BaudRate = GetBaudRate2();
                serialPort2.PortName = GetPortName2();
                serialPort2.Open();

                if (serialPort.IsOpen && serialPort2.IsOpen)
                {
                    btnConnect.Text = "Disconnect!";
                    EnableConnectionGUI(false);
                }
                else
                {
                    if (serialPort.IsOpen)
                        MessageBox.Show("Couldn't open Serial port " + serialPort.PortName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (serialPort2.IsOpen)
                        MessageBox.Show("Couldn't open Serial port " + serialPort2.PortName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
        }

        private void EnableConnectionGUI(bool en)
        {
            cboxBaudRate.Enabled = en;
            cboxComPorts.Enabled = en;
            cboxBaudRate2.Enabled = en;
            cboxComPorts2.Enabled = en;
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
            string temp = cboxComPorts2.Items[cboxComPorts.SelectedIndex] as string;
            temp += ' ';
            return temp.Substring(0, temp.IndexOf(' '));
        }
        private int GetBaudRate2()
        {
            string temp = cboxBaudRate.Items[cboxBaudRate2.SelectedIndex] as string;
            int ret = int.Parse(temp);
            return ret;
        }
        private string GetPortName2()
        {
            string temp = cboxComPorts2.Items[cboxComPorts2.SelectedIndex] as string;
            temp += ' ';
            return temp.Substring(0, temp.IndexOf(' '));
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            byte[] arr = new byte[serialPort.BytesToRead];
            serialPort.Read(arr, 0, arr.Length);
            LogData("Port#1", arr);

            if (serialPort2.IsOpen)
            {
                serialPort2.Write(arr, 0, arr.Length);
            }
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            byte[] arr = new byte[serialPort2.BytesToRead];
            serialPort2.Read(arr, 0, arr.Length);
            LogData("Port#2", arr);
            if (serialPort.IsOpen)
            {
                serialPort.Write(arr, 0, arr.Length);
            }
        }

        private void LogData(string port_name, byte[] bytes)
        {
            Action a = () =>
            {
                txtReceived.Text += port_name + "->";
                if (radText.Checked)
                {
                    string text = ASCIIEncoding.Default.GetString(bytes);
                    txtReceived.Text += text;
                }
                else if (radHexData.Checked)
                {
                    string strReceived = BitConverter.ToString(bytes);

                    if (chkUse0xFF.Checked)
                        strReceived = strReceived.Replace("FF", "\r\n");
                    txtReceived.Text += strReceived;
                }
                
                txtReceived.SelectionStart = txtReceived.TextLength;
                txtReceived.ScrollToCaret();
            };
            this.Invoke(a);
        }
    }
}
