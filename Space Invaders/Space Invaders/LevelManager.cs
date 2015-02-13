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
                EnemyManager.GetInstance().SpawnEnemies(this.GetLevel());
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
        public void StopLevel()
        {
            EnemyManager.GetInstance().KillAllEnemies();
            this.RoundRunning = false;
        }
        #endregion
    }
}
