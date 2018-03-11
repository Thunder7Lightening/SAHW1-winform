using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using System.Collections;

namespace SAHW1
{
    class MonitorSystem
    {
        private ArrayList _hostCollection = new ArrayList();

        public MonitorSystem()
        { 
            //產生初始監視hosts
            _hostCollection.Add(new Host("www.youtubehyrtd.com", ""));
            _hostCollection.Add(new Host("www.google.com", ""));
        }

        public void pingAll()
        { 
            foreach(Host host in _hostCollection)
                ping(host);
        }

        public void ping(Host host)
        {
            Ping p = new Ping();
            PingReply reply;

            try
            {
                IPAddress hostIP = Dns.GetHostAddresses(host.name())[0];
                reply = p.Send(hostIP);
                if (reply.Status == IPStatus.Success)
                {
                    host.setIp(hostIP.ToString());
                    host.setStatus(true);
                }
                else
                    host.setStatus(false);
            }
            catch
            {
                host.setStatus(false);
            }
        }

        public ArrayList currentHosts()
        {
            return _hostCollection;
        }
    }
}
