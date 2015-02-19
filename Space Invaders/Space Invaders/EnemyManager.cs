using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders
{
    class EnemyManager
    {
        private static EnemyManager instance = null;
        public static EnemyManager GetInstance()
        {
            if (instance == null)
                instance = new EnemyManager();
            return instance;
        }

        #region Private Variables
        private List<Entities.Enemy> Enemies = new List<Entities.Enemy>();
        #endregion
        public enum EnemyTyps
        {
            ENEMY_TYPE_NORMAL
        }

        public EnemyManager()
        {

        }

        /// <summary>
        /// Adds an Enemy to the Scene and to the Manager management list
        /// </summary>
        /// <param name="x">The Spawn X Coordinate (Middle)</param>
        /// <param name="y">The Spawn Y Coordinate (Middle)</param>
        /// <param name="type">The Type (Normal Enemy, boss)</param>
        /// <param name="level">The level of the enemy (for calculating the health)</param>
        public void AddEnemy(int x, int y, int type, int level)
        {
            //Console.WriteLine("[Enemy Manager]: Adding Enemy. Level: [" + level + "] x: [" + x + "] y: [" + y + "] Type: [" + type + "]");
            Entities.Enemy Enemy = new Entities.Enemy(x, y, x - Dimensions.ENEMY_MARGIN / 2, x + Dimensions.ENEMY_MARGIN / 2, level);
            this.Enemies.Add(Enemy);
            Game.Instance.Scene.Add(Enemy);
        }

        public void Remove(Entities.Enemy en)
        {
            this.Enemies.Remove(en);
        }
    
        /// <summary>
        /// Spawns all Enemies depending on the level
        /// </summary>
        /// <param name="level">The level of the Enemy</param>
        public void SpawnEnemies(Int32 level)
        {
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
                    EnemyManager.GetInstance().AddEnemy(PosX, PosY + Dimensions.GAME_INTERFACE_HEIGHT, (int)EnemyManager.EnemyTyps.ENEMY_TYPE_NORMAL, level);
                }
            }
        }


        public void KillAllEnemies()
        {
            foreach (Entities.Enemy en in this.Enemies)
            {
                en.Destroy();
            }
            this.Enemies.Clear();
        }
        public Int32 GetLivingEnemies()
        {
            return this.Enemies.Count;
        }
    }
}
