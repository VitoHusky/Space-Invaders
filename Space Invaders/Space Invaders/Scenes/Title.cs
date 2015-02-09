using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Scenes
{
    class Title : Scene
    {
        private Text enterText = null;
        private int enterTextBlinkWait = 0;
        private bool enterTextShowState = true;

        public Title()
            : base()
        {
            Console.WriteLine("[Scene] Initiating \"Title\"");

            // Hintergrundbild
            Image backgroundImage = new Image(Assets.GRAPHIC_TITLE_BACKGROUND);
            AddGraphic(backgroundImage);

            // Enter Text
            enterText = new Text("Druecken Sie Enter \num das Spiel zu starten...", Assets.FONT_HOMINIS, 20);
            enterText.X = Game.Instance.HalfWidth;
            enterText.Y = Game.Instance.HalfHeight;
            enterText.CenterOrigin();
            this.AddGraphic(enterText);

            // Hintergrund Musik
            Global.Song_Title.Play();



            Console.WriteLine("[Scene] Initiated \"Title\"");
        }
        public override void Begin()
        {
            base.Begin();

            Console.WriteLine("[Scene] Scene \"Title\" hast begun.");
        }
        public override void End()
        {
            base.End();
            Console.WriteLine("[Scene] Scene \"Title\" hast end.");
        }
        public override void Update()
        {
            base.Update();

            // Blinktext
            enterTextBlinkWait++;
            if (enterTextBlinkWait >= 30)
            {
                Console.WriteLine("Blinktext gets visible inverted.");
                enterTextShowState = !enterTextShowState;
                enterText.Visible = enterTextShowState;
                enterTextBlinkWait = 0;
            }

            // Wurde eine Taste gedrückt?
            if (Global.PlayerOne.Controller.Start.Pressed)
            {
                Global.Song_Title.Stop();
                Game.Instance.RemoveScene();
                Game.Instance.AddScene(new Scenes.MainGame());
            }
        }
    }
}
