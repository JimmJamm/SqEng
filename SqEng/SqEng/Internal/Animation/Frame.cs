using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SqEng.Internal.Animation
{
    public class Frame : GameObject
    {
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

        public override void LoadXmlDoc(XmlDocument x)
        {
            
        }

        public override string TypePath
        {
            get { return "frame"; }
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
