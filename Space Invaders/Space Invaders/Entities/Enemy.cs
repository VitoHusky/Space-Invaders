using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Enemy : Entity
    {
        #region Private Variables
        private int MinX = 0;
        private int MaxX = 0;
        private int SpawnX = 0;
        private int SpawnY = 0;
        private int MovingDirection = 0;
        private Graphic graphic = null;
        #endregion

        enum MovingDirectons
        {
            DIR_LEFT,
            DIR_RIGHT
        }

        #region Constructor
        /// <summary>
        /// Creates the enemy depending on his Options
        /// </summary>
        /// <param name="x">The Spawn X Coordinate (Middle)</param>
        /// <param name="y">The Spawn Y Coordinate (Middle)</param>
        /// <param name="minx">The minimal X (for moving to the left and the right)</param>
        /// <param name="maxx">The maximal X (for moving to the left and the right)</param>
        public Enemy(int x, int y, int minx, int maxx)
            : base()
        {
            this.SpawnX = x;
            this.SpawnY = y;
            this.MinX = minx;
            this.MaxX = maxx;
            this.X = x;
            this.Y = y;
            graphic = Image.CreateRectangle(Dimensions.ENEMY_WIDTH, Dimensions.ENEMY_HEIGHT, Color.Red);
            graphic.CenterOrigin();
            SetGraphic(graphic);

        }
        #endregion

        #region Public Overrides
        public override void Update()
        {
            base.Update();

        }
        #endregion
    }
}
