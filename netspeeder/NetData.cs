using System;
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
        public IPAddress broadcast;
    }
}
