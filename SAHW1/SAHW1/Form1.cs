﻿using System;
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
        private ArrayList hostCollection;

        public Form1()
        {
            InitializeComponent();
            rows = dataGridView1.Rows;
            hostCollection = new ArrayList();
            label1.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ping("www.youtubesdhgfgdrt.com");
            ping("www.google.com");
        }

        public void pingAll(ArrayList hostCollection)
        {
            foreach (String hostName in hostCollection)
            {
                ping(hostName);
            }
        }

        public void ping(string hostName)
        {
            Host host = ByPing(hostName);
            
            rows.Add(new Object[] { host.name(), host.ip(), host.status() });

            if (!hostCollection.Contains(hostName))
                hostCollection.Add(hostName);
        }

        public Host ByPing(string hostName)
        {
            Ping p = new Ping();
            PingReply reply;

            try
            {
                IPAddress hostIP = Dns.GetHostAddresses(hostName)[0];
                reply = p.Send(hostIP);
                if (reply.Status == IPStatus.Success)
                    return new Host(hostName, hostIP.ToString(), true);
            }
            catch
            {
                return Host.FailHost(hostName, false);
            }

            return Host.FailHost(hostName, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ping("www.yahoo6656575675675.com");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshDatas();
        }

        private void refreshDatas()
        {
            rows.Clear();
            pingAll(hostCollection);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
    }

    public class Host
    {
        private string _name;
        private string _ip;
        private bool _status;

        public Host(string name, string ip, bool status)
        {
            _name = name;
            _ip = ip;
            _status = status;
        }

        public static Host FailHost(string name, bool status)
        {
            return new Host(name, "", status);
        }

        public String name()
        {
            return _name;
        }

        public String ip()
        {
            return _ip;
        }

        public String status()
        {
            return _status ? "Up" : "Down";
        }
    }
}
