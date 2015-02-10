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
            //Game game = new Game("Space Invaders", 640, 480, 60, false);
            Game game = new Game("Space Invaders", 1200, 600, Global.GAME_FRAMES, false);

            Global.PlayerOne = game.AddSession("PlayerOne");
            Global.PlayerOne.Controller.Left.AddKey(Key.Left);
            Global.PlayerOne.Controller.Right.AddKey(Key.Right);
            Global.PlayerOne.Controller.Start.AddKey(Key.Return);
            Global.PlayerOne.Controller.X.AddKey(Key.LControl);
            Global.PlayerOne.Controller.Circle.AddKey(Key.Space);

            /*Global.PlayerTwo = game.AddSession("PlayerTwo");
            Global.PlayerTwo.Controller.Left.AddKey(Key.A);
            Global.PlayerTwo.Controller.Right.AddKey(Key.D);
            Global.PlayerTwo.Controller.X.AddKey(Key.W);
            Global.PlayerTwo.Controller.Circle.AddKey(Key.S);*/

            game.FirstScene = new Scenes.Title();
            game.Start();
        }

        private static void AssignKeysToPlayer(Session player)
        {
            
        }
    }
}
