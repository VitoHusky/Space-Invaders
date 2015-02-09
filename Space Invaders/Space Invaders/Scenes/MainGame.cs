using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Scenes
{
    class MainGame : Scene
    {
        private Random rand = null;

        public MainGame()
            : base()
        {
            Console.WriteLine("[Scene] Initiating \"MainGame\"");

            this.rand = new Random();

            Add(new Entities.MainLine(Game.Instance.Width, 1, 0, Global.GAME_INTERFACE_HEIGHT, Color.White));
            int fieldWidth = Game.Instance.Width * 33 / 100;
            Add(new Entities.MainLine(1, Global.GAME_INTERFACE_HEIGHT, fieldWidth, 0, Color.White));
            Add(new Entities.MainLine(1, Global.GAME_INTERFACE_HEIGHT, Game.Instance.Width - fieldWidth, 0, Color.White));

            Add(new Entities.MainLine(Game.Instance.Width, 5, 0, Game.Instance.Height - 20, Color.Green));

            Add(new Entities.PlayerShip(Global.PlayerOne));
            //Add(new Entities.PlayerShip(Global.PlayerTwo));


            Entity Text_Score = new Entities.TextObject("Score: --", fieldWidth / 2, 2, null, 24);
            Entity Text_Enemies = new Entities.TextObject("Gegner: --", fieldWidth + fieldWidth / 2, 2, null, 24);
            Entity Text_Test2 = new Entities.TextObject("Leben: --", 2 * fieldWidth + fieldWidth / 2, 2, null, 24);
            Add(Text_Score);
            Add(Text_Enemies);
            Add(Text_Test2);

            Console.WriteLine("[Scene] Initiated \"MainGame\"");
        }

        public override void Update()
        {
            base.Update();
            if (this.rand.Next(0, 100) % 3 == 0)
                Add(new Entities.StarLine(this.rand.Next(0, Game.Instance.Width)));
        }
    }
}