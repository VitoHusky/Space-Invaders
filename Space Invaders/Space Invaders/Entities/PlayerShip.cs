using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class PlayerShip : Entity
    {
        #region Private Variables
        private Text RocketText = new Text(20);

        private Image MainModel = new Image(Assets.GRAPHIC_PLAYER_SHIP_1);
        private Session PlayerSession = null;
        private float BaseY = 0;
        private const int BAR_WIDTH = 50;
        private Image HealthBar = null;
        private Image WeaponPrimaryBar = null;
        private Random rand = new Random();
        private Int16 ShipLevel = 0;

        private Double MaxHealth = 100;
        private Double CurrentHealth = 100;

        // Weapons
        private Weapon_Primary WeaponPrimary = new Weapon_Primary();
        private Weapon_Secondary WeaponSecondary = new Weapon_Secondary();

        // Upgrades
        private Int32 Upgrade_Invincible_Time = 0;
        #endregion

        #region Public Variables
        private float speed = 3.0f;
        public float Speed
        {
            get { return this.speed; }
            set
            {
                if (this.speed <= 0)
                    this.speed = 3.0f;
                else if (this.speed > 5.0f)
                    this.speed = 5.0f;
                else this.speed += value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create the player ship in the middle of the game screen
        /// </summary>
        /// <param name="session">the player session of the player who is controling the ship.</param>
        public PlayerShip(Session session)
            : base()
        {
            this.PlayerSession = session;
            Global.PlayerShipsAlive++;

            this.X = Game.Instance.HalfWidth;
            this.Y = Game.Instance.Height - MainModel.HalfHeight - 20;
            this.BaseY = this.Y;
            WeaponSecondary.GiveAmmo(5);

            this.Upgrade();


            //Scene.Instance.Add(new Interface_Healthbar(0, 0, this));
        }
        #endregion

        #region Private Methods
        private void Destroy()
        {
            Global.PlayerShipsAlive--;
            Scene.Add(new Effects_Explosion(this.X, this.Y));
            this.RemoveSelf();
        }
        #endregion

        #region Public Overrides
        /// <summary>
        /// Update Function for key handling.
        /// </summary>
        public override void Update()
        {
            base.Update();
            #region Movement Controls
            // Move to the left
            if (this.PlayerSession.Controller.Left.Down)
            {
                if (this.X > this.Speed + MainModel.HalfWidth)
                    this.X -= this.Speed;
            }
            // Move to the right
            else if (this.PlayerSession.Controller.Right.Down)
            {
                if (this.X < Game.Instance.Width - MainModel.HalfWidth - this.Speed)
                    this.X += this.Speed;
            }
            else if (this.PlayerSession.Controller.B.Down)
            {
                this.Destroy();
            }
            #endregion
            #region Ship Based Displays
            RocketText.String = WeaponSecondary.GetAmmo().ToString("00");
            RocketText.X = this.X + this.MainModel.HalfWidth;
            RocketText.Y = this.Y - this.MainModel.HalfHeight;

            // Healthbar
            if (this.Upgrade_Invincible_Time == 0)
            {
                HealthBar = Image.CreateRectangle((int)(BAR_WIDTH * this.GetHealthPercent() / 100), 10, Color.Red);
            }
            else 
            {
                HealthBar = Image.CreateRectangle((int)(BAR_WIDTH), 10, Color.Blue);
            }
            HealthBar.X = this.X - this.MainModel.HalfWidth - BAR_WIDTH;
            HealthBar.Y = this.Y - this.MainModel.HalfHeight;

            WeaponPrimaryBar = Image.CreateRectangle((int)(BAR_WIDTH * this.WeaponPrimary.GetLevelPercent() / 100), 10, Color.Green);
            WeaponPrimaryBar.X = this.X - this.MainModel.HalfWidth - BAR_WIDTH;
            WeaponPrimaryBar.Y = this.Y - this.MainModel.HalfHeight + 15;
            #endregion
            #region Weapon Controls
            // Shoot the Primary Weapon
            if (this.PlayerSession.Controller.A.Down)
            {
                this.WeaponPrimary.Shoot(this.X, this.Y);
                
            }
            // Shoot the Secondary Weapon
            if (this.PlayerSession.Controller.X.Down)
            {
                this.WeaponSecondary.Shoot(this.X, this.Y);
                //this.WeaponPrimary.Upgrade();
            }
            #endregion
            #region Collisions
            PickupManager.Instance.CheckCollide(this);

            if (this.Upgrade_Invincible_Time != 0)
            {
                var collb = Collider.Collide(X, Y, (int)Global.HIT_TYPES.PRIMARY_SHOT);
                if (collb != null)
                {
                    Weapon_Primary_Shot weapon = (Weapon_Primary_Shot)collb.Entity;
                    if (weapon.IsBotWeapon())
                    {
                        weapon.Destroy();
                        this.CurrentHealth -= weapon.GetDamage();
                        if (this.CurrentHealth <= 0)
                        {
                            this.Destroy();
                            return;
                        }
                    }
                }
            }
            
            /*
            var collb = Collider.Collide(X, Y, (int)Global.HIT_TYPES.PRIMARY_SHOT);
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
                        Scene.Add(new Pickup(this.X, this.Y, (Int16)Global.PICKUPTYPES.UPGRADE_WEAPON_PRIMARY));
                        return;
                    }
                }
            }*/
            #endregion
            #region Times
            if (this.Upgrade_Invincible_Time > 0)
                this.Upgrade_Invincible_Time--;
            #endregion
        }
        /// <summary>
        /// Override of the render function to draw the Rocket Count next to the ship
        /// </summary>
        public override void Render()
        {
            base.Render();
            Draw.Graphic(HealthBar);
            Draw.Graphic(WeaponPrimaryBar);
            Draw.Graphic(RocketText);
        }
        #endregion

        #region Public Methods
        public void Upgrade()
        {
            if (this.ShipLevel != 3)
            {
                this.ShipLevel++;
                switch (this.ShipLevel)
                {
                    case 1:
                        this.MainModel = new Image(Assets.GRAPHIC_PLAYER_SHIP_1);
                        break;
                    case 2:
                        this.MainModel = new Image(Assets.GRAPHIC_PLAYER_SHIP_2);
                        break;
                    case 3:
                        this.MainModel = new Image(Assets.GRAPHIC_PLAYER_SHIP_3);
                        break;
                }
                this.MainModel.CenterOrigin();
                this.Graphic = this.MainModel;

                SetHitbox((int)this.MainModel.HalfWidth, (int)this.MainModel.HalfHeight, (int)Global.HIT_TYPES.PLAYER_SHIP);
            }
        }
        public void SetCurrentHealth(Double val)
        {
            this.CurrentHealth = val;
        }
        public Double GetHealthCurrent()
        {
            return this.CurrentHealth;
        }
        public Weapon_Primary GetWeaponPrimary()
        {
            return this.WeaponPrimary;
        }
        public Weapon_Secondary GetWeaponSecondary()
        {
            return this.WeaponSecondary;
        }
        public Double GetHealthMax()
        {
            return this.MaxHealth;
        }
        public Double GetHealthPercent()
        {
            return this.CurrentHealth * 100 / this.MaxHealth;
        }
        public void IncreaseHealth(Int32 val)
        {
            this.CurrentHealth += val;
            if (this.CurrentHealth > this.GetHealthMax())
                this.CurrentHealth = this.GetHealthMax();
        }

        public void SetInvincible(bool mode)
        {
            if (mode)
            {
                this.Upgrade_Invincible_Time = Global.TIME_UPGRADE_INVINCIBLE;
            }
            else
            {
                this.Upgrade_Invincible_Time = 0;
            }
        }
        #endregion
    }
}
