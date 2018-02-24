using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace chatServer
{
    public partial class chatServer : Form
    {
        public chatServer()
        {
            InitializeComponent();
        }

        private void chatServer_Load(object sender, EventArgs e)
        {
            init();
        }



        //指示是否服务
        private bool isService = true;

        //server 密钥

        private string KDCaes;
        private string KDCe;
        private string KDCn;
        private string KDCp;
        private string KDCq;
        private string KDCd;
        private string serverIP;
        private string serverPort;

        private RSA rsa;
        private AES aes;


        private void btnService_Click(object sender, EventArgs e)
        {
            if (isService)
            {
                try
                {
                    beginService();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                    this.Close();
                }
                    this.btnService.Enabled = false;
            }
            else { 
                //没有开启服务
            }
        }

        //当前注册用户
        private ArrayList regClients = new ArrayList();
        //当前获取证书用户
        private ArrayList cerClients = new ArrayList();
        //当前通信组
        private ArrayList comClientGroups = new ArrayList();



        private void ReceiveData()
        {

            UdpClient udpClient = new UdpClient(int.Parse(serverPort));
            //远程主机节点
            IPEndPoint remote = null;
            //返回的报文
            string backMsg = string.Empty;


            //接收从远程主机发送过来的信息
            while (true)
            {
                //关闭udpClient时此句会产生异常
                //此句阻塞
                byte[] bytes = udpClient.Receive(ref remote);
                string recStr = aes.AesDecipher(Encoding.UTF8.GetString(bytes, 0, bytes.Length)).Trim();

              // this.txtComInfo.AppendText("\r\n" + recStr);
              // this.txtComInfo.AppendText("\r\n" + string.Format("来自{0}：{1}", remote, recStr));

                //必须加这句，原因未知。
                Thread.Sleep(100);

                string[] recStrArr = recStr.Split('|');

                //连接
                if (recStrArr[0] == "1")
                {
                    sendMessage(aes.AesEncipher("1" + "|" + recStrArr[3].ToUpper()), IPAddress.Parse(recStrArr[1]), int.Parse(recStrArr[2]));
                    this.txtComInfo.AppendText("\r\n处理来自" + remote + "的连接请求。");
                }

                //注册
                if (recStrArr[0] == "2")
                {
                    string username = rsa.Decryption(recStrArr[3], KDCp, KDCq, KDCd);
                    RegClient regClient = new RegClient(username);

                    //检查是否已经注册此用户
                    //标志
                    int flag = 0;
                    for (int i = 0; i < regClients.Count; i++)
                    {
                        if (regClient.Username == ((RegClient)regClients[i]).Username)
                        {
                            flag = 1;
                        }
                    }


                    this.txtComInfo.AppendText("\r\n处理来自" + username + "的注册请求。");
                    //用户未注册
                    if (0 == flag)
                    {
                        regClients.Add(regClient);
                        backMsg = rsa.Encryption(username, KDCp, KDCq, KDCd);
                        sendMessage(aes.AesEncipher("2|" + backMsg), regClient.ClientIP, regClient.ClientPort);
                    }
                    if (1 == flag)
                    {
                        //用户已经注册
                        backMsg = rsa.Encryption("exist", KDCp, KDCq, KDCd);
                        sendMessage(aes.AesEncipher("2|" + backMsg), regClient.ClientIP, regClient.ClientPort);
                    }

                }



                //获取证书
                if ("3" == recStrArr[0])
                {

                    //解密出请求报文
                    string cer = rsaDeByKd(recStrArr[3]);
                    string[] cerArr = cer.Split('c');
                    string username = cerArr[0];
                    string cerKe = cerArr[1];
                    string cerTick = cerArr[2];

                    this.txtComInfo.AppendText("\r\n处理来自" + username + "的获取会话证书请求。");
                    this.txtComInfo.AppendText("\r\n用户名：" + username);
                    this.txtComInfo.AppendText("\r\n用户公钥：" + cerKe);
                    this.txtComInfo.AppendText("\r\n时间戳：" + cerTick);


                    CerClient cerClient = new CerClient(username, cerKe, cerTick);

                    //检测该用户是否已经取得证书
                    //标志
                    int flag = 0;
                    for (int i = 0; i < cerClients.Count; i++)
                    {
                        if (cerClient.Username == ((CerClient)cerClients[i]).Username)
                        {
                            flag = 1;
                        }
                    }

                    

                    //用户未取得证书
                    if (0 == flag)
                    {
                        //KDC-->A:  Dp(CA,KdKDC)
                        backMsg = rsaEnByKd(username + "c" + cerKe);
                        sendMessage(aes.AesEncipher("3|" + backMsg), cerClient.ClientIP, cerClient.ClientPort);
                        cerClients.Add(cerClient);


                        //广播当前获得证书的用户
                        Thread th = new Thread(broadcastCerClients);
                        th.Start();

                        this.lbxCerClient.Items.Clear();
                        //页面显示
                        for (int i = 0; i < cerClients.Count; i++)
                        {
                            this.lbxCerClient.Items.Add(cerClients[i]);
                        }


                    }

                    if (1 == flag)
                    {
                        //用户已经取得证书
                        backMsg = rsa.Encryption("exist", KDCp, KDCq, KDCd);
                        sendMessage(aes.AesEncipher("3|" + backMsg), cerClient.ClientIP, cerClient.ClientPort);
                    }

                }

                //申请会话
                if ("5" == recStrArr[0])
                {
                    string str = rsaDeByKd(recStrArr[1]);
                    string username1 = str.Split('c')[0];
                    string username2 = str.Split('c')[1];
                    CerClient c1 = null;
                    CerClient c2 = null;

                    for (int i = 0; i < cerClients.Count; i++)
                    {
                        if (username1 == ((CerClient)cerClients[i]).Username)
                        {
                            c1 = (CerClient)cerClients[i];
                            break;
                        }
                    }

                    for (int i = 0; i < cerClients.Count; i++)
                    {
                        if (username2 == ((CerClient)cerClients[i]).Username)
                        {
                            c2 = (CerClient)cerClients[i];
                            break;
                        }
                    }

                    ComClientGroup comClientGroup = new ComClientGroup(c1, c2);


                    this.txtComInfo.AppendText("\r\n处理来自" + username1 + "的会话请求。");
                    this.txtComInfo.AppendText("\r\n<--"+comClientGroup.ToString()+"-->");
                    if (isExistComClientGroup(comClientGroup))
                    {
                        //通信组已近存在
                        //MessageBox.Show("存在");

                        backMsg = rsa.Encryption("exist", KDCp, KDCq, KDCd);
                        sendMessage(aes.AesEncipher("5|" + backMsg), c1.ClientIP, c1.ClientPort);
                    }
                    else
                    {
                        //尚未存在
                        this.comClientGroups.Add(comClientGroup);

                        //this.txtComInfo.AppendText("\r\n--------\r\n" + createStrSendRN(comClientGroup)[0]);
                        string str1 = rsaEnByKd(createStrSendRN(comClientGroup)[0]);
                        string str2 = rsaEnByKd(createStrSendRN(comClientGroup)[1]);

                        //this.txtComInfo.AppendText("\r\n--------\r\n" + str1);
                        //this.txtComInfo.AppendText("\r\n--------\r\n" + str2);


                        sendMessage(aes.AesEncipher("5|" + str1), c1.ClientIP, c1.ClientPort);
                        sendMessage(aes.AesEncipher("5|" + str2), c2.ClientIP, c2.ClientPort);


                        //页面显示
                        this.lbxComClient.Items.Clear();
                        for (int i = 0; i < comClientGroups.Count; i++)
                        {
                            this.lbxComClient.Items.Add((ComClientGroup)comClientGroups[i]);
                        }
                    }
                }


                //取消会话
                if ("6" == recStrArr[0])
                {
                    this.txtComInfo.AppendText("\r\n取消通信组：" + recStrArr[1]);
                    int i = 0;
                    for (i = 0; i < comClientGroups.Count; i++)
                    {
                        if (((ComClientGroup)comClientGroups[i]).ToString() == recStrArr[1])
                        {
                            break;
                        }
                    }

                    if (i >= comClientGroups.Count)
                    {
                        //已经取消通信
                    }
                    else
                    {
                        //移除该通信组
                        CerClient c1 = ((ComClientGroup)comClientGroups[i]).CerClient1;
                        CerClient c2 = ((ComClientGroup)comClientGroups[i]).CerClient2;
                        //发送通知
                        sendMessage(aes.AesEncipher("6|" + c2.Username), c1.ClientIP, c1.ClientPort);
                        sendMessage(aes.AesEncipher("6|" + c1.Username), c2.ClientIP, c2.ClientPort);



                        //刷新界面
                        comClientGroups.RemoveAt(i);
                        //页面显示
                        this.lbxComClient.Items.Clear();
                        for (int j = 0; j < comClientGroups.Count; j++)
                        {
                            this.lbxComClient.Items.Add((ComClientGroup)comClientGroups[j]);
                        }


                    }
                }


                //转发通信消息
                if ("7" == recStrArr[0])
                {
                    //this.txtComInfo.AppendText("\r\n收到转发通信消息报文：" + recStr);

                    //构造比较字符串
                    string str1 = null;

                    string username1 = recStrArr[1];   //源地址
                    string username2 = recStrArr[2];   //目的地址


                    //目的地址
                    CerClient cd = new CerClient(username2, "", "");
                    //源地址
                    CerClient cs = new CerClient(username1, "", "");


                    if (username1.CompareTo(username2) > 0)
                    {
                        str1 = username1 + "," + username2;
                    }
                    else
                    {
                        str1 = username2 + "," + username1;
                    }


                    int i = 0;
                    for (i = 0; i < comClientGroups.Count; i++)
                    {
                        if (((ComClientGroup)comClientGroups[i]).ToString() == str1)
                        {
                            break;
                        }
                    }

                    if (i >= comClientGroups.Count)
                    {
                        //不存在此通信组，返回消息发送失败                        
                    }
                    else
                    {

                        //向目的地址发送消息报文

                        ComClientGroup comClientGroup = ((ComClientGroup)comClientGroups[i]);

                        string repMsg = "7|" + cs.Username + "|" + recStrArr[3];
                        sendMessage(aes.AesEncipher(repMsg), cd.ClientIP, cd.ClientPort);
                        //this.txtComInfo.AppendText("\r\n转发消息报文：" + repMsg);
                        this.txtComInfo.AppendText("\r\n转发" + cs.Username + "---->" + cd.Username + " 消息报文：" + new AES(comClientGroup.Kaes).AesDecipher(recStrArr[3]).Trim());
                    }

                }



                //客户端断开消息
                if ("8" == recStrArr[0])
                {


                    this.txtComInfo.AppendText("\r\n--------断开用户：" + recStr);
                    string username = recStrArr[1];

                 
                        //去除regClients中的该用户
                        int i = 0;
                        for (i = 0; i < regClients.Count; i++)
                        {
                            if (((RegClient)regClients[i]).Username == username)
                            {
                                regClients.RemoveAt(i);
                                break;
                            }
                        }
                        
                    


                   
                        //去除取得证书的用户列表中的该用户
                         i = 0;
                        for (i = 0; i < cerClients.Count; i++)
                        {
                            if (((CerClient)cerClients[i]).Username == username)
                            {
                                cerClients.RemoveAt(i);
                                break;
                            }
                        }
                        

                    



                    //证书获得者页面刷新
                    this.lbxCerClient.Items.Clear();
                    for (int x = 0; x < cerClients.Count; x++)
                    {
                        this.lbxCerClient.Items.Add(cerClients[x]);
                    }








                    if (comClientGroups.Count != 0)
                    {
                        ArrayList comClientGroupsTemp = new ArrayList();
                        i = 0;
                        for (i = 0; i < comClientGroups.Count; i++)
                        {
                            comClientGroupsTemp.Add(comClientGroups[i]);
                        }
                        //ArrayList comClientGroupsTemp = comClientGroups;
                        //去除通信组中的该用户
                        i = 0;
                        for (i = 0; i < comClientGroupsTemp.Count; i++)
                        {
                            ComClientGroup ccg = (ComClientGroup)comClientGroupsTemp[i];

                            if ((ccg.CerClient1.Username == username || ccg.CerClient2.Username == username))
                            {
                                comClientGroups.Remove(ccg);
                                //comClientGroups.Remove();
                            }
                        }


                        //刷新页面


                        //通信组显示
                        this.lbxComClient.Items.Clear();
                        for (int j = 0; j < comClientGroups.Count; j++)
                        {
                            this.lbxComClient.Items.Add((ComClientGroup)comClientGroups[j]);
                        }
                    }




                    //广播用户断开消息

                    string rep = "8|" + rsa.Encryption(username, KDCp, KDCq, KDCd);

                    for (i = 0; i < cerClients.Count; i++)
                    {
                        sendMessage(aes.AesEncipher(rep), ((CerClient)cerClients[i]).ClientIP, ((CerClient)cerClients[i]).ClientPort);
                    }






                }




                //测试
                //sendMessage("connect",IPAddress.Parse("127.0.0.1") ,int.Parse("1000"));
            }
        }
        

        //构造发送RN的报文
        /// <summary>
        /// 产生一个随机数RN，并将RN和CA，CB一起发给A和B。
        ///KDCA: Dp(Ep(<CA,CB,RN,T1>，KeA),KdKDC)
        ///KDCB: Dp(Ep(<CA,CB,RN,T1>，KeB),KdKDC)
        /// </summary>
        /// <param name="comClientGroup"></param>
        /// <returns></returns>
        private string[] createStrSendRN(ComClientGroup comClientGroup)
        {
            //str=username1+"c"+username2+"c"+RN+"c"+ticks;
            string[] rsaStr = new string[2];
            string str = comClientGroup.CerClient1.Username + "c" + comClientGroup.CerClient2.Username + "c" + comClientGroup.Rn +"c"+ TimeUtil.getTicks();
            rsaStr[0] = this.rsaEnByKe(str,comClientGroup.CerClient1).Replace('$', 'd');
            rsaStr[1] = this.rsaEnByKe(str, comClientGroup.CerClient2).Replace('$', 'd');
            return rsaStr;
        }


        


        //检测该通信组是否已近存在
        private bool isExistComClientGroup(ComClientGroup comClientGroup)
        {
            for (int i = 0; i < comClientGroups.Count; i++) {
                if (((ComClientGroup)comClientGroups[i]).ToString()==comClientGroup.ToString()){
                    return true;
                }
            }
            return false;
        }

        //广播当前获得证书的用户
        private void broadcastCerClients() {
            StringBuilder sb = new StringBuilder();
            sb.Append("4");
            for (int i = 0; i < cerClients.Count; i++) {
                sb.Append("|"+((CerClient)cerClients[i]).Username);
            }
            for (int i = 0; i < cerClients.Count; i++) {
                sendMessage(aes.AesEncipher(sb.ToString()), ((CerClient)cerClients[i]).ClientIP, ((CerClient)cerClients[i]).ClientPort);
            }
        }

        //client 公钥 分组加密
        //KDC 私钥分组加密
        private string rsaEnByKe(string cer,CerClient cerClient)
        {

            int cerLength = cer.Length; //字符串长度
            int groupNum = cerLength / 15; //组数
            int lastNum = cerLength % 15; //最后一组的长度
            string clientE=cerClient.ClientKe.Split('a')[0];
            string clientN=cerClient.ClientKe.Split('a')[1];

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < groupNum; i++)
            {
                sb.Append(rsa.Encryption(cer.Substring(i * 15, 15),clientE,clientN));
                sb.Append('$');
            }
            sb.Append(rsa.Encryption(cer.Substring(groupNum * 15, lastNum), clientE, clientN));

            return sb.ToString();

        }



        //KDC 私钥分组加密
        private string rsaEnByKd(string cer)
        {

            int cerLength = cer.Length; //字符串长度
            int groupNum = cerLength / 15; //组数
            int lastNum = cerLength % 15; //最后一组的长度

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < groupNum; i++)
            {
                sb.Append(rsa.Encryption(cer.Substring(i * 15, 15), KDCp, KDCq,KDCd));
                sb.Append('$');
            }
            sb.Append(rsa.Encryption(cer.Substring(groupNum * 15, lastNum), KDCp, KDCq, KDCd));

            return sb.ToString();

        }



        //KDC私钥分组解密
        private string rsaDeByKd(string cer)
        {
            string[] cerArr = cer.Split('$');
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cerArr.Length; i++)
            {
                sb.Append(rsa.Decryption(cerArr[i], KDCp,KDCq, KDCd));
            }
            return sb.ToString();
        }


        //主机UdpClient
        private UdpClient myUdpClient = new UdpClient();
        /// <summary>
        /// UdpClient发送消息
        /// </summary>
        /// <param name="sendMsg"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        private void sendMessage(string sendMsg, IPAddress ip, int port)
        {
            //服务器节点
            IPAddress desIP = ip;
            int desPort = port;
            IPEndPoint iep = new IPEndPoint(desIP, desPort);

            //将发送内容转换为字节数组
            byte[] bytes = Encoding.UTF8.GetBytes(sendMsg);
            //向目的节点发送信息
            myUdpClient.Send(bytes, bytes.Length, iep);
        }



        private void init()
        {
            //读取服务器IP和PORT
            HostInfo hostInfo = new HostInfo();
            serverIP = hostInfo.getHostIP();

            //从配置文件中读取 服务器参数
            serverPort = XmlHelper.Read("serverPort"); //"10000";
            
            //读取KDC 密钥组
            KDCaes = XmlHelper.Read("KDCaes");//"00012001710198aeda7917146015359400012001710198aeda79171460153590";
            KDCe = XmlHelper.Read("KDCe");//"70589";
            KDCn = XmlHelper.Read("KDCn"); //"60367956303360727219487695955228829513663797";
            KDCp = XmlHelper.Read("KDCp"); //"8638626483950309547643";
            KDCq = XmlHelper.Read("KDCq"); //"6988142896966115800079";
            KDCd = XmlHelper.Read("KDCd"); //"44747665296534115670028709120122203238933125";


            

            //初始化加密对象
            rsa = new RSA();
            aes = new AES(KDCaes);




            //页面显示
            //显示服务器服务IP 和 PORT
            this.txtServerIP.Text = serverIP;
            this.txtServerPort.Text = serverPort;


            //显示读取服务器KDC公钥 私钥 AES密钥
            this.txtKekdc.Text = KDCe + "a" + KDCn;
            this.txtKaes.Text="00012001710198aeda7917146015359400012001710198aeda79171460153590";
            this.txtServerKd.Text = KDCp + "a" + KDCq + "a" + KDCd;


        }

        private void beginService() {

            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            //将线程设为后台运行
            receiveThread.IsBackground = true;
            receiveThread.Start();
            this.txtComInfo.AppendText("\r\n"+"端口" + serverPort + "开始监听连接。。。" );
            this.txtComInfo.AppendText("\r\n服务器启动服务。。。"+TimeUtil.getNowTime());
        }



        //服务器关闭 通知所有client 
        private void chatServer_FormClosing(object sender, FormClosingEventArgs e)
        {

            //使用户确定是否退出
            DialogResult result = MessageBox.Show("确定要退出系统并保存服务内容吗？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }


            this.txtComInfo.AppendText("\r\n服务器停止服务。。。"+TimeUtil.getNowTime());

            //广播服务器断开消息
            if (cerClients.Count > 0)
            {

                string rep = "9|" + rsa.Encryption("disconnect", KDCp, KDCq, KDCd);
                int i = 0;
                for (i = 0; i < cerClients.Count; i++)
                {
                    sendMessage(aes.AesEncipher(rep), ((CerClient)cerClients[i]).ClientIP, ((CerClient)cerClients[i]).ClientPort);
                }
            }

            //保存通信内容
            if (this.txtComInfo.Text != string.Empty)
            {
                StreamWriter sw = new StreamWriter("serverServiceRecord.txt", true, System.Text.Encoding.Default);
                sw.Write("\r\n-----------------------------------华丽的分割线--------------------------------\r\n");
                sw.Write(this.txtComInfo.Text);
                sw.Close();
            }



        }


        //关闭窗体，停止服务
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //显示历史记录
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "serverServiceRecord.txt";
                p.Start();
            }
            catch
            {
                MessageBox.Show("文件暂时不能打开！请检查此文件的位置是否正确！", "无法打开",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
