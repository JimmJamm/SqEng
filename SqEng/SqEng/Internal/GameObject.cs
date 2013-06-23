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
        public string BasePath;
        public double Rate = 1.0f;

        public string BaseXml
        {
            get
            {
                return
                    "<base>" + BasePath + "</base>" +
                    "<rate>" + Rate + "</rate>";
            }
        }

        protected virtual void onTick() { }
        public double MSSinceLastTick = 1.0f;

        public void Tick(double rate = 1.0f)
        {
            double totalRate = Rate * rate;
            if (totalRate == 0)
                return;

            MSSinceLastTick += Execution.DeltaTimeMS;

            while (MSSinceLastTick >= Execution.MSPF / totalRate)
            {
                onTick();
                MSSinceLastTick -= Execution.MSPF / totalRate;
            }
        }

        public GameObject(string basePath)
        {
            BasePath = basePath;
            baseLoadXml(StaticResources.GetXml(Path.Combine(TypePath, basePath)));
        }
        public GameObject(XmlDocument x)
        {
            baseLoadXml(x);
        }
        public GameObject(){}

        private void baseLoadXml(XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                string val = n.InnerText.Trim();
                switch (n.Name)
                {
                    case "base":
                        BasePath = val;
                        LoadXmlDoc(StaticResources.GetXml(Path.Combine(TypePath, val)));
                        break;
                    case "rate":
                        Rate = Convert.ToSingle(val);
                        break;
                }

            }
            LoadXmlDoc(x);
        }
    }
}
