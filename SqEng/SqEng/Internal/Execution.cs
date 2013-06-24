using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;
using SqEng.Internal.SeaPonyDash;

namespace SqEng.Internal
{
    public enum ExecMode
    {
        Title,
        Intro,
        Main,
        End
    }

    public static class Execution
    {
        public static ExecMode mode;

        public static double MSPF = 1000 / 30;
        public static double DeltaTimeMS = MSPF;

        public static RenderWindow window;
        public static VideoMode videomode = new VideoMode(800u, 600u, 32u);
        public static string title = "Sea Pony Dash!";

        public static DateTime lastTick;

        public static bool KeyPressedThisFrame = false;

        public static void DialogIfDialog()
        {
            if (StaticResources.State.Dialog != null && StaticResources.State.Dialog.Active)
            {
                window.Draw(StaticResources.State.Dialog.SFMLText);
            }
        }

        public static void Run()
        {
            Sound.Loop("music/seaponies");

            window = new RenderWindow(videomode, title, Styles.Default);

            window.Closed += new EventHandler(OnClosed);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            window.Resized += new EventHandler<SizeEventArgs>(OnResized);

            window.SetIcon(48, 48, new Image("data/tilesheets/pinktaffy48.png").Pixels);

            Sprite titleScreen = new Sprite(new Texture(new Image("data/tilesheets/title.png")));

            lastTick = DateTime.Now;

            View originView = new View(new Vector2f(400, 300), new Vector2f(800, 600));

            DateTime starttime = DateTime.Now;

            while (window.IsOpen())
            {

                if (TotalTaffies != 0 && StaticResources.State.Candies >= TotalTaffies){
                    var t = (DateTime.Now - starttime).TotalMilliseconds/1000;
                    System.Windows.Forms.MessageBox.Show("You win! Time: " + t);
                    System.IO.File.AppendAllText("scores.txt", t + "\n");
                   Environment.Exit(0);
                }

                DeltaTimeMS = (DateTime.Now - lastTick).TotalMilliseconds;

                if (DeltaTimeMS < MSPF)
                {
                    System.Threading.Thread.Sleep((int)(MSPF - DeltaTimeMS));
                    DeltaTimeMS = MSPF;
                }

                lastTick = DateTime.Now;

                window.DispatchEvents();

                window.SetView(originView);
                window.Draw(StaticResources.State.Background);

                switch (mode)
                {
                    case ExecMode.Title:
                        window.Draw(titleScreen);
                        break;
                    case ExecMode.Intro:
                        StaticResources.State.Tick();
                        DialogIfDialog();
                        break;
                    case ExecMode.Main:
                        StaticResources.State.Tick();
                        
                        if (StaticResources.State.MainCharacter != null){
                            window.SetView(StaticResources.State.MainCharacter.View);
                            //window.SetTitle(StaticResources.State.MainCharacter.Position.ToString());
                        }

                        foreach (SeaPonyDash.Actor a in StaticResources.State.Actors)
                        {
                            if (!a.Hidden && a.OnScreen)
                            {
                                //if (a.Type == ActorType.Taffy)
                                //{
                                //    Sprite b = new Sprite(a.Sprite);
                                //    b.Position = a.Position;
                                //    b.TextureRect = new IntRect(0, 0, 64, 64);
                                //    //works
                                //    window.Draw(b);
                                //}
                                //shows nothing on all but a few of the taffy sprites
                                window.Draw(new Sprite(a.Sprite) { Position = a.Position, TextureRect = a.Sprite.TextureRect });
                                //System.Windows.Forms.MessageBox.Show(a.Sprite.Position.ToString() + " " + a.Frame.ToXml() + " " + a.Animation.ToXml());
                            }
                            else
                            {
                            }
                        }

                        window.SetView(originView);

                        Text txt = new Text("Taffies: " + StaticResources.State.Candies + " / " + (TotalTaffies), StaticResources.CelestiaRedux);
                        txt.CharacterSize = 30;

                        DialogIfDialog();

                        window.Draw(txt);

                        if (StaticResources.State.MainCharacter != null)
                            window.SetView(StaticResources.State.MainCharacter.View);

                        break;
                    case ExecMode.End:

                        break;
                }
                
                window.Display();
            }

        }

        /// <summary>
        /// Function called when the window is closed
        /// </summary>
        static void OnClosed(object sender, EventArgs e)
        {
            window.Close();
            while (window.IsOpen()) ;
            Environment.Exit(0);
        }
        public static int TotalTaffies = 1;
        /// <summary>
        /// Function called when a key is pressed
        /// </summary>
        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (StaticResources.State.Dialog != null && StaticResources.State.Dialog.Active)
            {
                StaticResources.State.Dialog.KeyPress();
            }

            Window window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
                window.Close();

            switch (mode)
            {
                case ExecMode.Title:
                    mode = ExecMode.Intro;
                    StaticResources.State.Dialog.Activate(
                        "Welcome to the Olympics, \n" + 
                        "hosted this year by the sea ponies!\n" +
                        "The current event is: swimming!\n" +
                        "Collect all the taffies!\n" + 
                        "Move - WASD\n" +
                        "Spin - Space\n" +
                        "Go!"
                    );
                    break;
                case ExecMode.Intro:
                    //Sound.StopAll();
                    //Sound.Loop("music/aurora", 40);
                    Sound.Loop("ambient/water", 40);
                    mode = ExecMode.Main;
                    for (int i = 0; i < 1024 * 2; i += 80)
                    {
                        StaticResources.State.Actors.Add(Actor.Taffy);
                        StaticResources.State.Actors.Last().Position = new Vector2f(i, 0);
                        TotalTaffies++;
                    }
                    int r = 400;
                    for (int x = -r; x < r; x += 64)
                    {
                        int y = (int)((float)Math.Sqrt(r * r - x * x));
                        Actor circleTaffy = Actor.Taffy;
                        circleTaffy.Position = new Vector2f(x, y);
                        StaticResources.State.Actors.Add(circleTaffy);

                        Actor circleTaffy2 = Actor.Taffy;
                        circleTaffy2.Position = new Vector2f(x, -y);
                        StaticResources.State.Actors.Add(circleTaffy2);

                        TotalTaffies += 2;
                    }

                    int L = -(512 + 128);
                    int thickness = 4 * 128;
                    int T = -700;
                    int R = L + 3000;
                    int B = T + 2000;

                    for (int i = L + 128; i < R - 128; i += 64)
                    {
                        Actor taffy = Actor.Taffy;
                        taffy.Position = new Vector2f(i, (float)
                            (512.0f * Math.Sin((i / 200.0f))));
                        StaticResources.State.Actors.Add(taffy);
                        TotalTaffies += 1;
                    }

                    //top
                    for (int y = T - thickness - 128; y < T ; y += 128)
                    {
                        for (int x = L - thickness; x < R + thickness; x += 128)
                        {
                            Actor c = Blocks.c;
                            c.Position = new Vector2f(x, y);
                            StaticResources.State.Actors.Add(c);
                        }
                    }

                    for (int x = L; x < R + 128; x += 128)
                    {
                        Actor b = Blocks.b;
                        b.Position = new Vector2f(x, T);
                        StaticResources.State.Actors.Add(b);
                    }

                    //bottom
                    for (int y = B + 128; y < B + thickness; y += 128)
                    {
                        for (int x = L - thickness; x < R + thickness; x += 128)
                        {
                            Actor c = Blocks.c;
                            c.Position = new Vector2f(x, y);
                            StaticResources.State.Actors.Add(c);
                        }
                    }
                    for (int x = L; x < R + 128; x += 128)
                    {
                        Actor t = Blocks.t;
                        t.Position = new Vector2f(x, B);
                        StaticResources.State.Actors.Add(t);
                    }

                    //left
                    for (int x = L - thickness - 128; x < L ; x += 128)
                    {
                        for (int y = T; y < B + 128; y += 128)
                        {
                            Actor c = Blocks.c;
                            c.Position = new Vector2f(x, y);
                            StaticResources.State.Actors.Add(c);
                        }
                    }
                    for (int y = T; y < B + 128; y += 128)
                    {
                        Actor ri = Blocks.r;
                        ri.Position = new Vector2f(L, y);
                        StaticResources.State.Actors.Add(ri);
                    }

                    //right
                    for (int x = R + 128; x < R + 128 + thickness; x += 128)
                    {
                        for (int y = T; y < B + 128; y += 128)
                        {
                            Actor c = Blocks.c;
                            c.Position = new Vector2f(x, y);
                            StaticResources.State.Actors.Add(c);
                        }
                    }
                    for (int y = T; y < B + 128; y += 128)
                    {
                        Actor l = Blocks.l;
                        l.Position = new Vector2f(R, y);
                        StaticResources.State.Actors.Add(l);
                    }


                    
                    for (int i = 0; i < 30; i++)
                    {
                        //int x = i * 128;
                        //Actor c = Blocks.c;
                        //c.Position = new Vector2f(x, -(1024 + 128));
                        //StaticResources.State.Actors.Add(c);
                    }
                    break;
                case ExecMode.Main:

                    switch (e.Code)
                    {
                        case Keyboard.Key.Space:
                            StaticResources.State.MainCharacter.TrySquence(
                                Sequences.Spin, 600, 200
                            );
                            break;
                    }

                    break;
            }
        }

        /// <summary>
        /// Function called when the window is resized
        /// </summary>
        static void OnResized(object sender, SizeEventArgs e)
        {
            window.Size = new Vector2u(800u, 600u);
        }
    }
}
