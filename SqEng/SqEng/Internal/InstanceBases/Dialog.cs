using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

namespace SqEng.Internal.InstanceBases
{
    public class Dialog
    {
        public static Font CelestiaRedux = new Font("data/bin/celestiaredux.ttf");

        public bool Active;
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                SFMLText = new Text(message + "\nPress any key to continue.", CelestiaRedux);
                SFMLText.CharacterSize = 25;
            }
        }

        public Text SFMLText;

        public Dialog(string message)
        {
            Message = message;
        }

        public void Activate(string message)
        {
            Message = message;
            Active = true;
        }

        public byte r = 0;
        public byte g = 0;
        public byte b = 0;

        public void Tick()
        {
            unchecked{
                r += (byte)Helpers.Rnd.Next(0, 10);
                g += (byte)Helpers.Rnd.Next(1, 11);
                b += (byte)Helpers.Rnd.Next(2, 12);
            }
            SFMLText.Color = new Color(r, g, b);
        }

        public void KeyPress()
        {
            if (Next != null)
            {
                Message = Next.Message;
                Next = Next.Next;
            }
            else
            {
                Active = false;
            }
        }

        public Dialog Next;
    }
}
