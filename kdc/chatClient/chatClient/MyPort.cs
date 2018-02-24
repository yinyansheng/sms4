using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace chatClient
{
    class MyPort
    {
        //检测端口是否可用
        public static Boolean checkPort(String testPort)
        {

            string strLocalInfo = getLocalInfo();

            if (strLocalInfo.IndexOf(":" + testPort + "|") >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //选择出10个可用端口
        public static string[] getPorts(int portNum)
        {
            string strLocalInfo = getLocalInfo();


            Random rand = new Random();
            int startPort = rand.Next(1000, 60000);

            string[] strPorts = new string[portNum];

            int index = 0;

            for (int i = startPort; index < portNum; i++)
            {
                if (strLocalInfo.IndexOf(":" + i + "|") >= 0)
                {

                }
                else
                {
                    strPorts[index] = i.ToString();
                    index++;
                }

            }
            return strPorts;
        }




        //获得本机netstat -an 端口信息
        private static string getLocalInfo()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            //查看本机端口占用情况
            p.StandardInput.WriteLine(" netstat -an ");
            p.StandardInput.WriteLine("exit");
            //
            StreamReader reader = p.StandardOutput;//截取输出流
            string strAllInfo = "";
            string strLocalInfo = "";
            string strLine = reader.ReadLine();//每次读取一行
            int i = 0;
            while (!reader.EndOfStream)
            {
                strAllInfo += strLine + "\r\n";

                i++;

                if (i < 9)//去掉之前相关信息
                {
                    /*
                    Microsoft Windows [版本 5.2.3790]
                    (C) 版权所有 1985-2003 Microsoft Corp.

                                E:\Documents and Settings\Administrator>netstat -an

                                Active Connections

                                  Proto Local Address          Foreign Address        State
                    */
                }
                else
                {
                    if (strLine.Trim().Length > 0)
                    {
                        strLine = strLine.Trim();
                        Regex r = new Regex(@"\s+");
                        string[] strArr = r.Split(strLine);
                        strLocalInfo += strArr[1] + "|\r\n";
                    }
                }
                strLine = reader.ReadLine();//再下一行          
            }
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();//关闭进程
            reader.Close();//关闭流

            return strLocalInfo;

        }
    }
}
