using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using System.Collections;

namespace SAHW1
{
    public partial class Form1 : Form
    {
        private DataGridViewRowCollection rows;
        private MonitorSystem monitorSystem = new MonitorSystem();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rows = dataGridView1.Rows;
            label1.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshMonitorSystem();
        }

        private void refreshMonitorSystem()
        {
            monitorSystem.pingAll();
            refreshDataGridView();
        }

        private void refreshDataGridView()
        {
            rows.Clear();
            ArrayList hostCollection = monitorSystem.currentHosts();
            foreach (Host host in hostCollection)
                rows.Add(new Object[] { host.name(), host.ip(), host.status() });
        }

        #region 暫時別看

        private void button1_Click(object sender, EventArgs e)
        {
            //ping("www.yahoo6656575675675.com");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        #endregion
    }
}
