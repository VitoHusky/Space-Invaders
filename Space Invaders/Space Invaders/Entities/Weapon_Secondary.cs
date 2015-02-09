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
        public Weapon_Secondary()
            : base()
        {
        }

        // Public Methods
        public void GiveAmmo(int val = 1)
        {
            if (this.Ammo + val >= this.MaxAmmo)
                this.Ammo = this.MaxAmmo;
            else if (this.Ammo + val < this.MaxAmmo)
                this.Ammo += val;
        }
        public int GetAmmo()
        {
            return this.Ammo;
        }
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
