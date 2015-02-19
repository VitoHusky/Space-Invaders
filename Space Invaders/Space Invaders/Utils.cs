using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Otter;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Utils
    {
        public static void PlaySound(string path)
        {
            Sound sound = new Sound(path);
            sound.Play();
        }
    }
}
