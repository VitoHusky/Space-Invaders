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
            Entities.Enemy Enemy = new Entities.Enemy(x, y, x, y);
            this.Enemies.Add(Enemy);
            Game.Instance.Scene.Add(Enemy);
        }

        public Int32 GetLivingEnemies()
        {
            return this.Enemies.Count;
        }
    }
}
