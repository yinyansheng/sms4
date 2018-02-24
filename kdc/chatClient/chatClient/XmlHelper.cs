using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace chatClient
{
    class XmlHelper
    {
        public static string Read(string node)
        {
            string path = "clientConfig.xml";

            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.DocumentElement[node];
               // Console.WriteLine(xn.InnerText);
                value=xn.InnerText;
            }
            catch { }
            return value;
        }


        public static void Update(string node, string value)
        {
            string path = "clientConfig.xml";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.DocumentElement[node];
                XmlElement xe = (XmlElement)xn;
                xe.InnerText = value;
                doc.Save(path);
            }
            catch { }
        }
    }
}
