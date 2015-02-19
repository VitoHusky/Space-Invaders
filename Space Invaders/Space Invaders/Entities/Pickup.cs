using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Pickup : Entity
    {
        #region Private Variables
        private Int16 PickupType = 0;
        private Image img = null;
        private Speed speed = null;
        #endregion
        #region Public Variables
        #endregion

        #region Constructor
        public Pickup(float x, float y, Int16 type)
            : base(x, y)
        {
            this.PickupType = type;
            switch (type)
            {
                case (int)PickupManager.PICKUPTYPES.UPGRADE_WEAPON_PRIMARY:
	                img = new Image(Assets.GRAPHIC_PICKUP_UPGRADE_WEAPON_PRIMARY);
	                break;
                case (int)PickupManager.PICKUPTYPES.AMMO_ROCKET:
	                img = new Image(Assets.GRAPHIC_PICKUP_AMMO_ROCKET);
	                break;
                case (int)PickupManager.PICKUPTYPES.POWERUP_INV:
	                img = new Image(Assets.GRAPHIC_PICKUP_POWERUP_INV);
	                break;
                case (int)PickupManager.PICKUPTYPES.POWERUP_HEALTH:
	                img = new Image(Assets.GRAPHIC_PICKUP_POWERUP_HEALTH);
	                break;
                case (int)PickupManager.PICKUPTYPES.POWERUP_LEVEL_UP:
	                img = new Image(Assets.GRAPHIC_PICKUP_POWERUP_LEVEL_UP);
	                break;
                case (int)PickupManager.PICKUPTYPES.POWERUP_PLAYER_SHIP:
	                img = new Image(Assets.GRAPHIC_PICKUP_POWERUP_PLAYER_SHIP);
	                break;
                case (int)PickupManager.PICKUPTYPES.DEGRADE_WEAPON_PRIMARY:
	                img = new Image(Assets.GRAPHIC_PICKUP_DEGRADE_WEAPON_PRIMARY);
	                break;
                case (int)PickupManager.PICKUPTYPES.AMMO_ROCKET_LOOSE:
	                img = new Image(Assets.GRAPHIC_PICKUP_AMMO_ROCKET_LOOSE);
	                break;
                case (int)PickupManager.PICKUPTYPES.DEGRADE_50HEALTH:
	                img = new Image(Assets.GRAPHIC_PICKUP_DEGRADE_50HEALTH);
	                break;
                case (int)PickupManager.PICKUPTYPES.UPGRADE_SPEED:
	                img = new Image(Assets.GRAPHIC_PICKUP_UPGRADE_SPEED);
	                break;
                case (int)PickupManager.PICKUPTYPES.DEGRAGE_SPEED:
	                img = new Image(Assets.GRAPHIC_PICKUP_DEGRADE_SPEED);
	                break;

                default:
                    img = Image.CreateRectangle(5, Color.Red);
                    break;
            }
            this.X = x;
            this.Y = y;
            this.speed = new Speed(Global.SPEED_PICKUP_MAX);
            this.speed.Y = Rand.Int(2, Global.SPEED_PICKUP_MAX);
            img.CenterOrigin();
            this.SetGraphic(img);

            CircleCollider col = new CircleCollider((int)this.img.HalfWidth, (int)Global.HIT_TYPES.PICKUP);
            col.CenterOrigin();
            this.AddCollider(col);
            
        }
        #endregion
        #region Public Overrrdes
        public override void Update()
        {
            base.Update();

            this.Y += speed.Y;
            if (this.Y > Game.Instance.Height)
                this.RemoveSelf();
        }
        #endregion 
        #region Public Functions
        public void OnPickup(PlayerShip ship)
        {
            Utils.PlaySound(Assets.SOUND_EFFECTS_PICKUP_PICKUP);
            switch (this.PickupType)
            {
                case (Int16)PickupManager.PICKUPTYPES.UPGRADE_WEAPON_PRIMARY:
                    ship.GetWeaponPrimary().Upgrade();
                    break;
                case (Int16)PickupManager.PICKUPTYPES.AMMO_ROCKET:
                    ship.GetWeaponSecondary().GiveAmmo(1);
                    break;
                case (Int16)PickupManager.PICKUPTYPES.POWERUP_INV:
                    ship.SetInvincible(true);
                    break;
                case (Int16)PickupManager.PICKUPTYPES.POWERUP_HEALTH:
                    ship.IncreaseHealth(20);
                    break;
                case (Int16)PickupManager.PICKUPTYPES.POWERUP_LEVEL_UP:
                    EnemyManager.GetInstance().KillAllEnemies();
                    break;
                case (Int16)PickupManager.PICKUPTYPES.DEGRADE_WEAPON_PRIMARY:
                    ship.GetWeaponPrimary().Degrade();
                    break;
                case (Int16)PickupManager.PICKUPTYPES.AMMO_ROCKET_LOOSE:
                    ship.GetWeaponSecondary().GiveAmmo(-1);
                    break;
                case (Int16)PickupManager.PICKUPTYPES.DEGRADE_50HEALTH:
                    ship.SetCurrentHealth(ship.GetHealthCurrent() * 0.50);
                    break;
                case (Int16)PickupManager.PICKUPTYPES.UPGRADE_SPEED:
                    ship.Speed += 0.2f;
                    break;
                case (Int16)PickupManager.PICKUPTYPES.DEGRAGE_SPEED:
                    ship.Speed -= 0.2f;
                    break;
                case (Int16)PickupManager.PICKUPTYPES.POWERUP_PLAYER_SHIP:
                    ship.Upgrade();
                    break;
                    
                    
                    

                    
                    

            }
            this.Destroy();
        }
        public void Destroy()
        {
            this.RemoveSelf();
        }
        #endregion
        #region Private Functions
        #endregion

    }
}
