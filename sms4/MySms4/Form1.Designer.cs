namespace MySms4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.KeyText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlainText = new System.Windows.Forms.TextBox();
            this.ClipherText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jiami = new System.Windows.Forms.Button();
            this.jiemi = new System.Windows.Forms.Button();
            this.key_count = new System.Windows.Forms.Label();
            this.PainText_count = new System.Windows.Forms.Label();
            this.CipherText_count = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空明文MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空密文WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开明文OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开密文KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存明文BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存密文QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.换皮肤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calmnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deepCyanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mP10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyText
            // 
            this.KeyText.Location = new System.Drawing.Point(89, 26);
            this.KeyText.Name = "KeyText";
            this.KeyText.Size = new System.Drawing.Size(296, 21);
            this.KeyText.TabIndex = 0;
            this.KeyText.TextChanged += new System.EventHandler(this.KeyText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "KeyText:";
            // 
            // PlainText
            // 
            this.PlainText.Location = new System.Drawing.Point(32, 71);
            this.PlainText.Multiline = true;
            this.PlainText.Name = "PlainText";
            this.PlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PlainText.Size = new System.Drawing.Size(353, 69);
            this.PlainText.TabIndex = 2;
            this.PlainText.TextChanged += new System.EventHandler(this.PlainText_TextChanged);
            // 
            // ClipherText
            // 
            this.ClipherText.Location = new System.Drawing.Point(32, 181);
            this.ClipherText.Multiline = true;
            this.ClipherText.Name = "ClipherText";
            this.ClipherText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ClipherText.Size = new System.Drawing.Size(353, 69);
            this.ClipherText.TabIndex = 3;
            this.ClipherText.TextChanged += new System.EventHandler(this.ClipherText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "PlainText";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "CipherText";
            // 
            // jiami
            // 
            this.jiami.Location = new System.Drawing.Point(116, 146);
            this.jiami.Name = "jiami";
            this.jiami.Size = new System.Drawing.Size(75, 23);
            this.jiami.TabIndex = 6;
            this.jiami.Text = "加密↓";
            this.jiami.UseVisualStyleBackColor = true;
            this.jiami.Click += new System.EventHandler(this.jiami_Click);
            // 
            // jiemi
            // 
            this.jiemi.Location = new System.Drawing.Point(232, 146);
            this.jiemi.Name = "jiemi";
            this.jiemi.Size = new System.Drawing.Size(75, 23);
            this.jiemi.TabIndex = 6;
            this.jiemi.Text = "解密↑";
            this.jiemi.UseVisualStyleBackColor = true;
            this.jiemi.Click += new System.EventHandler(this.jiemi_Click);
            // 
            // key_count
            // 
            this.key_count.AutoSize = true;
            this.key_count.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.key_count.ForeColor = System.Drawing.Color.Blue;
            this.key_count.Location = new System.Drawing.Point(392, 27);
            this.key_count.Name = "key_count";
            this.key_count.Size = new System.Drawing.Size(0, 14);
            this.key_count.TabIndex = 7;
            // 
            // PainText_count
            // 
            this.PainText_count.AutoSize = true;
            this.PainText_count.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PainText_count.ForeColor = System.Drawing.Color.Blue;
            this.PainText_count.Location = new System.Drawing.Point(392, 127);
            this.PainText_count.Name = "PainText_count";
            this.PainText_count.Size = new System.Drawing.Size(0, 14);
            this.PainText_count.TabIndex = 8;
            // 
            // CipherText_count
            // 
            this.CipherText_count.AutoSize = true;
            this.CipherText_count.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CipherText_count.ForeColor = System.Drawing.Color.Blue;
            this.CipherText_count.Location = new System.Drawing.Point(392, 237);
            this.CipherText_count.Name = "CipherText_count";
            this.CipherText_count.Size = new System.Drawing.Size(0, 14);
            this.CipherText_count.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用说明ToolStripMenuItem,
            this.关于我们AToolStripMenuItem});
            this.帮助ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 使用说明ToolStripMenuItem
            // 
            this.使用说明ToolStripMenuItem.Name = "使用说明ToolStripMenuItem";
            this.使用说明ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.使用说明ToolStripMenuItem.Text = "使用说明(&U)";
            this.使用说明ToolStripMenuItem.Click += new System.EventHandler(this.使用说明ToolStripMenuItem_Click);
            // 
            // 关于我们AToolStripMenuItem
            // 
            this.关于我们AToolStripMenuItem.Name = "关于我们AToolStripMenuItem";
            this.关于我们AToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于我们AToolStripMenuItem.Text = "关于我们(&A)";
            this.关于我们AToolStripMenuItem.Click += new System.EventHandler(this.关于我们AToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空明文MToolStripMenuItem,
            this.清空密文WToolStripMenuItem,
            this.toolStripMenuItem4,
            this.打开明文OToolStripMenuItem,
            this.打开密文KToolStripMenuItem,
            this.toolStripMenuItem3,
            this.保存明文BToolStripMenuItem,
            this.保存密文QToolStripMenuItem,
            this.toolStripMenuItem2,
            this.换皮肤ToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.编辑ToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 清空明文MToolStripMenuItem
            // 
            this.清空明文MToolStripMenuItem.Name = "清空明文MToolStripMenuItem";
            this.清空明文MToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.清空明文MToolStripMenuItem.Text = "清空明文(&P)";
            this.清空明文MToolStripMenuItem.Click += new System.EventHandler(this.清空明文MToolStripMenuItem_Click);
            // 
            // 清空密文WToolStripMenuItem
            // 
            this.清空密文WToolStripMenuItem.Name = "清空密文WToolStripMenuItem";
            this.清空密文WToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.清空密文WToolStripMenuItem.Text = "清空密文(&C)";
            this.清空密文WToolStripMenuItem.Click += new System.EventHandler(this.清空密文WToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem4.Text = "-----------------";
            // 
            // 打开明文OToolStripMenuItem
            // 
            this.打开明文OToolStripMenuItem.Name = "打开明文OToolStripMenuItem";
            this.打开明文OToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.打开明文OToolStripMenuItem.Text = "打开明文(&O)";
            this.打开明文OToolStripMenuItem.Click += new System.EventHandler(this.打开明文OToolStripMenuItem_Click);
            // 
            // 打开密文KToolStripMenuItem
            // 
            this.打开密文KToolStripMenuItem.Name = "打开密文KToolStripMenuItem";
            this.打开密文KToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.打开密文KToolStripMenuItem.Text = "打开密文(&K)";
            this.打开密文KToolStripMenuItem.Click += new System.EventHandler(this.打开密文KToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem3.Text = "-----------------";
            // 
            // 保存明文BToolStripMenuItem
            // 
            this.保存明文BToolStripMenuItem.Name = "保存明文BToolStripMenuItem";
            this.保存明文BToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.保存明文BToolStripMenuItem.Text = "保存明文(&B)";
            this.保存明文BToolStripMenuItem.Click += new System.EventHandler(this.保存明文BToolStripMenuItem_Click);
            // 
            // 保存密文QToolStripMenuItem
            // 
            this.保存密文QToolStripMenuItem.Name = "保存密文QToolStripMenuItem";
            this.保存密文QToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.保存密文QToolStripMenuItem.Text = "保存密文(&Q)";
            this.保存密文QToolStripMenuItem.Click += new System.EventHandler(this.保存密文QToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem2.Text = "---------------";
            // 
            // 换皮肤ToolStripMenuItem
            // 
            this.换皮肤ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calmnessToolStripMenuItem,
            this.deepCyanToolStripMenuItem,
            this.waveToolStripMenuItem,
            this.mP10ToolStripMenuItem});
            this.换皮肤ToolStripMenuItem.Name = "换皮肤ToolStripMenuItem";
            this.换皮肤ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.换皮肤ToolStripMenuItem.Text = "换皮肤(&H)";
            // 
            // calmnessToolStripMenuItem
            // 
            this.calmnessToolStripMenuItem.Name = "calmnessToolStripMenuItem";
            this.calmnessToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.calmnessToolStripMenuItem.Text = "Calmness";
            this.calmnessToolStripMenuItem.Click += new System.EventHandler(this.calmnessToolStripMenuItem_Click);
            // 
            // deepCyanToolStripMenuItem
            // 
            this.deepCyanToolStripMenuItem.Name = "deepCyanToolStripMenuItem";
            this.deepCyanToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deepCyanToolStripMenuItem.Text = "DeepCyan";
            this.deepCyanToolStripMenuItem.Click += new System.EventHandler(this.deepCyanToolStripMenuItem_Click);
            // 
            // waveToolStripMenuItem
            // 
            this.waveToolStripMenuItem.Name = "waveToolStripMenuItem";
            this.waveToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.waveToolStripMenuItem.Text = "Wave";
            this.waveToolStripMenuItem.Click += new System.EventHandler(this.waveToolStripMenuItem_Click);
            // 
            // mP10ToolStripMenuItem
            // 
            this.mP10ToolStripMenuItem.Name = "mP10ToolStripMenuItem";
            this.mP10ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.mP10ToolStripMenuItem.Text = "MP10";
            this.mP10ToolStripMenuItem.Click += new System.EventHandler(this.mP10ToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(28, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(9, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 285);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CipherText_count);
            this.Controls.Add(this.PainText_count);
            this.Controls.Add(this.key_count);
            this.Controls.Add(this.jiemi);
            this.Controls.Add(this.jiami);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClipherText);
            this.Controls.Add(this.PlainText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyText);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SMS4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KeyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PlainText;
        private System.Windows.Forms.TextBox ClipherText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button jiami;
        private System.Windows.Forms.Button jiemi;
        private System.Windows.Forms.Label key_count;
        private System.Windows.Forms.Label PainText_count;
        private System.Windows.Forms.Label CipherText_count;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空明文MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空密文WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 换皮肤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calmnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deepCyanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mP10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开明文OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开密文KToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存明文BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存密文QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}

