using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using SFML.Graphics;
using SFML.Window;

namespace SqEng.Internal.Animation
{
    public class Frame : GameObject
    {
        private string tilesheet;
        private Sprite sprite;
        public bool Flipped = false;

        #region serialized
        public string TileSheet
        {
            get
            {
                return tilesheet ?? (tilesheet = "");
            }
            set
            {
                tilesheet = value;
                if (value != null && StaticResources.Tilesheets.ContainsKey(value))
                {
                    sprite = StaticResources.Tilesheets[value];
                    sprite.Origin = new SFML.Window.Vector2f(W / 2, H / 2);
                }
            }
        }

        public void MakeUnflipped()
        {
            Flipped = false;
            if (sprite.Scale.X < 0)
            {
                //var oldorigin = sprite.Origin;
                //sprite.Origin = new Vector2f(W / 2, H / 2);
                sprite.Scale = new Vector2f(1, 1);
                //sprite.Position = new Vector2f(sprite.Position.X - W, sprite.Position.Y);
                //sprite.Origin = oldorigin;
            }
        }

        public void MakeFlipped()
        {
            Flipped = true;
            if (sprite.Scale.X > 0)
            {
                //var oldorigin = sprite.Origin;
                //sprite.Origin = new Vector2f(W / 2, H / 2);
                sprite.Scale = new Vector2f(-1, 1);
                //sprite.Position = new Vector2f(sprite.Position.X + W, sprite.Position.Y);
                //sprite.Origin = oldorigin;
            }
        }

        public int X, Y, W, H;

        #endregion

        #region override

        public Frame(string path) 
            : base(path)
        {
            
        }

        public Frame(XmlDocument x)
            : base(x)
        {

        }

        public Frame(int x = 0, int y = 0, int w = 0, int h = 0) : base()
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        public override Sprite Sprite
        {
            get
            {
                return sprite;
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

        public override string ToXml(bool full = false)
        {
            return
                "<frame>" +
                    "<x>" + X + "</x>" +
                    "<y>" + Y + "</y>" +
                    "<w>" + W + "</w>" +
                    "<h>" + H + "</h>" +
                    "<tilesheet>" + TileSheet + "</tilesheet>" +
                    BaseXml +
                "</frame>";
             
        }

        #endregion

    }
}
