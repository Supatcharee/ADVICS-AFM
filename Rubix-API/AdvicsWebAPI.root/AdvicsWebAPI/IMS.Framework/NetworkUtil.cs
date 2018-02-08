using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Rubix.Framework
{
    public class NetworkUtil
    {
        public static string GetIPAdress()
        {
            string hostName = Dns.GetHostName();
            string ipAddress = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addrList = ipEntry.AddressList;
            foreach (IPAddress ip in addrList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                    break;
                }
            }
            return ipAddress;
        }
    }
}
