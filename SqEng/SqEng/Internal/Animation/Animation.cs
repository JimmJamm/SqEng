using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SqEng.Internal.Animation
{
    public class Animation : GameObject
    {
        #region serialized

        private string name;
        public string Name
        {
            get
            {
                return name ?? (name = "");
            }
            set
            {
                name = value;
            }
        }

        private List<Frame> frames;
        public List<Frame> Frames
        {
            get
            {
                return frames ?? (frames = new List<Frame>());
            }
        }

        public int Index = 0;
        public int Start = 0;

        #endregion

        #region override

        public override string TypePath
        {
            get { return "animations"; }
        }

        public Animation(string path)
            : base(path)
        {

        }

        public Animation(XmlDocument x)
            : base(x)
        {

        }

        public Animation() : base() { }

        public override void LoadXmlDoc(System.Xml.XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                string val = n.InnerText.Trim();
                switch (n.Name)
                {
                    case "frames":
                        foreach (XmlNode frameNode in n.ChildNodes)
                        {
                            Frames.Add(new Frame(Helpers.NodeToDoc(frameNode)));
                        }
                        break;
                    case "index":
                        Index = Convert.ToInt32(val);
                        break;
                    case "start":
                        Start = Convert.ToInt32(val);
                        break;
                    case "rate":
                        Rate = Convert.ToSingle(val);
                        break;
                    case "name":
                        Name = val;
                        break;
                }
            }
        }

        public override SFML.Graphics.Sprite Sprite
        {
            get
            {
                return Frames[Index].Sprite;
            }
        }

        public override string ToXml(bool full = false)
        {
            return 
                "<animation>" +
                    (full ?
                    "<name>" + Name + "</name>" +
                    "<index>" + Index + "</index>" +
                    "<start>" + Start + "</start>" +
                    "<frames>" +
                        string.Join("", (from f in Frames select f.ToXml())) +
                    "</frames>" : "") +
                    BaseXml +
                "</animation>";
        }

        protected override void onTick()
        {
            Index++;
            if (Index >= Frames.Count)
                Index = Start;
        }

        #endregion
    }
}
