using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;

namespace SqEng.Internal
{
    public static class Sound
    {
        public static List<Music> Sounds = new List<Music>();

        public static void StopAll()
        {
            foreach (Music m in Sounds)
                m.Stop();
            Sounds.Clear();
        }

        public static void Play(string name, float volume = 100)
        {
            Sounds.Add(new Music("data/sounds/" + name + ".ogg") { Volume = volume });
            Sounds.Last().Play();
        }

        public static void Loop(string name, float volume = 100)
        {
            Sounds.Add(new Music("data/sounds/" + name + ".ogg") { Loop = true, Volume = volume  });
            Sounds.Last().Play();
        }
    }
}
