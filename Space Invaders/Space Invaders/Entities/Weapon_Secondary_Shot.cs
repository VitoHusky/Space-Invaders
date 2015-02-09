using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Weapon_Secondary_Shot : Entity
    {

        private Sound shotsound = null;
        private Speed speed = new Speed(10.0f);

        private Color color = null;
        private Image image = null;
        private int weaponLevel = 0;

        /// <summary>
        /// The function to create the shot of the secondary weapon
        /// </summary>
        /// <param name="StartX">Start Position X</param>
        /// <param name="StartY">Start Position Y</param>
        /// <param name="weaponLevel">The Level of the Weapon</param>
        /// <param name="playSound">The boolean Value if the shotsound should be played</param>
        public Weapon_Secondary_Shot(float StartX, float StartY, int weaponLevel, bool playSound = true)
            : base()
        {
            Layer = 100;
            this.weaponLevel = weaponLevel;
            this.image = new Image(Assets.GRAPHIC_WEAPON_ROCKET_LAUNCHER);
            this.image.CenterOrigin();
            shotsound = new Sound(Assets.SOUND_WEAPON_ROCKET_LAUNCHER_START);
            speed.Y = -3.0f;

            this.SetGraphic(this.image);

            this.X = StartX;
            this.Y = StartY;
            if (playSound)
                shotsound.Play();
        }
        /// <summary>
        /// The public override to stop the sound if the shot got removed
        /// </summary>
        public override void Removed()
        {
            base.Removed();
            shotsound.Stop();
        }
        /// <summary>
        /// The update override to create the trail and move the shot depending on his speed
        /// </summary>
        public override void Update()
        {
            base.Update();
            this.Y += speed.Y;
            if (this.color != null)
                Scene.Add(new Entities.Weapon_Shot_Trail(this.X, this.Y, this.color));
            if (this.Y <= Global.GAME_INTERFACE_HEIGHT + 1)
            {
                Scene.Remove(this);
            }
        }
    }
}
