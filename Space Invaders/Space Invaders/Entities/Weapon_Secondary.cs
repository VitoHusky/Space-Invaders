using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Weapon_Secondary : Entity
    {
        // Private Variables
        private float LastShot = 0;
        private float ShotCooldown = 150;
        private int Ammo = 0;
        private int MaxAmmo = 5;
        private int WeaponLevel = 0;

        // Constructor
        /// <summary>
        /// Empty constructor of the Secondary Weapon
        /// </summary>
        public Weapon_Secondary()
            : base()
        {
        }

        // Public Methods
        /// <summary>
        /// The function to increase the ammo of the secondary weapon.
        /// </summary>
        /// <param name="val">The value how much shots should be added to the Ammo</param>
        public void GiveAmmo(int val = 1)
        {
            // Negativ
            if (val < 0)
            {
                if (this.Ammo > val)
                    this.Ammo -= val;
            }
            // Positiv
            else
            {
                if (this.Ammo + val >= this.MaxAmmo)
                    this.Ammo = this.MaxAmmo;
                else if (this.Ammo + val < this.MaxAmmo)
                    this.Ammo += val;
            }
        }
        /// <summary>
        /// Get the current Ammo of the Weapon
        /// </summary>
        /// <returns>The amount of the secondary weapon</returns>
        public int GetAmmo()
        {
            return this.Ammo;
        }
        /// <summary>
        /// The function for the shot of the secondary weapon
        /// </summary>
        /// <param name="x">Start Position X</param>
        /// <param name="y">Start Position Y</param>
        public void Shoot(float x, float y)
        {
            if (this.Ammo == -1 || this.Ammo > 0)
            {
                if (Game.Instance.Timer - LastShot >= ShotCooldown)
                {
                    LastShot = Game.Instance.Timer;
                    if (this.Ammo != -1)
                        this.Ammo--;
                    switch (this.WeaponLevel)
                    {
                        case 0:
                            Game.Instance.Scene.Add(new Weapon_Secondary_Shot(x, y, WeaponLevel));
                            break;
                    }
                }
            }
        }
    }
}
