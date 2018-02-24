using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chatServer
{
    public class AES
    {

        private int Nb = 4;               //State数组的列Nb,AES设为4    
        private int Nk = 0;               //定义密钥数组的列Nk,并初始化为0
        private int Nr = 0;               //定义迭代轮数Nr,并初始化为0
        private byte[] key;                         //key数组,存放用户输入的密钥

        public AES(string keyTemp)        //构造器
        {
            int length = keyTemp.Length;
            if (length == 32)
            {
                this.Nk = 4;
                this.Nr = 10;
            }
            else if (length == 48)
            {
                this.Nk = 6;
                this.Nr = 12;
            }
            else
            {
                this.Nk = 8;
                this.Nr = 12;
            }

            setKey(keyTemp);               //设置密钥
            SBox();                        //创建S盒
            InvSBox();                     //创建逆S盒
            BuildRcon();                   //
            KeyExpansion();                //密钥扩展

        }



        private void setKey(string inputKey)                  //设置初始密钥key[]
        {
            this.key = new byte[Nb * Nk];        //定义key数组大小,根据密钥大小而定
            String textKey = inputKey;     //从密钥的KeyText中读入密钥

            int[] textInt = new int[textKey.Length / 2];
            for (int i = 0; i < key.Length; i++)
            {
                textInt[i] = Convert.ToInt32(textKey.Substring(i * 2, 2), 16);    //Substring(起始位置,Length)
                key[i] = (byte)textInt[i];           //将密钥两个一组放入数组key[]                
            }


        } //设置初始密钥setKey() 

        private byte[,] Sbox;         // 创建S盒Sbox[16,16]
        private byte[,] iSbox;        // 创建逆S盒iSbox[16,16]



        private byte[,] cipherKey;                  //循环密钥cipherKey数组cipherKey[Nb * (Nr + 1), 4]
        private byte[,] Rcon;                       //轮常数Rcon
        private byte[,] State = new byte[4, 4];     //加密数组State[4,4]


        private void SBox()                    // 创建S盒 SBox()    
        {
            this.Sbox = new byte[16, 16] {  
          //  0列   1列   2列   3列   4列   5列   6列   7列   8列   9列   a列   b列   c列   d列   e列   f列   
             {0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76},   // 第 0 行 
             {0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0},   // 第 1 行  
             {0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15},   // 第 2 行 
             {0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75},   // 第 3 行  
             {0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84},   // 第 4 行  
             {0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf},   // 第 5 行 
             {0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8},   // 第 6 行 
             {0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2},   // 第 7 行 
             {0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73},   // 第 8 行  
             {0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb},   // 第 9 行  
             {0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79},   // 第 a 行  
             {0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08},   // 第 b 行  
             {0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a},   // 第 c 行 
             {0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e},   // 第 d 行  
             {0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf},   // 第 e 行  
             {0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16} }; // 第 f 行
        } //创建S盒 SBox()  

        private void InvSBox()                 // 创建逆S盒InvSBox()
        {
            this.iSbox = new byte[16, 16] {  
          //  0列   1列   2列   3列   4列   5列   6列   7列   8列   9列   a列   b列   c列   d列   e列   f列   
             {0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb},   // 第 0 行 
             {0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb},   // 第 1 行 
             {0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e},   // 第 2 行 
             {0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25},   // 第 3 行 
             {0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92},   // 第 4 行 
             {0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84},   // 第 5 行 
             {0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06},   // 第 6 行 
             {0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b},   // 第 7 行
             {0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73},   // 第 8 行
             {0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e},   // 第 9 行 
             {0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b},   // 第 a 行
             {0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4},   // 第 b 行
             {0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f},   // 第 c 行
             {0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef},   // 第 d 行
             {0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61},   // 第 e 行
             {0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d} }; // 第 f 行
        }  // 创建逆S盒InvSBox()

        private void BuildRcon()                       //创建轮常数Rcon()
        {
            this.Rcon = new byte[10, 4] {                  
                                         {0x01, 0x00, 0x00, 0x00},{0x02, 0x00, 0x00, 0x00},
                                         {0x04, 0x00, 0x00, 0x00},{0x08, 0x00, 0x00, 0x00},
                                         {0x10, 0x00, 0x00, 0x00},{0x20, 0x00, 0x00, 0x00},
                                         {0x40, 0x00, 0x00, 0x00},{0x80, 0x00, 0x00, 0x00},
                                         {0x1b, 0x00, 0x00, 0x00},{0x36, 0x00, 0x00, 0x00}
                                         // {0x6c, 0x00, 0x00, 0x00}
                                         };
        }   //创建轮常数Rcon()


        public string AesEncipher(string aesInput)
        {

            string aesOutput = "";
            StringBuilder cipherStr = new StringBuilder(20000000);           //可变的字符序列StringBuilder

            byte[] plainText = new byte[16];
            byte[] cipherText = new byte[16];

            byte[] tempStr = Encoding.Default.GetBytes(aesInput);

            int allInputLength = ((tempStr.Length - 1) / 16 + 1) * 16;           //明文总长度
            byte[] inputByte = new byte[allInputLength];

            int addCount = inputByte.Length - tempStr.Length;            //添加空格次数
            for (int i = 0; i < addCount; i++)               //若长度不为16的倍数,后加空格
            {
                aesInput = aesInput + " ";
            }

            inputByte = Encoding.Default.GetBytes(aesInput);        //明文数组


            for (int temp = 0; temp < inputByte.Length / 16; temp++)       //循环次数inputByte.Length / 16
            {
                for (int temp1 = 0, offset = temp * 16; temp1 < 16; temp1++)
                {
                    plainText[temp1] = inputByte[temp1 + offset];
                }
                Cipher(plainText, cipherText);     //调用加密函数Cipher(),对明文进行加密

                for (int temp2 = 0; temp2 < 16; temp2++)
                    cipherStr.Append(cipherText[temp2].ToString("x2"));    //添加到cipherStr
            }
            aesOutput = cipherStr.ToString();    //输出密文
            return aesOutput;

        }


        public string AesDecipher(string aesInput)
        {

            string aesOutput = "";
            StringBuilder tempStr = new StringBuilder(40000000);

            byte[] plainText = new byte[16];
            byte[] cipherText = new byte[16];

            byte[] textByte = new byte[aesInput.Length / 2];     //密文两个一组
            int[] textInt = new int[aesInput.Length / 2];


            for (int i = 0; i < textByte.Length; i++)
            {
                textInt[i] = Convert.ToInt32(aesInput.Substring(i * 2, 2), 16);//两个一组,16进制整形
                textByte[i] = (byte)textInt[i];
            }

            byte[] tempPlain = new byte[textByte.Length];    //放置明文

            //分组解密
            for (int temp = 0; temp < textByte.Length / 16; temp++)
            {
                for (int temp1 = 0, offset = 16 * temp; temp1 < 16; temp1++)
                {
                    cipherText[temp1] = textByte[temp1 + offset];
                }
                InvCipher(cipherText, plainText);      //调用函数进行解密

                for (int temp2 = 0, offset = 16 * temp; temp2 < 16; temp2++)//将每组得到的明文暂存在tempPlain中
                {
                    tempPlain[temp2 + offset] = plainText[temp2];
                }

            }
            tempStr.Append(Encoding.Default.GetString(tempPlain));
            aesOutput = tempStr.ToString();
            return aesOutput;
        }


        private void Cipher(byte[] inputByte, byte[] outputByte)   //加密函数  Cipher()
        {
            this.State = new byte[4, Nb];

            for (int i = 0; i < (4 * Nb); ++i)
                this.State[i / 4, i % 4] = inputByte[i];

            //加密
            AddRoundKey(0);
            for (int round = 1; round <= (Nr - 1); ++round)   //(Nr-1)个循环
            {
                SubBytes();
                ShiftRows();
                MixColumns();
                AddRoundKey(round);
            }

            SubBytes();                   //最后一次循环
            ShiftRows();
            AddRoundKey(Nr);
            for (int i = 0; i < (4 * Nb); ++i)
                outputByte[i] = this.State[i / 4, i % 4];
        } //加密函数 Cipher()

        private void SubBytes()  //加密 — 字节变换SubBytes
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < Nb; j++)
                {
                    this.State[i, j] = this.Sbox[(this.State[i, j] >> 4), (this.State[i, j]) & 0x0f];
                }

        } //加密 — 字节变换SubBytes

        private void ShiftRows()     //加密 — 移动行变换ShiftRows
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < i; j++)
                {
                    byte temp = State[i, 0];
                    State[i, 0] = State[i, 1];
                    State[i, 1] = State[i, 2];
                    State[i, 2] = State[i, 3];
                    State[i, 3] = temp;
                }

        }//加密—移动行变换ShiftRows

        private void MixColumns()      //加密—混合列变换MixColumns
        {
            byte[,] tempS = new byte[4, 4];
            for (int i = 0; i < 4; i++)     // 将State的数放入数组tempS[]
            {
                for (int j = 0; j < Nb; j++)
                {
                    tempS[i, j] = this.State[i, j];
                }
            }
            for (int i = 0; i < 4; ++i)
            {
                this.State[0, i] = (byte)((int)X02(tempS[0, i]) ^ (int)X03(tempS[1, i]) ^ (int)X01(tempS[2, i]) ^ (int)X01(tempS[3, i]));
                this.State[1, i] = (byte)((int)X01(tempS[0, i]) ^ (int)X02(tempS[1, i]) ^ (int)X03(tempS[2, i]) ^ (int)X01(tempS[3, i]));
                this.State[2, i] = (byte)((int)X01(tempS[0, i]) ^ (int)X01(tempS[1, i]) ^ (int)X02(tempS[2, i]) ^ (int)X03(tempS[3, i]));
                this.State[3, i] = (byte)((int)X03(tempS[0, i]) ^ (int)X01(tempS[1, i]) ^ (int)X01(tempS[2, i]) ^ (int)X02(tempS[3, i]));
            }
        }  // 加密—混合列变换MixColumns

        private void AddRoundKey(int round)             //加循环密钥AddRoundKey()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    this.State[i, j] = (byte)((int)this.State[i, j] ^ (int)cipherKey[(round * 4) + i, j]);
                }
        }  //加循环密钥 AddRoundKey()

        private byte X01(byte tempMix)
        {
            return tempMix;
        }
        private byte X02(byte tempMix)
        {
            if (tempMix < 0x80)
            {
                int temp = (int)(tempMix << 1);
                tempMix = (byte)temp;
                return tempMix;
            }
            else
            {
                int temp = (int)(tempMix << 1);
                temp = temp ^ (int)(0x1b);
                tempMix = (byte)temp;
                return tempMix;
            }
        }
        private byte X04(byte tempMix)
        {
            return (byte)((int)X02(X02(tempMix)));
        }
        private byte X08(byte tempMix)
        {
            return (byte)((int)X02(X02(X02(tempMix))));
        }
        private byte X03(byte tempMix)
        {
            int temp = (int)X02(tempMix);      //tempMix*0x03=tempMix(0x02+0x01)
            temp = temp ^ (int)tempMix;
            tempMix = (byte)temp;
            return tempMix;
        }






        public void InvCipher(byte[] inputByte, byte[] outputByte)  // 解密函数InvCipher()
        {

            this.State = new byte[4, Nb];

            for (int i = 0; i < (4 * Nb); ++i)
                this.State[i / 4, i % 4] = inputByte[i];

            //解密
            AddRoundKey(Nr);
            for (int round = Nr - 1; round > 0; round--)  // Nr-1个循环
            {
                InvSubBytes();
                InvShiftRows();
                AddRoundKey(round);
                InvMixColumns();
            }

            InvSubBytes();                         //最后一个循环
            InvShiftRows();
            AddRoundKey(0);

            for (int i = 0; i < (4 * Nb); ++i)
                outputByte[i] = this.State[i / 4, i % 4];

        }

        private void InvSubBytes() // 解密—字节变换InvSubBytes
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; ++j)
                    this.State[i, j] = this.iSbox[(this.State[i, j] >> 4), (this.State[i, j] & 0x0f)];
        }    // 解密—字节变换InvSubBytes

        private void InvShiftRows()  //解密—移动行变换 InvShiftRows
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < i; j++)
                {
                    byte temp = State[i, 3];
                    State[i, 3] = State[i, 2];
                    State[i, 2] = State[i, 1];
                    State[i, 1] = State[i, 0];
                    State[i, 0] = temp;
                }

        }  // 解密—移动行变换InvShiftRows()

        private void InvMixColumns()     //解密—混合列变换InvSubBytes
        {
            byte[,] temp = new byte[4, 4];

            for (int i = 0; i < 4; i++)  //将State放入数组temp[]
                for (int j = 0; j < 4; j++)
                    temp[i, j] = this.State[i, j];

            for (int i = 0; i < 4; ++i)
            {
                this.State[0, i] = (byte)((int)X0e(temp[0, i]) ^ (int)X0b(temp[1, i]) ^ (int)X0d(temp[2, i]) ^ (int)X09(temp[3, i]));
                this.State[1, i] = (byte)((int)X09(temp[0, i]) ^ (int)X0e(temp[1, i]) ^ (int)X0b(temp[2, i]) ^ (int)X0d(temp[3, i]));
                this.State[2, i] = (byte)((int)X0d(temp[0, i]) ^ (int)X09(temp[1, i]) ^ (int)X0e(temp[2, i]) ^ (int)X0b(temp[3, i]));
                this.State[3, i] = (byte)((int)X0b(temp[0, i]) ^ (int)X0d(temp[1, i]) ^ (int)X09(temp[2, i]) ^ (int)X0e(temp[3, i]));
            }
        }  // 解密—混合列变换InvSubBytes

        private byte X09(byte tempMix)
        {
            return (byte)(((int)X08(tempMix)) ^ (int)tempMix);   //tempMix*0x09=tempMix(0x08+0x01)        
        }
        private byte X0b(byte tempMix)
        {
            return (byte)((int)X08(tempMix) ^ (int)X02(tempMix) ^ (int)tempMix);   //tempMix*0x09=tempMix(0x08+0x02+0x01)  
        }
        private byte X0d(byte tempMix)
        {
            return (byte)((int)X08(tempMix) ^ (int)X04(tempMix) ^ (int)(tempMix));  //tempMix*0x09=tempMix(0x08+0x04+0x01)   
        }
        private byte X0e(byte tempMix)
        {
            return (byte)((int)X08(tempMix) ^ (int)X04(tempMix) ^ (int)X02(tempMix));  //tempMix*0x09=tempMix(0x08+0x04+0x02)  
        }



        private void KeyExpansion()                         //扩展密钥KeyExpansion()
        {
            BuildRcon();
            this.cipherKey = new byte[Nb * (Nr + 1), 4];            // 定义密钥数组
            byte[] tempKey = new byte[4];
            int rowTemp = Nb * Nk;

            for (int tempRow = 0; tempRow < Nb * Nk; tempRow++)
                this.cipherKey[tempRow / Nb, tempRow % Nb] = this.key[tempRow];


            if (Nk <= 6)      //Nk<=6时,扩展密钥
            {
                for (int I = Nk; I < Nb * (Nr + 1); ++I)
                {
                    tempKey[0] = this.cipherKey[I - 1, 0]; tempKey[1] = this.cipherKey[I - 1, 1];
                    tempKey[2] = this.cipherKey[I - 1, 2]; tempKey[3] = this.cipherKey[I - 1, 3];

                    if (I % Nk == 0)
                    {
                        tempKey = SubWord(Rotl(tempKey));
                        for (int i = 0; i < 4; i++)
                            tempKey[i] = (byte)((int)tempKey[i] ^ (int)this.Rcon[I / Nk - 1, i]);
                    }

                    for (int i = 0; i < 4; i++)
                        this.cipherKey[I, i] = (byte)((int)this.cipherKey[I - Nk, i] ^ (int)tempKey[i]);
                }

            }
            else          //Nk>6时,扩展密钥
            {
                for (int I = Nk; I < Nb * (Nr + 1); ++I)
                {
                    tempKey[0] = this.cipherKey[I - 1, 0]; tempKey[1] = this.cipherKey[I - 1, 1];
                    tempKey[2] = this.cipherKey[I - 1, 2]; tempKey[3] = this.cipherKey[I - 1, 3];

                    if (I % Nk == 0)
                    {
                        tempKey = SubWord(Rotl(tempKey));
                        for (int i = 0; i < 4; i++)
                            tempKey[i] = (byte)((int)tempKey[i] ^ (int)this.Rcon[I / Nk - 1, i]);
                    }
                    else
                        if (I % Nk == 4)
                            tempKey = SubWord(tempKey);

                    for (int i = 0; i < 4; i++)
                        this.cipherKey[I, i] = (byte)((int)this.cipherKey[I - Nk, i] ^ (int)tempKey[i]);

                }
            }


        }//扩展密钥KeyExpansion()

        private byte[] SubWord(byte[] temp)
        {
            byte[] tempkey = new byte[4];

            for (int i = 0; i < 4; i++)
                tempkey[i] = this.Sbox[temp[i] >> 4, temp[i] & 0x0f];

            return tempkey;
        }

        private byte[] Rotl(byte[] word)
        {
            byte[] tempkey = new byte[4];

            for (int i = 0; i < 4; i++)
                tempkey[i] = word[(i + 1) % 4];

            return tempkey;
        }

    }
}
