namespace chatClient
{
    partial class chatClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.registrationTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKaes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRegInfo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGetCertificate = new System.Windows.Forms.Button();
            this.btnGetUserKey = new System.Windows.Forms.Button();
            this.txtUserKd = new System.Windows.Forms.TextBox();
            this.txtUserKe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.txtKekdc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtHostIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConInfo = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtHostPort = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnShowMsg = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtShowMessage = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtComStatus = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelCom = new System.Windows.Forms.Button();
            this.btnAddCom = new System.Windows.Forms.Button();
            this.lbxComClient = new System.Windows.Forms.ListBox();
            this.lbxOnlineClient = new System.Windows.Forms.ListBox();
            this.myTabControl.SuspendLayout();
            this.registrationTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.registrationTab);
            this.myTabControl.Controls.Add(this.tabPage2);
            this.myTabControl.Location = new System.Drawing.Point(12, 12);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(776, 506);
            this.myTabControl.TabIndex = 0;
            // 
            // registrationTab
            // 
            this.registrationTab.Controls.Add(this.groupBox2);
            this.registrationTab.Controls.Add(this.groupBox1);
            this.registrationTab.Location = new System.Drawing.Point(4, 21);
            this.registrationTab.Name = "registrationTab";
            this.registrationTab.Padding = new System.Windows.Forms.Padding(3);
            this.registrationTab.Size = new System.Drawing.Size(768, 481);
            this.registrationTab.TabIndex = 0;
            this.registrationTab.Text = "registration";
            this.registrationTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKaes);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtRegInfo);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnRegistration);
            this.groupBox2.Controls.Add(this.txtKekdc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(7, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 328);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "user registration";
            // 
            // txtKaes
            // 
            this.txtKaes.Location = new System.Drawing.Point(112, 60);
            this.txtKaes.Name = "txtKaes";
            this.txtKaes.ReadOnly = true;
            this.txtKaes.Size = new System.Drawing.Size(426, 21);
            this.txtKaes.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "KDC AES key";
            // 
            // txtRegInfo
            // 
            this.txtRegInfo.Location = new System.Drawing.Point(544, 33);
            this.txtRegInfo.Multiline = true;
            this.txtRegInfo.Name = "txtRegInfo";
            this.txtRegInfo.ReadOnly = true;
            this.txtRegInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegInfo.Size = new System.Drawing.Size(205, 276);
            this.txtRegInfo.TabIndex = 8;
            this.txtRegInfo.Text = "user registration information";
            this.txtRegInfo.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGetCertificate);
            this.groupBox3.Controls.Add(this.btnGetUserKey);
            this.groupBox3.Controls.Add(this.txtUserKd);
            this.groupBox3.Controls.Add(this.txtUserKe);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(19, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 178);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "acquire certificate";
            // 
            // btnGetCertificate
            // 
            this.btnGetCertificate.Location = new System.Drawing.Point(374, 141);
            this.btnGetCertificate.Name = "btnGetCertificate";
            this.btnGetCertificate.Size = new System.Drawing.Size(130, 33);
            this.btnGetCertificate.TabIndex = 8;
            this.btnGetCertificate.Text = "acquire certificate";
            this.btnGetCertificate.UseVisualStyleBackColor = true;
            this.btnGetCertificate.Click += new System.EventHandler(this.btnGetCertificate_Click);
            // 
            // btnGetUserKey
            // 
            this.btnGetUserKey.Location = new System.Drawing.Point(374, 102);
            this.btnGetUserKey.Name = "btnGetUserKey";
            this.btnGetUserKey.Size = new System.Drawing.Size(130, 33);
            this.btnGetUserKey.TabIndex = 7;
            this.btnGetUserKey.Text = "acquire User Key";
            this.btnGetUserKey.UseVisualStyleBackColor = true;
            this.btnGetUserKey.Click += new System.EventHandler(this.btnGetUserKey_Click);
            // 
            // txtUserKd
            // 
            this.txtUserKd.Location = new System.Drawing.Point(113, 77);
            this.txtUserKd.Name = "txtUserKd";
            this.txtUserKd.ReadOnly = true;
            this.txtUserKd.Size = new System.Drawing.Size(391, 21);
            this.txtUserKd.TabIndex = 6;
            // 
            // txtUserKe
            // 
            this.txtUserKe.Location = new System.Drawing.Point(113, 20);
            this.txtUserKe.Name = "txtUserKe";
            this.txtUserKe.ReadOnly = true;
            this.txtUserKe.Size = new System.Drawing.Size(391, 21);
            this.txtUserKe.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "User private key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "User public key";
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(408, 92);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(130, 33);
            this.btnRegistration.TabIndex = 5;
            this.btnRegistration.Text = "registration";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // txtKekdc
            // 
            this.txtKekdc.Location = new System.Drawing.Point(112, 33);
            this.txtKekdc.Name = "txtKekdc";
            this.txtKekdc.ReadOnly = true;
            this.txtKekdc.Size = new System.Drawing.Size(426, 21);
            this.txtKekdc.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "KDC public key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMonitor);
            this.groupBox1.Controls.Add(this.txtHostIP);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtConInfo);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtHostPort);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "connect server";
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(233, 48);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(120, 33);
            this.btnMonitor.TabIndex = 10;
            this.btnMonitor.Text = "monitor ";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtHostIP
            // 
            this.txtHostIP.Location = new System.Drawing.Point(78, 69);
            this.txtHostIP.Name = "txtHostIP";
            this.txtHostIP.ReadOnly = true;
            this.txtHostIP.Size = new System.Drawing.Size(149, 21);
            this.txtHostIP.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "Host IP";
            // 
            // txtConInfo
            // 
            this.txtConInfo.Location = new System.Drawing.Point(359, 21);
            this.txtConInfo.Multiline = true;
            this.txtConInfo.Name = "txtConInfo";
            this.txtConInfo.ReadOnly = true;
            this.txtConInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConInfo.Size = new System.Drawing.Size(391, 98);
            this.txtConInfo.TabIndex = 7;
            this.txtConInfo.Text = "connect the server information";
            this.txtConInfo.WordWrap = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(233, 87);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 33);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtHostPort
            // 
            this.txtHostPort.Location = new System.Drawing.Point(78, 98);
            this.txtHostPort.Name = "txtHostPort";
            this.txtHostPort.ReadOnly = true;
            this.txtHostPort.Size = new System.Drawing.Size(149, 21);
            this.txtHostPort.TabIndex = 5;
            this.txtHostPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtHostPort_MouseDown);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(78, 43);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.ReadOnly = true;
            this.txtServerPort.Size = new System.Drawing.Size(149, 21);
            this.txtServerPort.TabIndex = 4;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(78, 16);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.ReadOnly = true;
            this.txtServerIP.Size = new System.Drawing.Size(149, 21);
            this.txtServerIP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Host Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "communication";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnShowMsg);
            this.groupBox6.Controls.Add(this.txtInput);
            this.groupBox6.Controls.Add(this.btnSend);
            this.groupBox6.Controls.Add(this.txtShowMessage);
            this.groupBox6.Location = new System.Drawing.Point(345, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(417, 469);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Communication GroupBox";
            // 
            // btnShowMsg
            // 
            this.btnShowMsg.Location = new System.Drawing.Point(93, 274);
            this.btnShowMsg.Name = "btnShowMsg";
            this.btnShowMsg.Size = new System.Drawing.Size(156, 34);
            this.btnShowMsg.TabIndex = 5;
            this.btnShowMsg.Text = "历史记录";
            this.btnShowMsg.UseVisualStyleBackColor = true;
            this.btnShowMsg.Click += new System.EventHandler(this.btnShowMsg_Click);
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInput.Location = new System.Drawing.Point(6, 314);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(405, 149);
            this.txtInput.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(255, 274);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(156, 34);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtShowMessage
            // 
            this.txtShowMessage.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtShowMessage.Location = new System.Drawing.Point(6, 21);
            this.txtShowMessage.Multiline = true;
            this.txtShowMessage.Name = "txtShowMessage";
            this.txtShowMessage.ReadOnly = true;
            this.txtShowMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShowMessage.Size = new System.Drawing.Size(405, 247);
            this.txtShowMessage.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtComStatus);
            this.groupBox5.Location = new System.Drawing.Point(6, 299);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(333, 176);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "通信状态";
            // 
            // txtComStatus
            // 
            this.txtComStatus.Location = new System.Drawing.Point(7, 21);
            this.txtComStatus.Multiline = true;
            this.txtComStatus.Name = "txtComStatus";
            this.txtComStatus.ReadOnly = true;
            this.txtComStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComStatus.Size = new System.Drawing.Size(320, 149);
            this.txtComStatus.TabIndex = 0;
            this.txtComStatus.Text = "communication status";
            this.txtComStatus.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btnDelCom);
            this.groupBox4.Controls.Add(this.btnAddCom);
            this.groupBox4.Controls.Add(this.lbxComClient);
            this.groupBox4.Controls.Add(this.lbxOnlineClient);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 287);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Client GroupBox";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(167, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "当前可通信用户";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "当前在线用户";
            // 
            // btnDelCom
            // 
            this.btnDelCom.Location = new System.Drawing.Point(169, 247);
            this.btnDelCom.Name = "btnDelCom";
            this.btnDelCom.Size = new System.Drawing.Size(156, 34);
            this.btnDelCom.TabIndex = 3;
            this.btnDelCom.Text = "取消通信";
            this.btnDelCom.UseVisualStyleBackColor = true;
            this.btnDelCom.Click += new System.EventHandler(this.btnDelCom_Click);
            // 
            // btnAddCom
            // 
            this.btnAddCom.Location = new System.Drawing.Point(7, 247);
            this.btnAddCom.Name = "btnAddCom";
            this.btnAddCom.Size = new System.Drawing.Size(156, 34);
            this.btnAddCom.TabIndex = 2;
            this.btnAddCom.Text = "申请通信";
            this.btnAddCom.UseVisualStyleBackColor = true;
            this.btnAddCom.Click += new System.EventHandler(this.btnAddCom_Click);
            // 
            // lbxComClient
            // 
            this.lbxComClient.FormattingEnabled = true;
            this.lbxComClient.ItemHeight = 12;
            this.lbxComClient.Location = new System.Drawing.Point(169, 33);
            this.lbxComClient.Name = "lbxComClient";
            this.lbxComClient.Size = new System.Drawing.Size(156, 208);
            this.lbxComClient.TabIndex = 1;
            // 
            // lbxOnlineClient
            // 
            this.lbxOnlineClient.FormattingEnabled = true;
            this.lbxOnlineClient.ItemHeight = 12;
            this.lbxOnlineClient.Location = new System.Drawing.Point(7, 33);
            this.lbxOnlineClient.Name = "lbxOnlineClient";
            this.lbxOnlineClient.Size = new System.Drawing.Size(156, 208);
            this.lbxOnlineClient.TabIndex = 0;
            // 
            // chatClientForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.myTabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(808, 564);
            this.MinimumSize = new System.Drawing.Size(808, 564);
            this.Name = "chatClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chatClient";
            this.Load += new System.EventHandler(this.chatClientForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chatClientForm_FormClosing);
            this.myTabControl.ResumeLayout(false);
            this.registrationTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl myTabControl;
        private System.Windows.Forms.TabPage registrationTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHostPort;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConInfo;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtKekdc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Button btnGetCertificate;
        private System.Windows.Forms.Button btnGetUserKey;
        private System.Windows.Forms.TextBox txtUserKd;
        private System.Windows.Forms.TextBox txtUserKe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegInfo;
        private System.Windows.Forms.TextBox txtHostIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKaes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtShowMessage;
        private System.Windows.Forms.TextBox txtComStatus;
        private System.Windows.Forms.Button btnDelCom;
        private System.Windows.Forms.Button btnAddCom;
        private System.Windows.Forms.ListBox lbxComClient;
        private System.Windows.Forms.ListBox lbxOnlineClient;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnShowMsg;
    }
}

