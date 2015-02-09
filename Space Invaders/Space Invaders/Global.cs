using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders
{
    class Global
    {
        public static Session PlayerOne = null;
        public static Session PlayerTwo = null;

        public static int Weapon_Cooldown = 0;
        public const int GAME_INTERFACE_HEIGHT = 40;

        public static Music Song_Title = new Music(Assets.SOUND_TITLE_MUSIC, true);

        public delegate void EmptyDelegate();

        public enum WEAPON_TYPES{
            MACHINE_GUN = 1,
            DOUBLE_MACHINE_GUN,
            ROCKET_LAUNCHER
        }
    }
}
