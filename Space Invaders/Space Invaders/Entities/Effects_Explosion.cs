using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    public class Effects_Explosion : Entity
    {
        public const int DESTROY_FRAME = 25;
        private int destroyFrame = 0;
        public Spritemap<string> sprite;
        //private Sound exSound = new Sound(Assets.SOUND_EFFECTS_EXPLOSION);

        public Effects_Explosion(float x, float y)
            : base(x, y)
        {
            destroyFrame = DESTROY_FRAME;

            sprite = new Spritemap<string>(Assets.SPRITE_EXPLOSION, 64, 64);
            sprite.Add("Emit", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f });

            sprite.CenterOrigin(); 
            sprite.Play("Emit");
            Graphic = sprite;

            Global.camShaker.ShakeCamera();
            //exSound.Play();
        }

        public override void Update()
        {
            base.Update();

            Y -= (float)(0.7 / Otter.Rand.Float(1, 2));
            if (sprite.CurrentFrame == destroyFrame)
            {
                RemoveSelf();
            }
        }
    }
}
