using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using SFML.Graphics;

namespace SqEng.Internal
{
    public abstract class GameObject
    {
        public abstract string TypePath { get; }
        public abstract Sprite @Sprite { get; }
        public abstract string ToXml();
        public abstract void LoadXmlDoc(XmlDocument x);
        public XmlDocument InitialXmlDoc;
        public string Name;
        public GameObject(string name)
        {
            Name = name;
            InitialXmlDoc = Resources.GetXml(Path.Combine(TypePath, name));
            foreach (XmlNode n in InitialXmlDoc)
            {
                if (n.Name == "base")
                {
                    LoadXmlDoc(Resources.GetXml(n.InnerText.Trim()));
                }
            }
            LoadXmlDoc(InitialXmlDoc);
        }
        public GameObject(){}
    }
}
