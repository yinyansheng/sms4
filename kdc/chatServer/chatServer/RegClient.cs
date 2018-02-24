using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace chatServer
{
    /// <summary>
    /// 注册成功的客户实体类
    /// </summary>
    class RegClient
    {

        public RegClient() { 
        
        }

        public RegClient(string username) {
            this.username = username;
            this.clientIP = IPAddress.Parse(username.Split('b')[0].Replace('a', '.'));
            this.clientPort = int.Parse(username.Split('b')[1]);
        }

        //用户名
        protected string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        //客户端IP
        protected IPAddress clientIP;

        public IPAddress ClientIP
        {
            get { return clientIP; }
            set { clientIP = value; }
        }

        //客户端监听端口
        protected int clientPort;

        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }

        public override string ToString()
        {
            return username;
        }


    }
}
