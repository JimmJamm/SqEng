using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;
using SqEng.Internal.Animation;
using System.Xml;

namespace SqEng.Internal.SeaPonyDash
{
    public enum ActorType
    {
        MainCharacter,
        Shark,
        Taffy,
        Rock
    }
    public class Actor : GameObject
    {
        private Sequence sequence;
        public Sequence Seq
        {
            get
            {
                if (sequence == null)
                    return null;
                if (!sequence.Active)
                    return null;
                return sequence;
            }
            set
            {
                sequence = value;
            }
        }
        public void TrySquence(Sequences seq, int lenMS, int timoutMS)
        {
            if (Seq == null)
            {
                Seq = new Sequence(seq, lenMS, timoutMS);
                return;
            }
        }

        public View View
        {
            get
            {
                return new View(new Vector2f(Position.X + Frame.W/2, Position.Y + Frame.H/2), new Vector2f(800, 600));
            }
        }

        public ActorType @Type;

        public Frame Frame
        {
            get
            {
                return Animation.Frame;
            }
        }
        public override Collision Collision
        {
            get
            {
                return Frame.Collision;
            }
        }

        public Vector2f Position = new Vector2f();
        public Vector2f Velocity = new Vector2f();
        public Vector2f Acceleration = new Vector2f();

        public float speedlimit = 0.24f;

        public static Actor Shark
        {
            get
            {
                return new Actor()
                { 
                    Type = ActorType.Shark,
                    Animation = new Animation.Animation("shark")
                };
            }
        }
        private static Actor maincharacter;
        public static Actor MainCharacter
        {
            get
            {
                if (maincharacter == null)
                    maincharacter =
                        new Actor()
                        {
                            @Type = ActorType.MainCharacter,
                            Animation = new Animation.Animation("idle")
                        };

                return maincharacter;
            }
        }

        public static string[] TaffyNames = { "taffy_blue", "taffy_pink", "taffy_yellow" };
        public static int TaffyIndex = 0;

        public static Actor Taffy
        {
            get
            {
                TaffyIndex++;
                if (TaffyIndex >= TaffyNames.Length)
                    TaffyIndex = 0;

                return new Actor()
                {
                    @Type = ActorType.Taffy ,
                    Animation = new Animation.Animation(TaffyNames[TaffyIndex])
                };
            }
        }

        public Vector2f StartingPoint;

        public FloatRect FRect
        {
            get
            {
                return new FloatRect(
                    Sprite.Position.X, Sprite.Position.Y,
                    Animation.Frames[Animation.Index].W,
                    Animation.Frames[Animation.Index].H);
            }
        }

        public Animation.Animation Animation;

        #region overrides

        public override string TypePath
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
                    case "animation":
                        Animation = new Animation.Animation(Helpers.NodeToDoc(n));
                        break;
                    case "type":
                        switch (val)
                        {
                            case "maincharacter":
                                @Type = ActorType.MainCharacter;
                                break;
                            case "shark":
                                @Type = ActorType.Shark;
                                break;
                            case "taffy":
                                @Type = ActorType.Taffy;
                                break;
                            case "rock":
                                @Type = ActorType.Rock;
                                break;
                        }
                        break;
                    case "x":
                        Position.X = Convert.ToSingle(val);
                        break;
                    case "y":
                        Position.Y = Convert.ToSingle(val);
                        break;
                }
            }
        }

        protected override void onTick()
        {
            Velocity += Acceleration * (float)Execution.MSPF;

            float a = 0.0005f;
            float div = 1.1f;

            if (Velocity.X > speedlimit)
                Velocity.X = speedlimit;
            if (Velocity.X < -speedlimit)
                Velocity.X = -speedlimit;

            if (Velocity.Y > speedlimit)
                Velocity.Y = speedlimit;
            if (Velocity.Y < -speedlimit)
                Velocity.Y = -speedlimit;

            Position += Velocity * (float)Execution.MSPF;

            @Animation.Tick();
            switch (@Type)
            {
                case ActorType.MainCharacter:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                        Acceleration.Y = -a;
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                        Acceleration.Y = a;
                    else
                    {
                        Acceleration.Y = 0;
                        Velocity.Y /= div;
                    }

                    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                        Acceleration.X = a;
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                        Acceleration.X = -a;
                    else
                    {
                        Acceleration.X = 0;
                        Velocity.X /= div;
                    }

                    if (Seq != null)
                    {
                        switch (Seq.Seq)
                        {
                            case Sequences.Default:
                                Animation = Animations.Idle;
                                break;
                            case Sequences.Spin:
                                Animation = Animations.Spinny;
                                break;
                        }
                    }
                    else
                    {
                        Animation = Animations.Idle;
                    }

                    break;
                case ActorType.Shark:
                    
                    break;
                case ActorType.Taffy:
                    if (Collision.CollidingWith(StaticResources.State.MainCharacter.Collision))
                    {
                        StaticResources.State.Candies++;
                        Position.X += 20;
                        Position.Y -= 20;
                    }
                    break;
            }

            Sprite.Position = new Vector2f(Position.X, Position.Y);
        }

        public override SFML.Graphics.Sprite Sprite
        {
            get { return @Animation.Sprite; }
        }

        public override string ToXml(bool full = false)
        {
            throw new NotImplementedException();
        }

        public Actor()
            : base()
        {

        }

        public Actor(string path)
            : base(path)
        {

        }

        #endregion
    }
}
