using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace chatClient
{
    class HostInfo
    {
        public string getHostIP() //获取IP
        {
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName); //得到主机IP
            string strIPAddr = IpEntry.AddressList[0].ToString();
            if (!(new TextCheck().checkInputIP(strIPAddr))) {
                strIPAddr = IpEntry.AddressList[1].ToString();
            }
            return strIPAddr;
        }

    }
}
