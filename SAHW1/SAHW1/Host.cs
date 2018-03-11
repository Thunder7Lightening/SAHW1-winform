using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHW1
{
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
