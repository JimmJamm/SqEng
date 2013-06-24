using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

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

        public static void Run()
        {
            Sound.Loop("music/seaponies");

            StaticResources.State.MainCharacter = SeaPonyDash.Actor.MainCharacter;

            window = new RenderWindow(videomode, title, Styles.Default);

            window.Closed += new EventHandler(OnClosed);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            window.Resized += new EventHandler<SizeEventArgs>(OnResized);

            window.SetIcon(64, 64, new Image("data/tilesheets/pinktaffy.png").Pixels);

            Sprite titleScreen = new Sprite(new Texture(new Image("data/tilesheets/title.png")));

            lastTick = DateTime.Now;

            View originView = new View(new Vector2f(400, 300), new Vector2f(800, 600));

            while (window.IsOpen())
            {
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
                    case ExecMode.Main:
                        StaticResources.State.Tick();

                        window.SetView(StaticResources.State.MainCharacter.View);

                        foreach (SeaPonyDash.Actor a in StaticResources.State.Actors)
                        {
                            //if (window.GetView().Viewport.Intersects(a.FRect))
                            //{
                                window.Draw(a.Sprite);
                            //}
                            //else
                            //{
                            //}
                        }

                        if (StaticResources.State.Dialog != null && StaticResources.State.Dialog.Active)
                        {
                            window.SetView(originView);
                            window.Draw(StaticResources.State.Dialog.SFMLText);
                        }
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

            if (mode == ExecMode.Title)
            {
 
            }

            switch (mode)
            {
                case ExecMode.Title:
                    mode = ExecMode.Main;
                    StaticResources.State.Dialog.Activate(
                        "Welcome to the Olympics, hosted this year by the sea ponies!\n" +
                        "The current event is: swimming!\n" +
                        "3, 2, 1 .. Go!"
                    );
                    break;
                case ExecMode.Intro:
                    Sound.StopAll();
                    Sound.Loop("music/aurora", 40);
                    Sound.Loop("ambient/water", 40);
                    break;
                case ExecMode.Main:

                    switch (e.Code)
                    {
                        case Keyboard.Key.Space:
                            StaticResources.State.MainCharacter.TrySquence(Sequences.Spin, 1000, 200);
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
