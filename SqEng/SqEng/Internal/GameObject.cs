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
        public float Rate = 1.0f;

        protected virtual void onTick() { }
        public double MSSinceLastTick = 1.0f;

        public void Tick(float rate = 1.0f)
        {
            float totalRate = Rate * rate;
            if (totalRate <= 1.0e-10)
                return;

            File.AppendAllText("c:/log.txt", "start\n");

            MSSinceLastTick += Execution.DeltaTimeMS;

            if (MSSinceLastTick >= Execution.MSPF / totalRate)
            {
                onTick();
                File.AppendAllText("c:/log.txt", MSSinceLastTick + "\r\n");
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
            foreach (XmlNode n in x)
            {
                string val = n.InnerText.Trim();
                switch (n.Name)
                {
                    case "base":
                        LoadXmlDoc(StaticResources.GetXml(val));
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
