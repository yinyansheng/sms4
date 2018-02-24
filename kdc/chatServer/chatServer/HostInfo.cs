using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace chatServer
{
    class HostInfo
    {
        private bool checkInputIP(string testIP)
        {

            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
            bool b = Regex.IsMatch(testIP, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
            return b;
        }

        public string getHostIP() //获取IP
        {
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName); //得到主机IP
            string strIPAddr = IpEntry.AddressList[0].ToString();
            if (!(checkInputIP(strIPAddr)))
            {
                strIPAddr = IpEntry.AddressList[1].ToString();
            }
            return (strIPAddr);
        }

    }
}
