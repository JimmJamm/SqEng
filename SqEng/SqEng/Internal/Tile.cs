using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqEng.Internal.Animation;
using System.Xml;

namespace SqEng.Internal
{
    public class Tile : GameObject
    {
        #region serialized

        public AnimationGroup AnimGroup;

        #endregion

        #region overrides

        public override string TypePath
        {
            get { return "tiles"; }
        }

        public Tile(string path)
            : base(path)
        {

        }

        public Tile()
            : base()
        {

        }

        public Tile(XmlDocument x)
            : base(x)
        {

        }

        public override SFML.Graphics.Sprite Sprite
        {
            get { throw new NotImplementedException(); }
        }

        public override void LoadXmlDoc(System.Xml.XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                string val = n.InnerText.Trim();
                switch (n.Name)
                {
                    case "animationgroup":
                        AnimGroup = new AnimationGroup(Helpers.NodeToDoc(n));
                        break;
                }
            }
        }

        public override string ToXml(bool full = false)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
