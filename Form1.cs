using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpScanner
{
    public partial class Form1 : Form
    {
        NetPinger netPing = new NetPinger();
        public Form1()
        {
            InitializeComponent();
            textBox1.ForeColor = Color.Red;
            netPing.PingEvent += NetPing_PingEvent;
        }
        private void NetPing_PingEvent(object sender, string e)
        {
            PrintResults();
        }
        private void PrintResults()
        {
            //textBox1.Text += ""+ Environment.NewLine;
            foreach (var host in netPing.hosts)
            {
                string[] hostNameStr = host.hostName.ToString().Split('.');
                textBox1.AppendText(host.ipAddress + "    " + hostNameStr[0] + "\r\n");
            }

            string tSpanSec = String.Format("{0:F3} ", netPing.ts.TotalSeconds);
            textBox1.AppendText("\r\n" + netPing.nFound.ToString() + " devices found... Elapsed Time: " +
                tSpanSec + " seconds" + "\r\n\r\n");
            netPing.hosts.Clear();
        }
        #region  Button Event Handlers
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Scanning " + netPing.BaseIP + "..." + "\r\n\r\n");
            netPing.RunPingSweep_Async();
        }

        #endregion
    }

}
