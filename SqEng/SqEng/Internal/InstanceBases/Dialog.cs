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
                SFMLText = new Text(message + "\nPress any key to continue.", StaticResources.CelestiaRedux);
                SFMLText.CharacterSize = 32;
                SFMLText.Position = new Vector2f(32, 128);
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

        public long cnt = 0;

        public void Tick()
        {
            unchecked{
                cnt += (long)Execution.DeltaTimeMS;
                double tmp = cnt / 200.0;
                r = (byte)(127 + 127 * Math.Sin(tmp));
                g = (byte)(127 + 127 * Math.Sin(Math.PI / 2 + tmp));
                b = (byte)(127 + 127 * Math.Sin(2.0 / 3.0 * Math.PI + tmp));
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
