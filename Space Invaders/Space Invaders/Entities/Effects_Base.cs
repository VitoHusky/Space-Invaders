using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Effects_Base : Entity
    {
        public Spritemap<string> sprite;
        public int destroyFrame = 1;

        public Effects_Base(float x, float y)
            : base(x, y)
        {

        }

        public override void Update()
        {
            base.Update();

            Y -= (float)(1.5 / Otter.Rand.Float(1, 3));

            // Check if we have finished playing. If so, remove self
            if (sprite.CurrentFrame == destroyFrame)
            {      
                RemoveSelf();
            }
        }
    }
}
