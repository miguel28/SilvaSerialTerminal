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

            if(cboxComPorts.Items.Count > 0)
                cboxComPorts.SelectedIndex = 0;
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
            
            serialPort.BaudRate = GetBaudRate();
            serialPort.PortName = GetPortName();
            serialPort.Open();

            if (serialPort.IsOpen)
            {
                btnConnect.Text = "Disconnect!";
                timerReader.Enabled = true;
            }
            else
                MessageBox.Show("Couldn't open Serial port " + serialPort.PortName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return temp.Substring(0, temp.IndexOf(' '));
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        private void timerReader_Tick(object sender, EventArgs e)
        {
            txtReceived.Text += serialPort.ReadExisting();
            txtReceived.SelectionStart = txtReceived.TextLength;
            txtReceived.ScrollToCaret();
        }
    }

}
