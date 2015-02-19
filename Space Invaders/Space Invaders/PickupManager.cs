using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders
{
    class PickupManager
    {
        private static Int32 UpgradeCount = 11;

        public enum PICKUPTYPES
        {
            UPGRADE_WEAPON_PRIMARY = 1,
            AMMO_ROCKET, 
            POWERUP_INV,
            POWERUP_HEALTH,
            POWERUP_LEVEL_UP,
            POWERUP_PLAYER_SHIP,
            DEGRADE_WEAPON_PRIMARY,
            AMMO_ROCKET_LOOSE,
            DEGRADE_50HEALTH,
            UPGRADE_SPEED,
            DEGRAGE_SPEED
        }

        private static PickupManager instance = null;
        public static PickupManager Instance
        {
            get {
                if (instance == null)
                    instance = new PickupManager();
                return instance;
            }

        }

        #region Private Variables
        private Random rand = new Random();
        private List<Entities.Pickup> Pickups = new List<Entities.Pickup>();
        #endregion


        public void SpawnRandomUpgrade(float x, float y, object instance = null)
        {
            /*switch(rand.Next(1, PickupManager.UpgradeCount))
            {
                case (Int16)PICKUPTYPES.UPGRADE_WEAPON_PRIMARY:
                    
                    break;
            }*/
            Int32 type = rand.Next(1, PickupManager.UpgradeCount);
            Entities.Pickup pickup = new Entities.Pickup(x, y, (Int16)type);
            this.Pickups.Add(pickup);
            Game.Instance.Scene.Add(pickup);
        }

        public void CheckCollide(Entities.PlayerShip ship)
        {
            var collb = ship.Collider.Collide(ship.X, ship.Y, (int)Global.HIT_TYPES.PICKUP);
            if (collb != null)
            {
                Entities.Pickup b = (Entities.Pickup)collb.Entity;
                b.OnPickup(ship);
                this.Pickups.Remove(b);
            }
        }
    }
}
