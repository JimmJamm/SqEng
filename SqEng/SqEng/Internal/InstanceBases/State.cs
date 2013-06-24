using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.InstanceBases
{
    public class State : GameObject
    {
        #region serialized



        #endregion

        #region override

        public override string TypePath
        {
            get { return "saves"; }
        }

        public override void LoadXmlDoc(System.Xml.XmlDocument x)
        {
            throw new NotImplementedException();
        }

        protected override void onTick()
        {
            
        }

        public override string ToXml(bool full = false)
        {
            throw new NotImplementedException();
        }

        public override SFML.Graphics.Sprite Sprite
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
