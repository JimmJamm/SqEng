using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqEng.Internal.Animation;
using SFML.Graphics;
using SFML.Window;
using System.Xml;

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
        public int Candies = 0;

        private Dialog dialog;
        public Dialog Dialog
        {
            get
            {
                return dialog ?? (dialog = new Dialog(""));
            }
        }

        public SeaPonyDash.Actor MainCharacter;

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
                switch (n.Name)
                {
                    case "shark":
                        Actors.Add(SeaPonyDash.Actor.Shark);
                        break;
                    case "maincharacter":
                        Actors.Add(SeaPonyDash.Actor.MainCharacter);
                        break;
                    case "taffy":
                        Actors.Add(SeaPonyDash.Actor.Taffy);
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
