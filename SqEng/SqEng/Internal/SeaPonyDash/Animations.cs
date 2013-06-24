using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.SeaPonyDash
{
    public static class Animations
    {
        public static Internal.Animation.Animation Spinny = new Internal.Animation.Animation("spin");
        public static Internal.Animation.Animation Idle = new Internal.Animation.Animation("idle");

        public static Internal.Animation.Animation  t{get{return new Internal.Animation.Animation("t");}}
        public static Internal.Animation.Animation tr{get{return new Internal.Animation.Animation("tr");}}
        public static Internal.Animation.Animation  r{get{return new Internal.Animation.Animation("r");}}
        public static Internal.Animation.Animation br{get{return new Internal.Animation.Animation("br");}}
        public static Internal.Animation.Animation  b{get{return new Internal.Animation.Animation("b");}}
        public static Internal.Animation.Animation bl{get{return new Internal.Animation.Animation("bl");}}
        public static Internal.Animation.Animation  l{get{return new Internal.Animation.Animation("l");}}
        public static Internal.Animation.Animation tl{get{return new Internal.Animation.Animation("tl");}}
        public static Internal.Animation.Animation  c{get{return new Internal.Animation.Animation("c");}}

    }
}
