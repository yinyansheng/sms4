using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace chatClient
{
    public partial class chatClientForm : Form
    {
        public chatClientForm()
        {
            InitializeComponent();
        }

        private RSA rsa;
        private AES aes;

        //密钥参数
        private string hostIP;
        private string hostPort;
        private string serverIP;
        private string serverPort;
        private string KDCe;
        private string KDCn;
        private string KDCaes;
        private string USERe;
        private string USERn;
        private string USERp;
        private string USERq;
        private string USERd;

         private void btnGetUserKey_Click(object sender, EventArgs ea)
        {

            GetBigPrimeNumber g = new GetBigPrimeNumber();
            
            this.txtRegInfo.AppendText("\r\n" +"正在计算，等一会吧......");
           // RSA rsa = new RSA();

            //RSA参数
            string p = g.GetPrime(20, 20);          //"400102763711414967770767037524228944827744999";
            string q = g.GetPrime(20, 20);          //"8309800040778730784806157814715597859931006281171";
            string n = string.Empty; ;
            string e = string.Empty;                //"65537";
            string faiN = string.Empty; ;
            string d = string.Empty; ;

            //用户密钥
            string userPubKey = string.Empty;
            string userPriKey = string.Empty;




            this.txtRegInfo.AppendText("\r\n" +"p=" + p);
            this.txtRegInfo.AppendText("\r\n" +"q=" + q);
            n = rsa.GetN(p, q);
            this.txtRegInfo.AppendText("\r\n" +"n=" + n);
            faiN = rsa.GetFaiN(p, q);
            this.txtRegInfo.AppendText("\r\n" +"faiN=" + faiN);
            e = rsa.GetE(faiN);
            this.txtRegInfo.AppendText("\r\n" +"e=" + e);
            d = rsa.GetD(faiN, e);
            this.txtRegInfo.AppendText("\r\n" +"d=" + d);

            USERe = e;
            USERn = n;
            USERp = p;
            USERq = q;
            USERd = d;



             //修改配置文件
            XmlHelper.Update("USERe", USERe);
            XmlHelper.Update("USERn", USERn);
            XmlHelper.Update("USERp", USERp);
            XmlHelper.Update("USERq", USERq);
            XmlHelper.Update("USERd", USERd);


            userPubKey = e + "a" + n;
            userPriKey = p + "a" + q + "a" + d;

            this.txtUserKd.Clear();
            this.txtUserKe.Clear();
            this.txtUserKd.AppendText(userPriKey);
            this.txtUserKe.AppendText(userPubKey);




            //测试

            TimeSpan ts1 = TimeUtil.getNowTimeTicks();
            string c = rsa.Encryption("37a4ed502e3e696", p, q, d);
            this.txtRegInfo.AppendText("\r\n" +"密文：" + c);


            string p1 = rsa.Decryption(c, e, n);
            this.txtRegInfo.AppendText("\r\n" +"明文：" + p1);

            TimeSpan ts2 = TimeUtil.getNowTimeTicks();
            String spanTime = TimeUtil.getSpanTime(ts1, ts2);
            this.txtRegInfo.AppendText("\r\n" +spanTime);

        }



         




        //初始化方法 
        private void init() 
        {

            //初始化参数
            //获取本机IP
            HostInfo hostInfo = new HostInfo();
            hostIP=hostInfo.getHostIP();



            //从配置文件读取参数

            //获取KDC 公钥 及 AES密钥
            KDCe = XmlHelper.Read("KDCe");   //"70589";
            KDCn = XmlHelper.Read("KDCn");//"60367956303360727219487695955228829513663797";
            KDCaes = XmlHelper.Read("KDCaes"); //"00012001710198aeda7917146015359400012001710198aeda79171460153590";

            //获取USER Ke Kd
            USERe = XmlHelper.Read("USERe");//"70589";
            USERn = XmlHelper.Read("USERn");//"60367956303360727219487695955228829513663797";
            USERp = XmlHelper.Read("USERp");//"8638626483950309547643";
            USERq = XmlHelper.Read("USERq");//"6988142896966115800079";
            USERd = XmlHelper.Read("USERd");//"44747665296534115670028709120122203238933125";

            //获取服务器IP 及 PORT
            serverIP = XmlHelper.Read("serverIP"); //"127.0.0.1";
            serverPort = XmlHelper.Read("serverPort");//"10000";

            //初始化加密对象
            rsa = new RSA();
            aes = new AES(KDCaes);

            //页面显示
            //显示本机IP
            this.txtHostIP.Text = hostIP;
            this.txtConInfo.AppendText("\r\n获取本机IP:  "+hostIP);

            //显示KDC 公钥 及 AES密钥
            this.txtKekdc.Text=KDCe+"a"+KDCn;
            this.txtKaes.Text=KDCaes;


            //显示USER Ke Kd
            this.txtUserKe.Text = USERe + "a" + USERn;
            this.txtUserKd.Text = USERp + "a" + USERq + "a" + USERd;
            

            //显示服务器IP 及 PORT
            this.txtServerIP.Text = serverIP;
            this.txtServerPort.Text = serverPort;

            //初始化界面按钮可用性
            this.btnConnect.Enabled = false;
            this.btnRegistration.Enabled = false;
            this.btnGetCertificate.Enabled = false;


            
        }

        private void txtHostPort_MouseDown(object sender, MouseEventArgs e)
        {
            hostPortForm c = new hostPortForm();
            c.Show(this);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {

               
                //this.btnConnect.Enabled = false;
                this.txtConInfo.AppendText("\r\n服务器监听节点：" + serverIP + ":" + serverPort);
                this.txtConInfo.AppendText("\r\n本机监听节点：" +hostIP+":"+hostPort);
                //连接服务器



                IPAddress ipa = IPAddress.Parse(serverIP);
                int port = int.Parse(serverPort);


                //AES aes = new AES(KDCaes);
                //构造测试连接服务器报文 例如："1|127.0.0.1:1000|connect"
                string connectString =aes.AesEncipher("1|" + hostIP + "|" + hostPort + "|connect");
                sendMessage(connectString, ipa, port);

                
                
               
            }
            else { 
                //没通过验证
            }
        }


        //取得证书的用户数组
        private ArrayList cerClients = new ArrayList();
        //当前可通信用户
        private ArrayList comClients = new ArrayList();
        private void ReceiveData()
        {

            UdpClient udpClient = new UdpClient(int.Parse(hostPort));
            //远程主机节点
            IPEndPoint remote = null;
           // RSA rsa = new RSA();
           // AES aes = new AES(KDCaes);

            //接收从远程主机发送过来的信息
            while (true)
            {
                //关闭udpClient时此句会产生异常
                byte[] bytes = udpClient.Receive(ref remote);
                string recStr = aes.AesDecipher(Encoding.UTF8.GetString(bytes, 0, bytes.Length)).Trim();
           
               
                

                string[] recStrArr=recStr.Split('|');
                if ("1" == recStrArr[0]) {
                    //this.txtConInfo.AppendText("\r\n" + string.Format("来自{0}：{1}", remote, recStr));
                    if ("CONNECT" == recStrArr[1])
                    {
                        this.txtConInfo.AppendText("\r\n"+hostIP+":"+hostPort + " 服务器连接成功");
                        this.btnRegistration.Enabled = true;
                        //this.btnConnect.Enabled = false;
                    }
                    else { 
                        //服务器连接失败
                    }
                }

                if ("2" == recStrArr[0])
                {
                    this.txtRegInfo.AppendText("\r\n" + string.Format("来自{0}：{1}", remote, recStr));
                    string username = hostIP.Replace('.', 'a') + "b" + hostPort;
                    
                    string str=rsa.Decryption(recStrArr[1],KDCe,KDCn);
                    if ("exist" == str)
                    {
                        this.txtRegInfo.AppendText("\r\n"+username + "用户已经注册成功。。。");
                        
                    }
                    else if (username ==str)
                    {
                        this.txtRegInfo.AppendText("\r\n" + "注册成功。。。");
                        this.btnGetCertificate.Enabled = true;
                    }
                    else{ 
                        //注册失败
                    }
                }

                if ("3" == recStrArr[0]) {
                    this.txtRegInfo.AppendText("\r\n" + string.Format("来自{0}：{1}", remote, recStr));
                    string username = hostIP.Replace('.', 'a') + "b" + hostPort;
                    string  userKe = USERe + "a" + USERn;
                    string message = string.Empty;
                    string str = rsaDeByKe(recStrArr[1]);
                   // this.txtRegInfo.AppendText("\r\n----------" + str.Split('c')[0]+"|");
                   // this.txtRegInfo.AppendText("\r\n----------" + str.Split('c')[1]+"|");
                    if ("exist" == str)
                    {
                        message = "\r\n用户：" + username + " 已经取得证书。。。";
                    }
                    else if(username == str.Split('c')[0]&&userKe == str.Split('c')[1])
                    {
                        //获得证书成功
                        message ="\r\n从服务器取得证书：< " +username+" , "+userKe+" >";
                        this.btnGetUserKey.Enabled = false;
                    }

                    if (message != string.Empty)
                    {
                        this.txtRegInfo.AppendText(message);
                    }
                }


                //广播取得证书用户
                if ("4" == recStrArr[0]) {
                    

                    //刷新当前用户数组
                    this.cerClients.Clear();
                    for (int i = 1; i < recStrArr.Length; i++)
                    {
                        this.cerClients.Add(recStrArr[i]);
                    } 

                    //页面显示当前所有取得证书的用户
                    this.lbxOnlineClient.Items.Clear();
                    try
                    {
                        this.lbxOnlineClient.BeginUpdate();
                        for (int i = 0; i < cerClients.Count; i++)
                        {
                            this.lbxOnlineClient.Items.Add(cerClients[i].ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    finally {
                        this.lbxOnlineClient.EndUpdate();
                    }
                    //Thread.Sleep(200);
                    //this.txtComStatus.AppendText("刷新在线用户。。。\r\n");
                }

                //会话请求返回报文
                if ("5" == recStrArr[0])
                {
                    string str = rsaDeByKe(recStrArr[1]);
                    string message = string.Empty;


                    //this.txtInput.AppendText("\r\n" + str);
                    if ("exist" == str)
                    {
                        message = "\r\n用户：此通信组已经取得会话密钥。。。";
                    }
                    else {
                       //获得通信组
                        string strRN=rsaDeByKd(str.Replace('d','$'));

                        string hostUsername = hostIP.Replace('.', 'a') + "b" + hostPort;
                        string comUsername=null;
                        string rn = null;
                        string ticks = null;


                        string[] msg = strRN.Split('c');

                        if (msg[0] != hostUsername)
                        {
                            comUsername = msg[0];
                        }
                        else {
                            comUsername = msg[1];
                        }

                        rn = msg[2];

                        ticks = msg[3];

                        ComClient comClient = new ComClient(comUsername, rn, ticks);

                        comClients.Add(comClient);

                        //页面显示
                        this.lbxComClient.Items.Clear();
                        for (int i = 0; i < comClients.Count; i++) {
                            this.lbxComClient.Items.Add(((ComClient)comClients[i]));
                        }





                            message = "\r\n服务器返回报文：" + strRN;
                        
                    }


                    if (message != string.Empty)
                    {
                        this.txtComStatus.AppendText(message);
                    }

                }

                 //会话取消返回报文
                if ("6" == recStrArr[0]) {

                    this.txtComStatus.AppendText("\r\n取消会话：" + recStrArr[1]);
                    int i = 0;

                    int len = comClients.Count;
                    if (comClients.Count != 0)
                    {

                        for (i = 0; i < len; i++)
                        {
                            if (recStrArr[1] == ((ComClient)comClients[i]).Username)
                            {
                                //删除此会话
                                comClients.RemoveAt(i);
                                break;
                            }
                        }

                        if (i >= len)
                        {
                            //已经没有此会话了
                        }
                        else
                        {
                            
                            //页面显示
                            this.lbxComClient.Items.Clear();
                            for (int j = 0; j < comClients.Count; j++)
                            {
                                this.lbxComClient.Items.Add(((ComClient)comClients[j]));
                            }
                        }
                    }
                }



                //接受通信消息
                if ("7" == recStrArr[0])
                {
                    //源地址 用户名
                    //string username = recStrArr[1];
                    //主机名称
                    string username = hostIP.Replace('.', 'a') + "b" + hostPort;

                    int i = 0;
                    for (i = 0; i < comClients.Count; i++)
                    {
                        if (recStrArr[1] == ((ComClient)comClients[i]).Username)
                        {
                            break;
                        }
                    }

                    if (i >= comClients.Count)
                    {
                        //已经没有此会话了
                    }
                    else
                    {
                        this.txtShowMessage.AppendText("\r\n" + recStrArr[1] + "—>" +username+"  "+TimeUtil.getNowTime() + "\r\n    " + new AES(((ComClient)comClients[i]).Kaes).AesDecipher(recStrArr[2]).Trim());
                    }

                  //  this.txtShowMessage.AppendText("\r\n" +recStrArr[1]+" "+TimeUtil.getNowTime()+"\r\n       "+recStrArr[2]);


                }


                //用户断开消息
                if ("8" == recStrArr[0]) {
                    string username = rsa.Decryption(recStrArr[1], KDCe, KDCn);

                   // this.txtComStatus.AppendText("\r\n-----断开：" + username);

                  
                        int i = 0;
                        for (i = 0; i < cerClients.Count; i++)
                        {
                            if (cerClients[i].ToString() == username)
                            {
                                cerClients.RemoveAt(i);
                                break;
                            }
                        }
                        
                    


                    

                        i = 0;
                        for (i = 0; i < comClients.Count; i++)
                        {
                            if (((ComClient)comClients[i]).Username == username)
                            {
                                comClients.RemoveAt(i);
                                break;
                            }
                        }
                        
                    
                   


                    //页面显示
                        this.lbxComClient.Items.Clear();
                        for (int j = 0; j < comClients.Count; j++)
                        {
                            this.lbxComClient.Items.Add(((ComClient)comClients[j]));
                        }


                        this.lbxOnlineClient.Items.Clear();
                        for (i = 0; i < cerClients.Count; i++)
                        {
                            this.lbxOnlineClient.Items.Add(cerClients[i].ToString());
                        }
                    



                        this.txtComStatus.AppendText("\r\n----" + username + "断开连接");
                }



                if ("9" == recStrArr[0])
                {
                    string command = rsa.Decryption(recStrArr[1], KDCe, KDCn);

                    if ("disconnect" == command) { 
                        //服务器断开 清空所有用户

                        cerClients.Clear();
                        comClients.Clear();

                        this.lbxComClient.Items.Clear();
                        this.lbxOnlineClient.Items.Clear();

                        this.txtComStatus.AppendText("\r\n服务器断开。。。。");
                    }
                }


            }
        }

        private void beginService()
        {

            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            //将线程设为后台运行
            receiveThread.IsBackground = true;
            receiveThread.Start();
            this.txtConInfo.AppendText("\r\n" + "端口" + hostPort  + "开始监听连接。。。");
        }

        //主机UdpClient
        private UdpClient myUdpClient = new UdpClient();
        private void sendMessage(string sendMsg, IPAddress ip, int port) {
            //服务器节点
            IPAddress desIP = ip;
            int desPort = port;
            IPEndPoint iep = new IPEndPoint(desIP, desPort);

            //将发送内容转换为字节数组
            byte[] bytes = Encoding.UTF8.GetBytes(sendMsg);
            //向目的节点发送信息
            myUdpClient.Send(bytes, bytes.Length, iep);
        }

        private bool checkInput() {
            TextCheck tc = new TextCheck();

            if (!tc.checkInputIP(this.txtServerIP.Text))
            {
                MessageBox.Show("Server IP：" + tc.WarningMessage);
                this.txtServerIP.Clear();
                this.txtServerIP.Focus();
                return false;
            }

            if (!tc.checkInputPort(this.txtServerPort.Text))
            {
                MessageBox.Show("Server port：" + tc.WarningMessage);
                this.txtServerPort.Clear();
                this.txtServerPort.Focus();
                return false;
            }

            if (!tc.checkInputPort(this.txtHostPort.Text)) 
            {
                MessageBox.Show("Host port：" + tc.WarningMessage);
                this.txtHostPort.Clear();
                this.txtHostPort.Focus();
                return false;
            }
            return true;
        }

      


        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chatClientForm_Load(object sender, EventArgs e)
        {
            //数据初始化
            this.init();
        }

        //用户注册
        private void btnRegistration_Click(object sender, EventArgs e)
        {

           // AES aes = new AES(KDCaes);
            //获取用户名 例如"127a0a0a1b1000"
            string username = hostIP.Replace('.', 'a') + "b" + hostPort;

            this.txtRegInfo.AppendText("\r\n此次会话用户名：" + username);


            RSA rsa = new RSA();
            //构造注册报文

            string regString = "2|" + hostIP + "|" + hostPort + "|" + rsa.Encryption(username, KDCe, KDCn);

            //发送报文
            sendMessage(aes.AesEncipher(regString), IPAddress.Parse(serverIP), int.Parse(serverPort));



            this.txtRegInfo.AppendText("\r\n发送注册报文：" + regString);

        }


        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                hostPort = this.txtHostPort.Text;
                //开启监听
                try
                {
                    beginService();
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.ToString());
                    this.Close();
                }

                
                this.btnMonitor.Enabled = false;
                this.btnConnect.Enabled = true;
            }
        }


        /// <summary>
        /// 获取证书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetCertificate_Click(object sender, EventArgs e)
        {
            string cer = createCerString();
            
            //发送给服务器
            sendMessage(aes.AesEncipher(cer), IPAddress.Parse(serverIP), int.Parse(serverPort));
            //页面显示
            this.txtRegInfo.AppendText("\r\n发送请求获取证书报文：\r\n" + cer);
        }

        //构造获取证书的报文
        private string createCerString() { 


            // 获取用户名 例如"127a0a0a1b1000"
            string username = hostIP.Replace('.', 'a') + "b" + hostPort;
            
            //获取当前时间戳
           
            string timeTicks = TimeUtil.getTicks();
            //证书明文
            string cer=username + "c" + USERe + "a" + USERn + "c" + timeTicks;


            string cerString = "3|" + hostIP + "|" + hostPort + "|" + rsaEnByKe(cer);

            //返回证书密文Ep(<A,KeA,T0>,KeKDC)

            return cerString;



        }



        //用自己的Kd分组解密
        private string rsaDeByKd(string cer)
        {
            string[] cerArr = cer.Split('$');
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cerArr.Length; i++)
            {
                sb.Append(rsa.Decryption(cerArr[i], USERp, USERq, USERd));
            }
            return sb.ToString();
        }

        //用KDC公钥分组加密

        private string rsaEnByKe(string cer) {

            int cerLength = cer.Length; //字符串长度
            int groupNum = cerLength / 15; //组数
            int lastNum = cerLength % 15; //最后一组的长度

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < groupNum; i++) {
                sb.Append(rsa.Encryption(cer.Substring(i * 15, 15), KDCe, KDCn));
                sb.Append('$');
            }
            sb.Append(rsa.Encryption(cer.Substring(groupNum * 15, lastNum), KDCe, KDCn));

            return sb.ToString();  

        }

        //用KDC公钥分组解密
        private string rsaDeByKe(string cer) {
            string[] cerArr = cer.Split('$');
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cerArr.Length; i++) {
                sb.Append(rsa.Decryption(cerArr[i], KDCe, KDCn));
            }
            return sb.ToString();
        }


        //申请会话
        private void btnAddCom_Click(object sender, EventArgs e)
        {
            //检查是否选择了有证书用户
            if (-1 == this.lbxOnlineClient.SelectedIndex) {
                MessageBox.Show("    请选择需要添加的用户！    ");
                return;
            }
            //检测是否选择了自己
            string username = hostIP.Replace('.', 'a') + "b" + hostPort;
            if (username == this.lbxOnlineClient.SelectedItem.ToString()) {
                MessageBox.Show("  不能选择自己作为通信用户！  ");
                return;
            }

            //选择正确，发送会话请求

            string str = username + "c" + lbxOnlineClient.SelectedItem.ToString();

            //构造请求会话报文
            string reqMsg = "5|" + rsaEnByKe(str);

            sendMessage(aes.AesEncipher(reqMsg), IPAddress.Parse(serverIP), int.Parse(serverPort));

            this.txtComStatus.AppendText("\r\n发送申请会话报文：" + reqMsg);
            //MessageBox.Show(str);
        }


        //取消通信组
        private void btnDelCom_Click(object sender, EventArgs e)
        {
            //检查是否选择了有证书用户
            if (-1 == this.lbxComClient.SelectedIndex) {
                MessageBox.Show("    请选择需要取消的用户！    ");
                return;
            }

            string reqMsg=null;
            string username = hostIP.Replace('.', 'a') + "b" + hostPort;
            ////选择正确，发送取消请求
            if (username.CompareTo(this.lbxComClient.SelectedItem.ToString()) > 0)
            {
                reqMsg = "6|" + username + "," + this.lbxComClient.SelectedItem.ToString();
            }
            else {
                 reqMsg = "6|" + this.lbxComClient.SelectedItem.ToString() + "," + username;
            }

            //发送报文
            sendMessage(aes.AesEncipher(reqMsg), IPAddress.Parse(serverIP), int.Parse(serverPort));

            this.txtComStatus.AppendText("\r\n发送取消会话报文：" + reqMsg);
        }

        //单击发送按钮，开始通信
        private void btnSend_Click(object sender, EventArgs e)
        {
            //开始检查是否选中了通信对象
            if (-1 == this.lbxComClient.SelectedIndex)
            {
                MessageBox.Show("    请选择需要通信的用户！    ");
                return;
            }


            //检测是否在文本框中输入了内容
            if (string.Empty == this.txtInput.Text) {
                MessageBox.Show("      不能发送空消息！      ");
                return;
            }


            //开始检查是否选中了通信对象
            if (this.txtInput.Text.Length>100)
            {
                MessageBox.Show("    输入的文本不要大于100个字符！    ");
                return;
            }


            //发送通信报文




            string reqMsg = null;

           //目的地址用户名
            //源地址用户名
            string username1 = hostIP.Replace('.', 'a') + "b" + hostPort;
            string username2 = this.lbxComClient.SelectedItem.ToString();
            //找出comClient
            int i=0;
            ComClient c=null;
            for(i=0;i<comClients.Count;i++){
                if(username2==((ComClient)comClients[i]).Username)
                {
                    c=(ComClient)comClients[i];
                    break;
                }
            }

            if(i>=comClients.Count){
                  MessageBox.Show("      通信对象已经不存在！      ");
                return;
            }else{

                 //通信内容
                string msg = new AES(c.Kaes).AesEncipher(this.txtInput.Text);
                //构造报文

                reqMsg = "7|" + username1 + "|" + username2 + "|" + msg;

                //发送报文
                sendMessage(aes.AesEncipher(reqMsg), IPAddress.Parse(serverIP), int.Parse(serverPort));

                //页面显示
                this.txtShowMessage.AppendText("\r\n" + username1 + "—>" + this.lbxComClient.SelectedItem.ToString() + "  " + TimeUtil.getNowTime() + "\r\n    " + this.txtInput.Text);
                this.txtInput.Clear();
                this.txtInput.Focus();
            
           
            }


        }


        //窗体关闭前，通知服务器
        private void chatClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            //使用户确定是否退出
            DialogResult result = MessageBox.Show("确定要退出系统并保存通信内容吗？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }



            //主机名称
            string username = hostIP.Replace('.', 'a') + "b" + hostPort;


            //if have got the 证书
            if (cerClients.Count != 0)
            {
                //窗体关闭，用户断开
                

                //构造报文
                string reqMsg = "8|" + username;

                sendMessage(aes.AesEncipher(reqMsg), IPAddress.Parse(serverIP), int.Parse(serverPort));
            }


            //保存通信内容
            if (this.txtShowMessage.Text != string.Empty) {
                    StreamWriter sw= new StreamWriter("clientChatRecord.txt", true, System.Text.Encoding.Default);
                    sw.Write("\r\n-----------------------------------华丽的分割线--------------------------------\r\n");
                    sw.Write(username + "会话内容记录\r\n");
                    sw.Write(this.txtShowMessage.Text);
                    sw.Close();
                
            }
        }

        private void btnShowMsg_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "clientChatRecord.txt";
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
