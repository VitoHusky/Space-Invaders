using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders
{
    class LevelManager
    {
        private static LevelManager instance = null;
        public static LevelManager GetInstance()
        {
            if (instance == null)
                instance = new LevelManager();
            return instance;
        }

        #region Private Variables
        private Int16 CurrentLevel = 0;
        private Boolean RoundRunning = false;
        #endregion

        #region Public Methods
        public void Reset()
        {
            this.CurrentLevel = 1;
        }
        /// <summary>
        /// Checks the state of the running game
        /// </summary>
        /// <returns>RoundRunning variable</returns>
        public bool IsRunning()
        {
            return this.RoundRunning;
        }
        /// <summary>
        /// A function that initiats the new round and creates the enemies
        /// </summary>
        public void InitializeLevel()
        {
            if (!RoundRunning)
            {
                Console.WriteLine("[Level Manager]: Starting new Round. Current Level: " + this.CurrentLevel);
                RoundRunning = true;

                Int32 EnemiesCountX = Game.Instance.Width / (Dimensions.ENEMY_WIDTH + Dimensions.ENEMY_MARGIN);
                Int32 EnemiesCountY = Dimensions.ENEMY_FIELD_HEIGHT / (Dimensions.ENEMY_HEIGHT + Dimensions.ENEMY_MARGIN);
                Int32 EnemyWidth = Dimensions.ENEMY_WIDTH + Dimensions.ENEMY_MARGIN;
                Int32 EnemyHeight = Dimensions.ENEMY_HEIGHT + Dimensions.ENEMY_MARGIN;
                for (int y = 0; y < EnemiesCountY - Global.ENEMY_FREE_LINES; y++)
                {
                    for (int x = 0; x < EnemiesCountX; x++)
                    {
                        Int32 PosX = x * EnemyWidth + Dimensions.ENEMY_WIDTH / 2 + Dimensions.ENEMY_MARGIN / 2;
                        Int32 PosY = y * EnemyHeight + Dimensions.ENEMY_HEIGHT / 2 + Dimensions.ENEMY_MARGIN / 2;
                        EnemyManager.GetInstance().AddEnemy(PosX, PosY + Dimensions.GAME_INTERFACE_HEIGHT, (int)EnemyManager.EnemyTyps.ENEMY_TYPE_NORMAL, this.GetLevel());
                    }
                }

                Console.WriteLine("[Level Manager] Added " + EnemyManager.GetInstance().GetLivingEnemies() + " Enemies.");
            }
        }
        public Int16 GetLevel() 
        {
            return this.CurrentLevel;
        }
        public void IncreaseLevel()
        {
            this.CurrentLevel++;
        }
        #endregion
    }
}
