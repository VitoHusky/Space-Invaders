using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Weapon_Shot_Trail : Entity
    {
        private Image img = null;
        /// <summary>
        /// The function to create a trail of a shot
        /// </summary>
        /// <param name="x">The x coordinate where the trail should be created</param>
        /// <param name="y">The y coordinate where the trail should be created</param>
        /// <param name="col">The color of the original shot</param>
        public Weapon_Shot_Trail(float x, float y, Color col)
            : base(x, y)
        {
            img= Image.CreateCircle(1, col);
            img.CenterOrigin();
            SetGraphic(img);
            LifeSpan = 3;
        }
        /// <summary>
        /// Public override to fade out the shot depending on his current Weapon. 
        /// Increases the opacity
        /// </summary>
        public override void Update()
        {
            base.Update();

            img.Alpha = Util.ScaleClamp(Timer, 0, LifeSpan, 1, 0);
        }
    }
}
