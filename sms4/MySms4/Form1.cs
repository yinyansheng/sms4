using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MySms4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            skinEngine1.SkinFile = "MP10.ssk";
            KeyText.Text = "12345678abcdefgh";
            key_count.Text = KeyText.Text.Length.ToString();
            PainText_count.Text = PlainText.Text.Length.ToString();
            CipherText_count.Text = ClipherText.Text.Length.ToString();
        }

        private Boolean testASCII(string judge, string str)     //判断是否是英文数字
        {
            string testEng = str;

            for (int i = 0; i < testEng.ToCharArray().Length; i++)      //逐个判断是否是英文数字
            {
                char t = testEng.ToCharArray()[i];
                if (t >= 0 && t <= 127)
                    continue;
                else
                {
                    MessageBox.Show("输入错误,请在" + judge + "内输入ASCII码表中的字符!",
                               "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        
        private Boolean TestOxCurrent(String strInput)        //判断是否为16进制
        {
            String testInput = strInput;
            byte[] TestOxCurrentIn = new byte[testInput.Length];
            TestOxCurrentIn = Encoding.Default.GetBytes(testInput);

            for (int i = 0; i < TestOxCurrentIn.Length; i++)       // 依次读入进行判断
            {
                if ((TestOxCurrentIn[i] >= 48 && TestOxCurrentIn[i] <= 57) || (TestOxCurrentIn[i] >= 97 && TestOxCurrentIn[i] <= 102))
                { continue; }
                else
                { return false; }
            }
            return true;
        }  //Boolean TestOxCurrent()  

        private void jiami_Click(object sender, EventArgs e)
        {
            
            string key = KeyText.Text;
            if (true == testASCII("Key", key))
            {
                if (16 == key.Length)
                {
                    if (true == testASCII("PlainText", PlainText.Text))
                    {
                        if (0 != PlainText.Text.Length)
                        {
                            TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);   //获取当前时间的刻度数
                            string plaintext = PlainText.Text;
                            Sms4 sms4 = new Sms4(key);

                            int pLength = plaintext.Length;
                            string newPaint = plaintext;
                            for (int i = 0; i < (16 - pLength % 16) % 16; i++)
                            {
                                newPaint += '0';
                            }
                            string cipherText = "";
                            string flag = "";
                            for (int i = 0; i < newPaint.Length / 16; i++)
                            {
                                flag = sms4.encryption(newPaint.Substring(i * 16, 16));
                                cipherText += flag;


                            }
                            ClipherText.Text = cipherText;

                            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                            TimeSpan ts = ts2.Subtract(ts1).Duration();//时间差的绝对值 
                            String spanTime = "加密运行时间: " + ts.Seconds.ToString() + "秒" + ts.Milliseconds.ToString() + "毫秒";

                            toolStripStatusLabel1.Text = spanTime;


                        }
                        else
                        {

                            MessageBox.Show("明文框中不能为空值!",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    if (KeyText.Text.Length < 16)
                    {
                        MessageBox.Show("key的位数小于16,请在key文本框内输入ASCII码表中的字符!",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("key的位数大于16,请在key文本框内内ASCII码表中的字符!",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void jiemi_Click(object sender, EventArgs e)
        {

            string key = KeyText.Text;
            if (true == testASCII("Key", key))
            {
                if (16 == key.Length)
                {
                    if (true == TestOxCurrent(ClipherText.Text))
                    {
                        if (0 != ClipherText.Text.Length && 0 == ClipherText.Text.Length % 32)
                        {

                            TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);   //获取当前时间的刻度数
                            string ciphertext = ClipherText.Text;
                            Sms4 sms4 = new Sms4(key);
                            string plaintext = string.Empty;


                            for (int i = 0; i < ciphertext.Length / 32; i++)
                            {
                                plaintext += sms4.decryption(ciphertext.Substring(i * 32, 32));
                            }

                            PlainText.Text = plaintext;

                            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                            TimeSpan ts = ts2.Subtract(ts1).Duration();//时间差的绝对值 
                            String spanTime = "解密运行时间: " + ts.Seconds.ToString() + "秒" + ts.Milliseconds.ToString() + "毫秒";

                            toolStripStatusLabel1.Text = spanTime;

                        }
                        else
                        {
                            MessageBox.Show("密文框中不能为空值且长度是32的整数倍!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("密文框中只能输入十六进制的数（0~F）!",
                                 "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("key的位数不足,请在key文本框内输入ASCII码表中的字符!!",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void KeyText_TextChanged(object sender, EventArgs e)
        {
            key_count.Text = KeyText.Text.Length.ToString();
        }

        private void PlainText_TextChanged(object sender, EventArgs e)
        {
            PainText_count.Text = PlainText.Text.Length.ToString();
        }

        private void ClipherText_TextChanged(object sender, EventArgs e)
        {
            CipherText_count.Text = ClipherText.Text.Length.ToString();
        }

        private void 清空明文MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlainText.Text = String.Empty;
        }

        private void 清空密文WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipherText.Text = string.Empty;
        }

        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instructions instructions = new Instructions();
            instructions.ShowDialog();
        }


        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calmnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "Calmness.ssk";
        }

        private void deepCyanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "deepCyan.ssk";
        }

        private void waveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "Wave.ssk";
        }

        private void mP10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = "MP10.ssk";
        }

        private void 打开明文OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;

            openFile.Filter = "文本文件|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFile.FileName, System.Text.Encoding.Default);
                PlainText.Text = streamReader.ReadToEnd();

                streamReader.Close();
            }
        }

        private void 打开密文KToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;

            openFile.Filter = "文本文件|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFile.FileName, System.Text.Encoding.Default);
                ClipherText.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        private void 保存明文BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckFileExists = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "文本文件|*.txt";

            DialogResult drsave = sfd.ShowDialog();
            if (drsave == DialogResult.OK)
            {
                string save = PlainText.Text;
                PlainText.Text = save;
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(PlainText.Text);
                sw.Close();            
            }
        }

        private void 保存密文QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckFileExists = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "文本文件|*.txt";

            DialogResult drsave = sfd.ShowDialog();
            if (drsave == DialogResult.OK)
            {
                string save = ClipherText.Text;
                ClipherText.Text = save;
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(ClipherText.Text);
                sw.Close();
            }
        }
        class Sms4
        {
            //轮密钥生成
            private string key = "";
            public Sms4(string key)
            {
                this.key = key;      //传入密钥
                get_rk();            //得到轮密钥rk[];
            }

            //S盒
            private ulong[,] SBOX = new ulong[,]
        {{0xd6,0x90,0xe9,0xfe,0xcc,0xe1,0x3d,0xb7,0x16,0xb6,0x14,0xc2,0x28,0xfb,0x2c,0x05},
        {0x2b,0x67,0x9a,0x76,0x2a,0xbe,0x04,0xc3,0xaa,0x44,0x13,0x26,0x49,0x86,0x06,0x99},
        {0x9c,0x42,0x50,0xf4,0x91,0xef,0x98,0x7a,0x33,0x54,0x0b,0x43,0xed,0xcf,0xac,0x62},
        {0xe4,0xb3,0x1c,0xa9,0xc9,0x08,0xe8,0x95,0x80,0xdf,0x94,0xfa,0x75,0x8f,0x3f,0xa6},
        {0x47,0x07,0xa7,0xfc,0xf3,0x73,0x17,0xba,0x83,0x59,0x3c,0x19,0xe6,0x85,0x4f,0xa8},
        {0x68,0x6b,0x81,0xb2,0x71,0x64,0xda,0x8b,0xf8,0xeb,0x0f,0x4b,0x70,0x56,0x9d,0x35},
        {0x1e,0x24,0x0e,0x5e,0x63,0x58,0xd1,0xa2,0x25,0x22,0x7c,0x3b,0x01,0x21,0x78,0x87},
        {0xd4,0x00,0x46,0x57,0x9f,0xd3,0x27,0x52,0x4c,0x36,0x02,0xe7,0xa0,0xc4,0xc8,0x9e},
        {0xea,0xbf,0x8a,0xd2,0x40,0xc7,0x38,0xb5,0xa3,0xf7,0xf2,0xce,0xf9,0x61,0x15,0xa1},
        {0xe0,0xae,0x5d,0xa4,0x9b,0x34,0x1a,0x55,0xad,0x93,0x32,0x30,0xf5,0x8c,0xb1,0xe3},
        {0x1d,0xf6,0xe2,0x2e,0x82,0x66,0xca,0x60,0xc0,0x29,0x23,0xab,0x0d,0x53,0x4e,0x6f},
        {0xd5,0xdb,0x37,0x45,0xde,0xfd,0x8e,0x2f,0x03,0xff,0x6a,0x72,0x6d,0x6c,0x5b,0x51},
        {0x8d,0x1b,0xaf,0x92,0xbb,0xdd,0xbc,0x7f,0x11,0xd9,0x5c,0x41,0x1f,0x10,0x5a,0xd8},
        {0x0a,0xc1,0x31,0x88,0xa5,0xcd,0x7b,0xbd,0x2d,0x74,0xd0,0x12,0xb8,0xe5,0xb4,0xb0},
        {0x89,0x69,0x97,0x4a,0x0c,0x96,0x77,0x7e,0x65,0xb9,0xf1,0x09,0xc5,0x6e,0xc6,0x84},
        {0x18,0xf0,0x7d,0xec,0x3a,0xdc,0x4d,0x20,0x79,0xee,0x5f,0x3e,0xd7,0xcb,0x39,0x48}};
            //常数FK[4]
            private ulong[] FK = new ulong[] { 0xa3b1bac6, 0x56aa3350, 0x677d9197, 0xb27022dc };
            //常数CK[32]
            private ulong[] CK = new ulong[]
        {
        0x00070e15,0x1c232a31,0x383f464d,0x545b6269,
        0x70777e85,0x8c939aa1,0xa8afb6bd,0xc4cbd2d9,
        0xe0e7eef5,0xfc030a11,0x181f262d,0x343b4249,
        0x50575e65,0x6c737a81,0x888f969d,0xa4abb2b9,
        0xc0c7ced5,0xdce3eaf1,0xf8ff060d,0x141b2229,
        0x30373e45,0x4c535a61,0x686f767d,0x848b9299,
        0xa0a7aeb5,0xbcc3cad1,0xd8dfe6ed,0xf4fb0209,
        0x10171e25,0x2c333a41,0x484f565d,0x646b7279
        };
            //初始密钥MK[4]
            ulong[] MK = new ulong[] { 0x01234567, 0x89abcdef, 0xfedcba98, 0x76543210 };

            private ulong[] rk = new ulong[32]; //存放轮密钥
            private ulong[] K = new ulong[36];  //存放中间数据
            private ulong[] X = new ulong[36];  //存放明文数据


            //密钥初始化
            private void initMK()
            {
                int index = 0;
                byte[] b = Encoding.ASCII.GetBytes(key);
                for (int i = 0; i < b.Length; i = i + 4)
                {
                    ulong x = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        x = x << 8;
                        x += b[j];
                    }
                    MK[index++] = x;
                }
            }

            private ulong rol(ulong a, int i)    //将a循环左移i位
            {
                ulong b;
                b = a;
                return ((a << i) | (b >> (32 - i))) & 0xFFFFFFFF;    //取后32位
            }

            //S盒扩散
            private ulong sbox(ulong a)
            {
                ulong b = a;
                return SBOX[a / 16, b - a / 16 * 16];
            }

            //tao函数
            private ulong tao(ulong a)
            {
                ulong a1, a2, a3, a0, b0, b1, b2, b3;
                //将a分为4个8位的数
                a0 = a >> 24;
                a1 = (a - (a0 << 24)) >> 16;
                a2 = (a - (a0 << 24) - (a1 << 16)) >> 8;
                a3 = a - (a0 << 24) - (a1 << 16) - (a2 << 8);

                b0 = sbox(a0);
                b1 = sbox(a1);
                b2 = sbox(a2);
                b3 = sbox(a3);
                return (b0 * 16777216 + b1 * 65536 + b2 * 256 + b3);
            }
            //L’函数
            private ulong L1(ulong b)
            {
                ulong b1, b2;
                b1 = b2 = b;
                return (b ^ (rol(b1, 13)) ^ (rol(b2, 23)));

            }

            //得到轮密钥
            private void get_rk()
            {
                //初始化密钥
                initMK();
                //初始化中间数
                K[0] = MK[0] ^ FK[0];
                K[1] = MK[1] ^ FK[1];
                K[2] = MK[2] ^ FK[2];
                K[3] = MK[3] ^ FK[3];

                for (int i = 0; i < 32; i++)
                {
                    K[i + 4] = K[i] ^ L1(tao(K[i + 1] ^ K[i + 2] ^ K[i + 3] ^ CK[i]));
                    rk[i] = K[i + 4];
                }
            }

            //L方法
            private ulong L(ulong b)
            {
                ulong b1, b2, b3, b4;
                b1 = b2 = b3 = b4 = b;
                return (b ^ (rol(b1, 2)) ^ (rol(b2, 10)) ^ (rol(b3, 18)) ^ (rol(b4, 24)));
            }

            //F方法
            private ulong F(ulong x0, ulong x1, ulong x2, ulong x3, ulong rk)
            {
                return (x0 ^ L(tao(x1 ^ x2 ^ x3 ^ rk)));

            }

            //初始化明文
            private void initPaint(string text)
            {
                int index = 0;
                byte[] b = Encoding.ASCII.GetBytes(text);
                for (int i = 0; i < b.Length; i = i + 4)
                {
                    ulong x = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        x = x << 8;
                        x += b[j];
                    }
                    X[index++] = x;
                }
            }

            //数字转字符
            private string ulongToChar(ulong a)
            {
                ulong a1 = 0, a2 = 0, a3 = 0, a0 = 0;
                //将a分为4个8位的数
                a0 = a >> 24;
                a1 = (a - (a0 << 24)) >> 16;
                a2 = (a - (a0 << 24) - (a1 << 16)) >> 8;
                a3 = a - (a0 << 24) - (a1 << 16) - (a2 << 8);

                return "" + (char)a0 + (char)a1 + (char)a2 + (char)a3;
            }

            //加密
            public string encryption(string plainText)
            {
                string miwen = "";
                initPaint(plainText);

                for (int i = 0; i < 32; i++)
                {
                    X[i + 4] = F(X[i], X[i + 1], X[i + 2], X[i + 3], rk[i]);
                }
                X[0] = X[35];
                X[1] = X[34];
                X[2] = X[33];
                X[3] = X[32];
                string flag = string.Empty;
                for (int i = 0; i < 4; i++)
                {
                    if (Convert.ToString((int)X[i], 16).Length == 7)
                    {
                        flag += "0";

                    }
                    flag += Convert.ToString((int)X[i], 16);

                }
                miwen = flag;
                return miwen;

            }


            private void initclipher(string clipherText)
            {
                int index = 0;
                for (int i = 0; i < clipherText.Length; i = i + 8)
                {
                    X[index++] = Convert.ToUInt64(clipherText.Substring(i, 8), 16);

                }
            }

            //解密
            public string decryption(string clipherText)
            {
                string mingwen = "";
                initclipher(clipherText);

                for (int i = 0; i < 32; i++)
                {
                    X[i + 4] = F(X[i], X[i + 1], X[i + 2], X[i + 3], rk[31 - i]);
                }

                X[0] = X[35];
                X[1] = X[34];
                X[2] = X[33];
                X[3] = X[32];
                for (int i = 0; i < 4; i++)
                {
                    mingwen += ulongToChar(X[i]);
                }
                return mingwen;

            }
        }

        private void 关于我们AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs aboutus = new AboutUs();
            aboutus.ShowDialog();
        }


    }
}