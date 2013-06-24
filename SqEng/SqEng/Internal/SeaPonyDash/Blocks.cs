using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.SeaPonyDash
{
    public static class Blocks
    {
        public static Internal.SeaPonyDash.Actor t { get  { return new Internal.SeaPonyDash.Actor("t"); } }
        public static Internal.SeaPonyDash.Actor tr { get { return new Internal.SeaPonyDash.Actor("tr"); } }
        public static Internal.SeaPonyDash.Actor r { get  { return new Internal.SeaPonyDash.Actor("r"); } }
        public static Internal.SeaPonyDash.Actor br { get { return new Internal.SeaPonyDash.Actor("br"); } }
        public static Internal.SeaPonyDash.Actor b { get  { return new Internal.SeaPonyDash.Actor("b"); } }
        public static Internal.SeaPonyDash.Actor bl { get { return new Internal.SeaPonyDash.Actor("bl"); } }
        public static Internal.SeaPonyDash.Actor l { get  { return new Internal.SeaPonyDash.Actor("l"); } }
        public static Internal.SeaPonyDash.Actor tl { get { return new Internal.SeaPonyDash.Actor("tl"); } }
        public static Internal.SeaPonyDash.Actor c { get { return new Internal.SeaPonyDash.Actor("c") { Type = ActorType.Rock }; } }
    }
}
