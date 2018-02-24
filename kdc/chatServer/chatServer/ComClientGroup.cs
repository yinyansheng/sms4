using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace chatServer
{
    /// <summary>
    /// 用户通信组
    /// </summary>
    class ComClientGroup
    {
        private CerClient cerClient1;

        internal CerClient CerClient1
        {
            get { return cerClient1; }
            set { cerClient1 = value; }
        }

        private CerClient cerClient2;

        internal CerClient CerClient2
        {
            get { return cerClient2; }
            set { cerClient2 = value; }
        }

        private int rn;

        public int Rn
        {
            get { return rn; }
            set { rn = value; }
        }

        private string timeTick;

        public string TimeTick
        {
            get { return timeTick; }
            set { timeTick = value; }
        }

        public override string ToString()
        {
            if (cerClient1.Username.CompareTo(cerClient2.Username) > 0)
            {
                return cerClient1.Username + "," + cerClient2.Username;
            }
            else {
                return cerClient2.Username + "," + cerClient1.Username;
            }
        }

        public ComClientGroup() { 
        
        }

        public ComClientGroup(CerClient c1, CerClient c2) {
            this.cerClient1 = c1;
            this.cerClient2 = c2;
            this.timeTick = TimeUtil.getTicks();
            this.rn = new Random().Next(10000, 100000);
            this.kaes = dt(rn.ToString());
        }


        private string dt(string rn)
        {

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

        private string kaes;

        public string Kaes
        {
            get { return kaes; }
            set { kaes = value; }
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

    }
}
