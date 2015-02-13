using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Weapon_Primary_Shot : Entity
    {
        public const int MaxWeaponMode = 4;

        private Sound shotsound = null;
        private Speed speed = new Speed(10.0f);
        private Double DamagePerShot = 0;

        private Color color = null;
        private Image image = null;
        private int weaponMode = 0;

        #region Constructor
        /// <summary>
        /// The constructor to create the shot
        /// </summary>
        /// <param name="StartX">Shot start coordinate X</param>
        /// <param name="StartY">Shot start coordinate Y</param>
        /// <param name="weaponLevel">The weaponLevel</param>
        /// <param name="playSound">Bool variable if the weapon sound should be played (If you shoot 4 shots at the same time you only need one Sound)</param>
        public Weapon_Primary_Shot(float StartX, float StartY, int weaponLevel, bool playSound = true)
            : base()
        {
            Layer = 100;

            for (int i = 0; i < weaponLevel; i++)
            {
                if (weaponMode == MaxWeaponMode)
                    weaponMode = 0;
                weaponMode++;
            }

            // Die Farbe des Schusses
            switch (weaponMode)
            {
                case 1:
                    this.color = Color.Red;
                    break;
                case 2:
                    this.color = Color.Blue;
                    break;
                case 3:
                    this.color = Color.Green;
                    break;
                case 4:
                    this.color = Color.White;
                    break;
            }
            //Allgemeine Eigenschaften
            switch (weaponMode)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    speed.Y = -5.0f;
                    this.image = Image.CreateRectangle(1, 5, this.color);
                    shotsound = new Sound(Assets.SOUND_WEAPON_MACHINE_GUN);
                    break;
            }

            this.DamagePerShot = this.weaponMode * Global.DAMAGE_WEAPON_PER_LEVEL;

            this.SetGraphic(this.image);

            this.X = StartX;
            this.Y = StartY;
            this.SetHitbox(2, 2, (int)Global.HIT_TYPES.PRIMARY_SHOT);
            if (playSound)
                shotsound.Play();
        }
        #endregion 

        #region Public Methods
        public void Destroy()
        {
            this.RemoveSelf();
        }
        public Double GetDamage()
        {
            return this.DamagePerShot;
        }
        #endregion

        #region Public Overrides
        /// <summary>
        /// The override to stop the sound when the shot is removed.
        /// </summary>
        public override void Removed()
        {
            base.Removed();
            shotsound.Stop();
        }
        /// <summary>
        /// The override von the Update Function
        /// Updates the Position of the Shot and creates the Shot trail
        /// </summary>
        public override void Update()
        {
            base.Update();
            this.Y += speed.Y;
            if (this.color != null)
                Scene.Add(new Entities.Weapon_Shot_Trail(this.X, this.Y, this.color));
            if (this.Y <= Dimensions.GAME_INTERFACE_HEIGHT + 1)
            {
                Scene.Remove(this);
            }
        }
        #endregion
    }
}
