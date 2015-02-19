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
        #region Private Variables
        // Zeiten
        private float LastShot = 0;
        private float ShotCooldown = 10;
        private bool BotWeapon = false;
        private int UpgradeLevel = 1;

        private Int32 Shotcount;
        private Int32 Weaponpower;


        // Maximals
        private const int MaxUpgradeLevel = MaxWeaponShotsPerLevel * MaxWeaponPower;
        private const int MaxWeaponPower = 4;
        private const int MaxWeaponShotsPerLevel = 5;
        #endregion

        #region Constructor
        public Weapon_Primary()
        {
            this.SyncWeapon();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Synchronize the Weapon for Power and Shotcount
        /// </summary>
        private void SyncWeapon()
        {
            this.Weaponpower = this.CalculateWeaponpower();
            this.Shotcount = this.CalculateShotcount();   
        }
        private Int32 CalculateShotcount()
        {
            if (this.Weaponpower == 1)
                return this.UpgradeLevel;
            else return this.UpgradeLevel - ((this.Weaponpower - 1) * MaxWeaponShotsPerLevel);
        }

        private Int32 CalculateWeaponpower()
        {
            return (Int32) Math.Ceiling( (double)this.UpgradeLevel / (double)MaxWeaponShotsPerLevel);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// The function to increase the Weapon level plus one until the max level is reached.
        /// </summary>
        public void Upgrade()
        {
            if (this.UpgradeLevel < MaxUpgradeLevel)
            {
                this.UpgradeLevel++;
                this.SyncWeapon();
                Console.WriteLine("Weapon Primary Upgraded. New Level: " + this.UpgradeLevel + " | New Power: " + this.Weaponpower + " | Shots: " + this.Shotcount);
            }
        }
        public void Degrade()
        {
            if (this.UpgradeLevel > 1)
            {
                this.UpgradeLevel--;
                this.SyncWeapon();
                Console.WriteLine("Weapon Primary Upgraded. New Level: " + this.UpgradeLevel + " | New Power: " + this.Weaponpower + " | Shots: " + this.Shotcount);
            }
        }
        public void SetBotWeapon(bool b)
        {
            this.BotWeapon = b;
        }
        public Int32 GetLevel()
        {
            return this.UpgradeLevel;
        }
        public Int32 GetLevelPercent()
        {
            return this.UpgradeLevel * 100 / MaxUpgradeLevel;
        }
        public Int32 GetMaxLevel()
        {
            return MaxUpgradeLevel;
        }
        public Int32 GetWeaponMode()
        {
            return this.Weaponpower;
        }
        /// <summary>
        /// Public function to create a shot. Depending on the x and y coordinate
        /// </summary>
        /// <param name="x">x coordinate the weapons shoots from</param>
        /// <param name="y">y coordinate the weapons shoots from</param>
        public void Shoot(float x, float y)
        {
            if (Game.Instance.Timer - LastShot >= ShotCooldown)
            {
                LastShot = Game.Instance.Timer;
                if (this.BotWeapon)
                {
                    Game.Instance.Scene.Add(new Weapon_Primary_Shot(x, y, this.UpgradeLevel, true, true));
                }
                else
                {
                    bool firstShot = true;

                    // Mitte
                    if (this.Shotcount == 1 || this.Shotcount == 3 || this.Shotcount == 5)
                    {
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x, y - 5, this.UpgradeLevel, firstShot, this.BotWeapon, this));
                        firstShot = false;
                    }
                    // Außen Weit
                    if (this.Shotcount == 2 || this.Shotcount == 3 || this.Shotcount == 4 || this.Shotcount == 5)
                    {
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 20, y, this.UpgradeLevel, firstShot, this.BotWeapon, this));
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 20, y, this.UpgradeLevel, false, this.BotWeapon, this));
                        firstShot = false;
                    }
                    // Außen innen 
                    if (this.Shotcount == 4 || this.Shotcount == 5)
                    {
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x - 10, y, this.UpgradeLevel, firstShot, this.BotWeapon, this));
                        Game.Instance.Scene.Add(new Weapon_Primary_Shot(x + 10, y, this.UpgradeLevel, false, this.BotWeapon, this));
                        firstShot = false;
                    }
                }
            }
        }
        #endregion
    }
}
