using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace chatClient
{
    class ComClient
    {

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string rn;

        public string Rn
        {
            get { return rn; }
            set { rn = value; }
        }

        private string ticks;

        public string Ticks
        {
            get { return ticks; }
            set { ticks = value; }
        }

        //共享Aes密钥 
        private string kaes;

        public string Kaes
        {
            get { return kaes; }
            set { kaes = value; }
        }


        public ComClient() { 
            
        }

        public ComClient(string username,string rn,string ticks) {
            this.username = username;
            this.rn = rn;
            this.ticks = ticks;
            this.kaes = dt(rn);
        }



         /*
                 
             A和B分别用RN产生会话密钥，
             Ks＝Dt(RN，KAB）
        */
        private string dt(string rn) {

            StringBuilder aesK = new StringBuilder();
            string str = SHA1Encrypt(rn);
            int index = 0;
            for (int i = 0; i < 14; index++)
            {
                char c = str.ToCharArray()[index % 40];
                if (c >= '0' && c <= '9')
                {
                    aesK.Append(c);
                    i++;
                }

            }

            index = 0;
            for (int i = 0; i < 4; index++)
            {
                char c = str.ToCharArray()[index % 40];
                if (c >= 'a' && c <= 'z')
                {
                    aesK.Append(c);
                    i++;
                }

            }

            index = 0;
            for (int i = 0; i < 28; index++)
            {
                char c = str.ToCharArray()[index % 40];
                if (c >= '0' && c <= '9')
                {
                    aesK.Append(c);
                    i++;
                }

            }

            index = 0;
            for (int i = 0; i < 4; index++)
            {
                char c = str.ToCharArray()[index % 40];
                if (c >= 'a' && c <= 'z')
                {
                    aesK.Append(c);
                    i++;
                }

            }

            index = 0;
            for (int i = 0; i < 14; index++)
            {
                char c = str.ToCharArray()[index % 40];
                if (c >= '0' && c <= '9')
                {
                    aesK.Append(c);
                    i++;
                }

            }
            return aesK.ToString();
        }

        private string SHA1Encrypt(string Source_String)
        {

            byte[] StrRes = Encoding.Default.GetBytes(Source_String);

            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();

            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }

            return EnText.ToString();
        }  


        public override string ToString()
        {
            return this.username;
        }
    }
}
