using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal
{
    public enum Sequences
    {
        Spin,
        SwimLeft,
        SwimRight,
        SharkLeft,
        SharkRight,
        Default
    }
    public class Sequence
    {
        public DateTime Start;
        public int LengthMS;
        public int TimeoutMS;
        public bool InTimeout
        {
            get
            {
                return (DateTime.Now - Start).TotalMilliseconds >= LengthMS;
            }
        }

        public bool Active
        {
            get
            {
                return (DateTime.Now - Start).TotalMilliseconds <= LengthMS + TimeoutMS;
            }
        }
        public Sequences Seq;
        public Sequence(Sequences seq, int lengthMS, int timeoutMS)
        {
            Start = DateTime.Now;
            Seq = seq;
            LengthMS = lengthMS;

            switch (Seq)
            {
                case Sequences.Spin:
                    Sound.Play("player/spin" + Helpers.Rnd.Next(1, 2));
                    break;
            }
        }

    }
}
