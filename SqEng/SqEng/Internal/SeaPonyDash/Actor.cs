using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;
using SqEng.Internal.Animation;
using System.Xml;
using SqEng.Internal;

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
        public bool Hidden = false;
        public bool SharkHit = false;

        public bool OnScreen
        {
            get
            {
                if (StaticResources.State.MainCharacter == null)
                    return false;

                var mc = StaticResources.State.MainCharacter;
                return Right >= mc.Left - 800 && Left <= mc.Right + 500 &&
                    Top >= mc.Top - 400 && Bottom <= mc.Bottom + 400;
            }
        }

        public float Left{
            get{
                return Position.X - Frame.W / 2;
            }
        }
        public float Right{
            get{

                return Left + Frame.W;
            }
        }
        public float Top{
            get{
                return Position.Y - Frame.H / 2;
            }
        }
        public float Bottom{
            get{
                return Top + Frame.H;
            }
        }
        public Vector2f Center{
            get{
                //return new Vector2f(Left + Frame.W/2, Top + Frame.H/2);
                return new Vector2f(Sprite.Position.X, Sprite.Position.Y);
                //return new Vector2f(Left, top
            }
        }

        public FloatRect ScreenRect
        {
            get
            {
                return new FloatRect(Center.X - 400, Center.Y - 300, 800, 600);
            }
        }


        public bool Spinning
        {
            get
            {
                if (Seq == null)
                    return false;
                if (Seq.Seq == Sequences.Spin)
                    return true;
                return false;
            }
        }

        private Sequence sequence;
        public Sequence Seq
        {
            get
            {
                if (sequence == null)
                    return null;
                if (!sequence.Running)
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
            if (!Seq.Running)
            {
                Seq = new Sequence(seq, lenMS, timoutMS);
            }
        }

        public View View
        {
            get
            {
                return new View(new Vector2f(Position.X, Position.Y), new Vector2f(800, 600));
                //return new View(new Vector2f(Position.X + Frame.W/2, Position.Y + Frame.H/2), new Vector2f(800, 600));
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
                return new Collision(new FloatRect(Left, Top, Frame.W, Frame.H));
            }
        }

        public Vector2f Position = new Vector2f();
        public Vector2f LastPosition = new Vector2f();
        public Vector2f DeltaPosition = new Vector2f();
        public Vector2f Velocity = new Vector2f();
        public Vector2f Acceleration = new Vector2f();

        public float speedlimit = 0.34f;

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
                    @Type = ActorType.Taffy,
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
            get { return "actors"; }
        }

        public override void LoadXmlDoc(System.Xml.XmlDocument x)
        {
            foreach (XmlNode n in x.DocumentElement.ChildNodes)
            {
                
                string val = n.InnerText.Trim();

                //System.Windows.Forms.MessageBox.Show(n.Name + " : " + val);

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

        public void GoBack()
        {
            DeltaPosition = new Vector2f(LastPosition.X - Position.X, LastPosition.Y - Position.Y);
            Position = new Vector2f(LastPosition.X, LastPosition.Y);
        }

        protected override void onTick()
        {
            Velocity += Acceleration * (float)Execution.MSPF;

            float a = 0.0005f;
            float div = 1.1f;

            if (@Type == ActorType.MainCharacter)
            {

                if (Velocity.X > speedlimit)
                    Velocity.X = speedlimit;
                if (Velocity.X < -speedlimit)
                    Velocity.X = -speedlimit;

                if (Velocity.Y > speedlimit)
                    Velocity.Y = speedlimit;
                if (Velocity.Y < -speedlimit)
                    Velocity.Y = -speedlimit;
            }

            LastPosition = new Vector2f(Position.X, Position.Y);
            Position += Velocity * (float)Execution.MSPF;
            DeltaPosition = new Vector2f(Position.X - LastPosition.X, Position.Y - LastPosition.Y);

            @Animation.Tick();
            switch (@Type)
            {
                case ActorType.Rock:
                    if (Collision.CollidingWith(StaticResources.State.MainCharacter.Collision))
                    {
                        StaticResources.State.MainCharacter.GoBack();
                    }
                    break;
                case ActorType.MainCharacter:
                    if (Velocity.X >= 0)
                    {
                        Frame.MakeUnflipped();
                    }
                    else if (Velocity.X <= 0)
                    {
                        Frame.MakeFlipped();
                    }

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

                    if (Collision.CollidingWith(StaticResources.State.MainCharacter.Collision))
                    {
                        if (StaticResources.State.MainCharacter.Seq != null)
                        {
                            if (StaticResources.State.MainCharacter.Seq.Seq == Sequences.Spin)
                            {
                                Seq = null;
                                Velocity = new Vector2f(0.8f, -0.8f);
                                SharkHit = true;
                                return;
                            }
                        }
                        if (!SharkHit)
                        {
                            System.Windows.Forms.MessageBox.Show("You died!");
                            Environment.Exit(0);
                            StaticResources.State.MainCharacter.GoBack();
                        }
                    }

                    if (!SharkHit)
                    {
                        if (Seq == null)
                        {
                            if (Velocity.X >= 0)
                            {
                                Velocity.X = -0.1f;
                                Seq = new Sequence(Sequences.SharkLeft, 3000, 0);
                            }
                            else
                            {
                                Velocity.X = 0.1f;
                                Seq = new Sequence(Sequences.SharkRight, 3000, 0);
                            }
                        }

                        if (Velocity.X <= 0)
                        {
                            Sprite.Scale = new Vector2f(1.0f, 1.0f);
                        }
                        else if (Velocity.X >= 0)
                        {
                            Sprite.Scale = new Vector2f(-1.0f, 1.0f);
                        }
                    }
                    else
                    {
                        Sprite.Scale = new Vector2f(Sprite.Scale.X / 2, Sprite.Scale.Y / 2);
                    }
                    break;
                case ActorType.Taffy:
                    if (!Hidden && Collision.CollidingWith(StaticResources.State.MainCharacter.Collision))
                    {
                        StaticResources.State.Candies++;
                        Hidden = true;
                        Sound.Play("player/powerup" + Helpers.Rnd.Next(1, 3), 50);
                        //System.Windows.Forms.MessageBox.Show("aaa");
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

        public Actor(XmlDocument x)
            : base(x)
        {

        }

        #endregion
    }
}
