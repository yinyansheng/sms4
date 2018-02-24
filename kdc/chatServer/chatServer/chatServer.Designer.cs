namespace chatServer
{
    partial class chatServer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtServerKd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKaes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKekdc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnService = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxComClient = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxCerClient = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtComInfo = new System.Windows.Forms.TextBox();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewHistory);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.txtServerKd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtKaes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtKekdc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnService);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(128, 170);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(115, 29);
            this.btnDisconnect.TabIndex = 17;
            this.btnDisconnect.Text = "stop service";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtServerKd
            // 
            this.txtServerKd.Location = new System.Drawing.Point(104, 108);
            this.txtServerKd.Name = "txtServerKd";
            this.txtServerKd.ReadOnly = true;
            this.txtServerKd.Size = new System.Drawing.Size(260, 21);
            this.txtServerKd.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "KDC private key";
            // 
            // txtKaes
            // 
            this.txtKaes.Location = new System.Drawing.Point(104, 135);
            this.txtKaes.Name = "txtKaes";
            this.txtKaes.ReadOnly = true;
            this.txtKaes.Size = new System.Drawing.Size(260, 21);
            this.txtKaes.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "KDC AES key";
            // 
            // txtKekdc
            // 
            this.txtKekdc.Location = new System.Drawing.Point(104, 81);
            this.txtKekdc.Name = "txtKekdc";
            this.txtKekdc.ReadOnly = true;
            this.txtKekdc.Size = new System.Drawing.Size(260, 21);
            this.txtKekdc.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "KDC public key";
            // 
            // btnService
            // 
            this.btnService.Location = new System.Drawing.Point(249, 170);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(115, 29);
            this.btnService.TabIndex = 9;
            this.btnService.Text = "begin service";
            this.btnService.UseVisualStyleBackColor = true;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(104, 54);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.ReadOnly = true;
            this.txtServerPort.Size = new System.Drawing.Size(260, 21);
            this.txtServerPort.TabIndex = 8;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(104, 26);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.ReadOnly = true;
            this.txtServerIP.Size = new System.Drawing.Size(260, 21);
            this.txtServerIP.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lbxComClient);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbxCerClient);
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 284);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "当前通信用户组";
            // 
            // lbxComClient
            // 
            this.lbxComClient.FormattingEnabled = true;
            this.lbxComClient.ItemHeight = 12;
            this.lbxComClient.Location = new System.Drawing.Point(141, 33);
            this.lbxComClient.Name = "lbxComClient";
            this.lbxComClient.Size = new System.Drawing.Size(223, 244);
            this.lbxComClient.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "当前取得证书用户";
            // 
            // lbxCerClient
            // 
            this.lbxCerClient.FormattingEnabled = true;
            this.lbxCerClient.ItemHeight = 12;
            this.lbxCerClient.Location = new System.Drawing.Point(8, 33);
            this.lbxCerClient.Name = "lbxCerClient";
            this.lbxCerClient.Size = new System.Drawing.Size(127, 244);
            this.lbxCerClient.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtComInfo);
            this.groupBox3.Location = new System.Drawing.Point(397, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 506);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "communication status";
            // 
            // txtComInfo
            // 
            this.txtComInfo.Location = new System.Drawing.Point(6, 23);
            this.txtComInfo.Multiline = true;
            this.txtComInfo.Name = "txtComInfo";
            this.txtComInfo.ReadOnly = true;
            this.txtComInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComInfo.Size = new System.Drawing.Size(358, 477);
            this.txtComInfo.TabIndex = 0;
            this.txtComInfo.WordWrap = false;
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(8, 170);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(115, 29);
            this.btnViewHistory.TabIndex = 18;
            this.btnViewHistory.Text = "view record";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // chatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(808, 564);
            this.MinimumSize = new System.Drawing.Size(808, 564);
            this.Name = "chatServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chatServer";
            this.Load += new System.EventHandler(this.chatServer_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chatServer_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtComInfo;
        private System.Windows.Forms.TextBox txtKaes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKekdc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerKd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxCerClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbxComClient;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnViewHistory;
    }
}

