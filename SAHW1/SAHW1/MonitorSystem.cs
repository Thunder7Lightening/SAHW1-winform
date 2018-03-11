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
            initHostData();
        }

        public void initHostData()
        {
            addHost(new Host("www.youtubehyrtd.com"));
            addHost(new Host("www.google.com"));
            addHost(new Host("www.facebook.com"));
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
                    if (!isHostAlreadyInMonitoring(host))
                        addHost(host);
                }
                else
                {
                    host.setStatus(false);
                    if (!isHostAlreadyInMonitoring(host))
                        addHost(host);
                }
            }
            catch
            {
                host.setStatus(false);
                if (!isHostAlreadyInMonitoring(host))
                    addHost(host);
            }
        }

        public ArrayList currentHosts()
        {
            return _hostCollection;
        }

        public void addHost(Host host)
        {
            _hostCollection.Add(host);
        }

        public void removeHost(Host host)
        {
            if (isHostAlreadyInMonitoring(host))
            {
                host = getHostFromHostCollection(host);
                _hostCollection.Remove(host);
            }
        }

        public Host getHostFromHostCollection(Host host)
        {
            foreach (Host hostFromHostCollection in _hostCollection)
            {
                if (host.name().Equals(hostFromHostCollection.name()))
                    return hostFromHostCollection;
            }
            return null;
        }

        public bool isHostAlreadyInMonitoring(Host host)
        {
            foreach(Host hostFromHostCollection in _hostCollection)
            {
                if(host.name().Equals(hostFromHostCollection.name()))
                    return true;
                else if(host.name().Equals(hostFromHostCollection.ip()))
                    return true;
            }
            return false;
        }
    }
}
