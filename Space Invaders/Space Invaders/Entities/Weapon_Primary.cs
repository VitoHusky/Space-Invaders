using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Weapon_Primary : Entity
    {
        // Private Variables
        private float LastShot = 0;
        private float ShotCooldown = 10;
        private int WeaponLevel = 1;
        private int MaxWeaponLevel = 5 * Weapon_Primary_Shot.MaxWeaponMode;

        // Public Methods
        public void Upgrade()
        {
            if (this.WeaponLevel < this.MaxWeaponLevel)
            {
                this.WeaponLevel++;
                Console.WriteLine("Weapon Primary Upgraded. New Level: " + this.WeaponLevel);
            }
        }
        public void Shoot(float x, float y)
        {
            if (Game.Instance.Timer - LastShot >= ShotCooldown)
            {
                LastShot = Game.Instance.Timer;
                /*switch(true)
                {
                    case this.WeaponLevel % 4 == 0:
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 20, y, this.WeaponLevel));
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 40, y, this.WeaponLevel));
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 20, y, this.WeaponLevel));
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 40, y, this.WeaponLevel));
                        break;
                }*/

                if (this.WeaponLevel % 5 == 0)
                {
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x, y-5, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 10, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 20, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 10, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 20, y, this.WeaponLevel));
                }
                else if (this.WeaponLevel % 4 == 0)
                {
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 10, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 20, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 10, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 20, y, this.WeaponLevel));
                }
                else if (this.WeaponLevel % 3 == 0)
                {
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 40, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 40, y, this.WeaponLevel));
                }
                else if (this.WeaponLevel % 2 == 0)
                {
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 40, y, this.WeaponLevel));
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 40, y, this.WeaponLevel));
                }
                else if (this.WeaponLevel % 1 == 0)
                {
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x, y, this.WeaponLevel));
                }
            }
        }
    }
}
