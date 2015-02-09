using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class StarLine : Entity
    {
        Image imageLine = Image.CreateRectangle(1, 4, Color.Gray);
        Speed speed = new Speed(10);
        public StarLine(int x)
            : base()
        {
            SetGraphic(imageLine);
            this.Y = Global.GAME_INTERFACE_HEIGHT;
            this.X = x;
            speed.Y = 250;
        }
        public override void Update()
        {
            base.Update();
            X += speed.X;
            Y += speed.Y;
            if (Y > Game.Instance.Height)
            {
                this.RemoveSelf();
            }
        }
    }
}
