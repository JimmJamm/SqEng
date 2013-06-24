using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using SFML.Graphics;
using SqEng.Internal.InstanceBases;

namespace SqEng.Internal
{
    public static class StaticResources
    {

        private static State state;
        public static State State
        {
            get
            {
                return state ?? (state = new State("1"));
            }
        }

        private static Dictionary<string, Sprite> tilesheets;
        public static Dictionary<string, Sprite> Tilesheets
        {
            get
            {
                if (tilesheets == null)
                {
                    tilesheets = new Dictionary<string, Sprite>();
                    foreach (FileInfo fi in (new DirectoryInfo("data/tilesheets")).GetFiles())
                    {
                        tilesheets[fi.Name] = new Sprite(new Texture(new Image(fi.FullName)));
                    }
                }
                return tilesheets;
            }
        }

        public static XmlDocument GetXml(string path)
        {
            XmlDocument x = new XmlDocument();
            x.LoadXml(File.ReadAllText("data/" + path + "/data.xml"));
            return x;
        }
    }
}
