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

        public Weapon_Shot_Trail(float x, float y, Color col)
            : base(x, y)
        {
            img= Image.CreateCircle(1, col);
            img.CenterOrigin();
            SetGraphic(img);
            LifeSpan = 3;
        }
        public override void Update()
        {
            base.Update();

            img.Alpha = Util.ScaleClamp(Timer, 0, LifeSpan, 1, 0);
        }
    }
}
