using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Space Invaders", 720, 480, 60, false);
            game.FirstScene = new Scenes.Menue();
            game.Start();
        }
    }
}
