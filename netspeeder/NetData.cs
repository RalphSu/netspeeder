using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

namespace netspeeder
{
    class NetData
    {
        public NetworkInterface netiface;
        public IPAddress ip;
        public IPAddress netmask;
    }
}
