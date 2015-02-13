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
        private Int32 MinX = 0;
        private Int32 MaxX = 0;
        private Int32 SpawnX = 0;
        private Int32 SpawnY = 0;
        private Int32 Width = 0;
        private Int32 Height = 0;
        private int MovingDirection = 0;
        private Int32 Level = 0;
        private Graphic graphic = null;
        private Text HealthText = new Text(20);

        private Double MaximalHealth = 100;
        private Double CurrentHealth = 100;

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
        public Enemy(int x, int y, int minx, int maxx, int level)
            : base()
        {
            this.SpawnX = x;
            this.SpawnY = y;
            this.MinX = minx;
            this.MaxX = maxx;
            this.Width = Dimensions.ENEMY_WIDTH;
            this.Height = Dimensions.ENEMY_HEIGHT;
            this.X = x;
            this.Y = y;

            this.Level = level;
            graphic = Image.CreateRectangle(this.Width, this.Height, Color.Red);
            graphic.CenterOrigin();
            SetGraphic(graphic);

            // Health
            this.CurrentHealth = level * Global.DAMAGE_ENEMY_LIVE_PER_LEVEL;
            this.MaximalHealth = this.CurrentHealth;

            // Create the Collidor
            BoxCollider col = new BoxCollider(this.Width, this.Height, (int)Global.HIT_TYPES.ENEMY);
            col.CenterOrigin();
            this.SetCollider(col);
        }
        #endregion

        #region Public Methods
        public void Destroy()
        {
            Global.Score += Global.SCORE_PER_ENEMY * this.Level;
            this.RemoveSelf();
        }
        #endregion

        #region Public Overrides
        public override void Update()
        {
            base.Update();
            
            // Primary Weapon Collision
            var collb = Collider.Collide(X,Y, (int)Global.HIT_TYPES.PRIMARY_SHOT);
            if (collb != null)
            {
                Weapon_Primary_Shot b = (Weapon_Primary_Shot)collb.Entity;
                b.Destroy();
                this.CurrentHealth -= b.GetDamage();
                if (this.CurrentHealth <= 0)
                {
                    this.Destroy();
                    EnemyManager.GetInstance().Remove(this);
                    Scene.Add(new Pickup(this.X, this.Y, (Int16)Global.PICKUPTYPES.UPGRADE_WEAPON_PRIMARY));
                    return;
                }
            }

            #region Enemy Based display
            Int32 percent = Convert.ToInt32(CurrentHealth * 100 / MaximalHealth);
            HealthText.String = percent.ToString("00") + " %";
            HealthText.X = this.X - this.Width / 2;
            HealthText.Y = this.Y + this.Height / 2;
            #endregion
        }

        public override void Render()
        {
            base.Render();
            Draw.Graphic(HealthText);
        }
        #endregion
    }
}
