using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SqEng.Internal
{
    public abstract class GameObject
    {
        public abstract string TypePath { get; }
        public abstract string ToXml();
        public abstract void LoadXmlDoc(XmlDocument x);
        public GameObject(string path)
        {
            XmlDocument x = Resources.GetXml(Path.Combine(TypePath, path));
            foreach (XmlNode n in x)
            {
                if (n.Name == "base")
                {
                    LoadXmlDoc(Resources.GetXml(n.InnerText.Trim()));
                }
            }
            LoadXmlDoc(x);
        }
        public GameObject(){}
    }
}
