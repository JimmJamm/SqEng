using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SqEng.Internal
{
    public static class Resources
    {
        public static XmlDocument GetXml(string path)
        {
            XmlDocument x = new XmlDocument();
            x.LoadXml(File.ReadAllText("data/" + path + "data.xml"));
            return x;
        }
    }
}
