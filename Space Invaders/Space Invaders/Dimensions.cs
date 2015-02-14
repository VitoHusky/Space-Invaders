using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders
{
    class Dimensions
    {
        // Game Sizes
        public const Int32 GAME_INTERFACE_HEIGHT = 40;
        public const Int32 GAME_PLAYER_SPACE = 100;

        // Enemies
        public const Int32 ENEMY_WIDTH = 42;
        public const Int32 ENEMY_MARGIN = 20;
        public const Int32 ENEMY_HEIGHT = 46;
        public static Int32 ENEMY_FIELD_HEIGHT
        {
            get { return Game.Instance.Height - GAME_INTERFACE_HEIGHT - GAME_PLAYER_SPACE; }
        }
    }
}
