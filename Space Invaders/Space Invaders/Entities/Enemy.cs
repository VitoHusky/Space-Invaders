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
        private Speed speed = new Speed(10);
        private Int32 Level = 0;
        private Graphic graphic =  new Image(Assets.GRAPHIC_ENEMY_SHIP);
        private Graphic HealthBarBackground = null;
        //private Graphic HealthBarValue = null;
        private Weapon_Primary weapon = new Weapon_Primary();

        private Random rand = new Random();

        private Double MaximalHealth = 100;
        private Double CurrentHealth = 100;

        #endregion

        enum MovingDirectons
        {
            DIR_LEFT = 1,
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
            : base(x, 0)
        {
            // Koordianten. Ursprung und minimal und Maximal Position
            this.SpawnX = x;
            this.SpawnY = y;
            this.MinX = minx;
            this.MaxX = maxx;
            // Höhe und Breite festlegen
            this.Width = Dimensions.ENEMY_WIDTH;
            this.Height = Dimensions.ENEMY_HEIGHT;
            this.Y -= Game.Instance.Height;
            // Healthbar
            this.HealthBarBackground = Image.CreateRectangle(this.Width, 5, Color.White);
            //this.HealthBarValue = Image.CreateRectangle(this.Width, 5, Color.Red);
            //
            this.weapon.SetBotWeapon(true);

            // X Bwegung
            speed.X = Rand.Float(0.1f, level * 0.1f);
            if (speed.X > 3.0)
                speed.X = 3.0f;
            speed.Y = 0.1f;

            if (rand.Next(1, 2) == 1)
                this.MovingDirection = (int)MovingDirectons.DIR_LEFT;
            else
                this.MovingDirection = (int)MovingDirectons.DIR_RIGHT;

            this.Level = level;
            //graphic = Image.CreateRectangle(this.Width, this.Height, Color.Red);
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
            Scene.Add(new Effects_Explosion(this.X, this.Y));
            this.RemoveSelf();
        }
        #endregion

        #region Public Overrides
        public override void Update()
        {
            base.Update();

            // Moving
            if (this.Y >= SpawnY)
            {

                if (this.MovingDirection == (int)MovingDirectons.DIR_LEFT)
                {
                    this.X -= speed.X;
                    if (this.X < this.MinX)
                        this.MovingDirection = (int)MovingDirectons.DIR_RIGHT;
                }
                else
                {
                    this.X += speed.X;
                    if (this.X > this.MaxX)
                        this.MovingDirection = (int)MovingDirectons.DIR_LEFT;
                }
                if (rand.Next(1, 30) == 10)
                    this.Y += speed.Y;
            }
            else
            {
                // Reinfliegen
                this.Y += 3.0f;
            }
            
            // Primary Weapon Collision
            var collb = Collider.Collide(X,Y, (int)Global.HIT_TYPES.PRIMARY_SHOT);
            if (collb != null)
            {
                Weapon_Primary_Shot b = (Weapon_Primary_Shot)collb.Entity;
                if (!b.IsBotWeapon())
                {
                    b.Destroy();
                    this.CurrentHealth -= b.GetDamage();
                    if (this.CurrentHealth <= 0)
                    {
                        this.Destroy();
                        EnemyManager.GetInstance().Remove(this);

                        PickupManager.Instance.SpawnRandomUpgrade(this.X, this.Y);
                        Global.KilledEnemies++;
                        return;
                    }
                }
            }

            // Chance ist 1 zu 2500, dass der Bot schießt
            if (Rand.Int(1, 2500) == 1)
            {
                weapon.Shoot(this.X, this.Y);
            }

            #region Enemy Based display
            Int32 percent = Convert.ToInt32(CurrentHealth * 100 / MaximalHealth);
            
            //HealthText.String = percent.ToString("00") + " %";
            HealthBarBackground = Image.CreateRectangle(this.Width * percent / 100, 5, Color.Red);
            HealthBarBackground.X = this.X - this.Width / 2;
            HealthBarBackground.Y = this.Y + this.Height / 2;
            /*
            HealthBarValue = Image.CreateRectangle(this.Width / 100 * percent, 5, Color.Red);
            HealthBarValue.X = this.X - this.Width / 2 + (this.Width / 100 * (100 - percent));
            HealthBarValue.Y = this.Y + this.Height / 2;*/
            
            //HealthBarValue.Width = this.Width - this.X;

            //HealthBarBackground
            #endregion
        }

        public override void Render()
        {
            base.Render();
            // Draw.Graphic(HealthBarValue);
            Draw.Graphic(HealthBarBackground);
            
        }
        #endregion
    }
}
