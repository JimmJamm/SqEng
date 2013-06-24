using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SqEng.Internal.Animation
{
    public class AnimationGroup : GameObject
    {
        private Animation currentAnimation;
        #region serialized

        private Dictionary<string, Animation> animations;
        public Dictionary<string, Animation> Animations
        {
            get
            {
                return animations ?? (animations = new Dictionary<string, Animation>());
            }
        }

        private string currentAnimationName;
        public string CurrentAnimation
        {
            get
            {
                return currentAnimationName;
            }
            set
            {
                if (Animations.ContainsKey(value))
                {
                    currentAnimationName = value;
                    currentAnimation = Animations[value];
                }
            }
        }

        #endregion

        #region override

        public AnimationGroup(string path)
            : base(path)
        {

        }

        public AnimationGroup(XmlDocument x)
            : base(x)
        {

        }

        public AnimationGroup()
            : base()
        {

        }

        public override string TypePath
        {
            get { return "animationgroups"; }
        }

        public override void LoadXmlDoc(System.Xml.XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                string val = n.InnerText;
                switch (n.Name)
                {
                    case "animations":
                        foreach (XmlNode a in n.ChildNodes)
                        {
                            Animation tmpAnim = new Animation(Helpers.NodeToDoc(a));
                            Animations[tmpAnim.Name] = tmpAnim;
                        }

                        break;
                }
            }
        }

        public override string ToXml(bool full = false)
        {
            return 
                "<animationgroup>" +
                    (full ?
                    "<animations>" +
                        string.Join("", (from a in Animations.Values select a.ToXml())) +
                    "</animations>" +
                    "<currentanimation>" +
                        CurrentAnimation +
                    "</currentanimation>" : "") +
                    BaseXml +
                "</animationgroup>";
        }

        public override SFML.Graphics.Sprite Sprite
        {
            get { return currentAnimation.Sprite; }
        }
        #endregion
    }
}
