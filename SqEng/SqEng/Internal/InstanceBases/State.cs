using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqEng.Internal.Animation;
using SFML.Graphics;
using SFML.Window;
using System.Xml;
using SqEng.Internal.SeaPonyDash;

namespace SqEng.Internal.InstanceBases
{

    public enum StateMode
    {
        Intro,
        Game,
        Outro
    }

    public class State : GameObject
    {
        private Actor maincharacter;
        public Actor MainCharacter
        {
            get
            {
                return maincharacter;
            }
        }

        public int Candies = 0;

        private Dialog dialog;
        public Dialog Dialog
        {
            get
            {
                return dialog ?? (dialog = new Dialog(""));
            }
        }

        private List<SeaPonyDash.Actor> actors;
        public List<SeaPonyDash.Actor> Actors
        {
            get
            {
                return actors ?? (actors = new List<SeaPonyDash.Actor>());
            }
            set
            {
                actors = value;
            }
        }

        #region serialized

        private List<Tile> tiles;
        public List<Tile> Tiles
        {
            get
            {
                return tiles ?? (tiles = new List<Tile>());
            }
            set
            {
                tiles = value;
            }
        }

        #endregion

        private Animation.Animation bg;

        public Sprite Background
        {
            get
            {
                if (bg == null)
                {
                    bg = new Animation.Animation("background");
                }
                bg.Sprite.Origin = new Vector2f(0, 0);
                return bg.Sprite;
            }
        }

        #region override

        public override string TypePath
        {
            get { return "saves"; }
        }

        public State()
            : base()
        {

        }

        public State(string path)
            : base(path)
        {

        }

        public override void LoadXmlDoc(System.Xml.XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                //switch (n.Name)
                //{
                //    case "shark":
                //        Actors.Add(SeaPonyDash.Actor.Shark);
                //        break;
                //    case "maincharacter":
                //        Actors.Add(SeaPonyDash.Actor.MainCharacter);
                //        break;
                //    case "taffy":
                //        Actors.Add(SeaPonyDash.Actor.Taffy);
                //        break;
                //}

                string val = n.InnerText.Trim();
                switch (n.Name)
                {
                    case "actor":
                        Actor tmpActor = new Actor(Helpers.NodeToDoc(n));
                        Actors.Add(tmpActor);
                        if (tmpActor.Type == ActorType.MainCharacter)
                            maincharacter = tmpActor;
                        else if (tmpActor.Type == ActorType.Taffy)
                        {
                            SeaPonyDash.Actor.TaffyIndex++;
                            if (Actor.TaffyIndex >= Actor.TaffyNames.Length)
                                Actor.TaffyIndex = 0;
                            tmpActor.Animation = new Animation.Animation(Actor.TaffyNames[Actor.TaffyIndex]);
                        }
                        break;
                }
            }
        }

        protected override void onTick()
        {
            bg.Tick();

            if (Dialog != null && Dialog.Active)
            {
                Dialog.Tick();
            }
            else
            {
                foreach (var a in Actors)
                {
                    if (a.OnScreen)
                        a.Tick();
                }
            }
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
