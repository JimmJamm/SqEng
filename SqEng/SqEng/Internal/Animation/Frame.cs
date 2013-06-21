using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SFML.Graphics;

namespace SqEng.Internal.Animation
{
    public class Frame : GameObject
    {
        public string TileSheet;

        public int X, Y, W, H;

        public Frame(string path) : base(path)
        {

        }

        public Frame(int x = 0, int y = 0, int w = 0, int h = 0) : base()
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        #region OverRides

        public override Sprite Sprite
        {
            get
            {
                return Resources.Tilesheets[TileSheet];
            }
        }

        public override void LoadXmlDoc(XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                string val = n.InnerText.Trim();
                switch (n.Name)
                {
                    case "x":
                        X = Convert.ToInt32(val);
                        break;
                    case "y":
                        Y = Convert.ToInt32(val);
                        break;
                    case "w":
                        W = Convert.ToInt32(val);
                        break;
                    case "h":
                        H = Convert.ToInt32(val);
                        break;
                    case "tilesheet":
                        TileSheet = val;
                        break;
                }
            }
        }

        public override string TypePath
        {
            get { return "frames"; }
        }

        public override string ToXml()
        {
            return
                "<frame>" +
                "<x>" + X + "</x>" +
                "<y>" + Y + "</y>" +
                "<w>" + W + "</w>" +
                "<h>" + H + "</h>" +
                "</frame>";
             
        }

        #endregion

    }
}
