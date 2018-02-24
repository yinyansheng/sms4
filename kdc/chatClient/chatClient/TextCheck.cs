using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace chatClient
{
    class TextCheck
    {
        //warning message
        private string warningMessage = null;

        /// <summary>
        /// 检查输入的端口号
        /// 默认通过的条件1.为数字 2.port  1000~60000即可。 
        /// </summary>
        /// <param name="testPort"></param>
        /// <returns></returns>
        public bool checkInputPort(string testPort) 
        {
            //不为null
            if (null == testPort) {
                warningMessage = "输入的端口号不能为null！";
                return false;
            }
            //不为empty
            if ("" == testPort)
            {
                warningMessage = "输入的端口号不能为空！";
                return false;
            }
            //全为数字
            for (int i = 0; i < testPort.Length; i++) {
                char c=testPort.ToCharArray()[i] ;
                if (c< '0' || c > '9')
                {
                    warningMessage = "输入的端口号必须为数字！";
                    return false;
                }
            }
            //首数字不能为0
            if (testPort.ToCharArray()[0] == '0')
            {
                 warningMessage="输入的端口号首位不要为0！";
                    return false;
            }

            //端口大小1000~60000之间合适

            int numPort=Int32.Parse(testPort);

            if(numPort>60000)
            {
                warningMessage = "输入的端口号不要大于60000！";
                return false;
            }

            if(numPort<1000){
                 warningMessage="输入的端口号不要小于1000！";
                    return false;
            }

         

            return true;


        }


        
        /// <summary>
        /// 检查输入的IP的格式
        /// </summary>
        /// <param name="testIP"></param>
        /// <returns></returns>
        public bool checkInputIP(string testIP) {

            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
            bool b = Regex.IsMatch(testIP, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
            if (!b) {
                warningMessage = "你输入的IP格式不对，请重新输入！（例：127.0.0.1）";
            }
            return b;
        }

        public string WarningMessage
        {
            get { return warningMessage; }
            set { warningMessage = value; }
        }

    }
}
