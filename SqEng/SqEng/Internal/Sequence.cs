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
                double dt = (DateTime.Now - Start).TotalMilliseconds;
                return dt >= LengthMS && dt <= LengthMS + TimeoutMS;
            }
        }

        public bool Running
        {
            get
            {
                return (DateTime.Now - Start).TotalMilliseconds <= LengthMS + TimeoutMS;
            }
        }
        private Sequences seq;
        public Sequences Seq
        {
            get
            {
                return InTimeout ? Sequences.Default : seq;
            }
            set
            {
                seq = value;
            }
        }

        public Sequence(Sequences seq, int lengthMS, int timeoutMS)
        {
            Start = DateTime.Now;
            Seq = seq;
            LengthMS = lengthMS;
            TimeoutMS = timeoutMS;

            switch (Seq)
            {
                case Sequences.Spin:
                    Sound.Play("player/spin" + Helpers.Rnd.Next(1, 2));
                    break;
            }
        }

    }
}
