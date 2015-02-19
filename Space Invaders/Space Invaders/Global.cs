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
        public static Entities.CameraShaker camShaker = new Entities.CameraShaker();

        public static Boolean GameRunning = false;
        public static Int32 PlayerShipsAlive = 0;
        public static int KilledEnemies = 0;

        public const Double DAMAGE_ENEMY_LIVE_PER_LEVEL = 30;
        public const Double DAMAGE_WEAPON_PER_LEVEL = 12.5;

        public const Int32 TIME_TILL_FIRST_ROUND = 100;
        public const Int32 TIME_TILL_NEXT_ROUND = 150;
        public const Int32 TIME_UPGRADE_INVINCIBLE = 5000;

        public const Int32 SCORE_PER_ENEMY = 10;

        public const Int32 GAME_FRAMES = 60;

        public static Int32 Score = 0;

        public const Int32 ENEMY_FREE_LINES = 2;

        public const Int32 SPEED_PICKUP_MAX = 5;

        public static Music Song_Title = new Music(Assets.SOUND_TITLE_MUSIC, true);

        public delegate void EmptyDelegate();

        public enum WEAPON_TYPES{
            MACHINE_GUN = 1,
            ROCKET_LAUNCHER
        }
        
        public enum HIT_TYPES
        {
            ENEMY = 1,

            PLAYER_SHIP,

            PRIMARY_SHOT,

            PICKUP
        }
    }
}
