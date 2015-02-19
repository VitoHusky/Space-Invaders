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
        private int Round_Countdown = Global.TIME_TILL_FIRST_ROUND;
        private Boolean FirstRun = true;
        private Sound Music = new Sound(Assets.SOUND_GAME_MUSIC[0]);

        Entities.TextObject Text_Score = null;
        Entities.TextObject Text_Level = null;
        Entities.TextObject Text_Countdown = null;
        Entities.TextObject Text_Enemies = null;
        Entities.TextObject Text_BigInfo = null;
        

        private LevelManager LManager = LevelManager.GetInstance();

        
        public MainGame()
            : base()
        {
            Console.WriteLine("[Scene] Initiating \"MainGame\"");

            // Reset Variables
            Global.Score = 0;
            LManager.Reset();
            Music.Play();

            this.rand = new Random();
            Global.GameRunning = true;

            Add(new Entities.MainLine(Game.Instance.Width, 1, 0, Dimensions.GAME_INTERFACE_HEIGHT, Color.White));
            int fieldWidth = Game.Instance.Width * 33 / 100;
            Add(new Entities.MainLine(1, Dimensions.GAME_INTERFACE_HEIGHT, fieldWidth, 0, Color.White));
            Add(new Entities.MainLine(1, Dimensions.GAME_INTERFACE_HEIGHT, Game.Instance.Width - fieldWidth, 0, Color.White));

            Add(new Entities.MainLine(Game.Instance.Width, 5, 0, Game.Instance.Height - Dimensions.GAME_PLAYER_SPACE, Color.Green));

            Add(new Entities.PlayerShip(Global.PlayerOne));
            //Add(new Entities.PlayerShip(Global.PlayerTwo));

            Add(Global.camShaker);


            Text_Score = new Entities.TextObject("Score: --", fieldWidth / 2, 2, null, 24);
            Text_Countdown = new Entities.TextObject("Countdown", Game.Instance.Width / 2, Game.Instance.Height / 2, null, 24);
            Text_BigInfo = new Entities.TextObject("", Game.Instance.Width / 2, Game.Instance.Height / 2, null, 60);
            Text_Countdown.CenterOriginY();
            Text_Enemies = new Entities.TextObject("Gegner: --", fieldWidth + fieldWidth / 2, 2, null, 24);
            Text_Level = new Entities.TextObject("Level: --", 2 * fieldWidth + fieldWidth / 2, 2, null, 24);
            Add(Text_Score);
            Add(Text_Enemies);
            Add(Text_Countdown);
            Add(Text_Level);

            Console.WriteLine("[Scene] Initiated \"MainGame\"");
        }

        public override void Update()
        {
            base.Update();
            if (Global.GameRunning)
            {
                if (this.rand.Next(0, 100) % 3 == 0)
                    Add(new Entities.StarLine(this.rand.Next(0, Game.Instance.Width)));
                if (!LManager.IsRunning())
                {
                    Round_Countdown--;

                    if (Round_Countdown == 0)
                    {
                        Remove(Text_Countdown);
                        if (FirstRun) FirstRun = false;
                        else Remove(Text_BigInfo);
                        LManager.InitializeLevel();
                    }
                    else
                    {
                        if (FirstRun)
                            Text_Countdown.SetString("Game starts in\n" + (Round_Countdown / Global.GAME_FRAMES + 1));
                        else
                            Text_Countdown.SetString("Next round starts in\n" + (Round_Countdown / Global.GAME_FRAMES + 1));
                    }


                }
                else
                {
                    if (EnemyManager.GetInstance().GetLivingEnemies() == 0)
                    {
                        Add(Text_BigInfo);
                        Add(Text_Countdown);
                        LManager.StopLevel();
                        LManager.IncreaseLevel();
                        Text_BigInfo.SetString("LEVEL COMPLETED\nNext Level: " + LManager.GetLevel());
                        Round_Countdown = Global.TIME_TILL_NEXT_ROUND;
                        Utils.PlaySound(Assets.SOUND_LEVELUP);
                    }
                    else if (Global.PlayerShipsAlive == 0)
                    {
                        Add(Text_BigInfo);
                        LManager.StopLevel();
                        Text_BigInfo.SetString("GAMEOVER\nGetoetete Gegner: " + Global.KilledEnemies + "\n \nDruecke Start um zum Menue zu gelangen.");
                        Global.GameRunning = false;
                    }
                }
                Text_Score.SetString("Score: " + Global.Score.ToString("000000"));
                Text_Level.SetString("Level: " + LManager.GetLevel().ToString("00"));
                Text_Enemies.SetString("Gegner: " + EnemyManager.GetInstance().GetLivingEnemies().ToString("00"));
            }
            else
            {
                if (Global.PlayerOne.Controller.Start.Pressed)
                {
                    Game.Instance.RemoveScene();
                    Game.Instance.AddScene(new Scenes.Title());
                }
            }
        }
    }
}