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
                            Frames.Add(new Frame(frameNode.OuterXml));
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
                }
            }
        }

        public override SFML.Graphics.Sprite Sprite
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToXml()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
