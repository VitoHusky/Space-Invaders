using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class MainLine : Entity
    {
        public MainLine(int width, int height, int x, int y, Color col)
            : base()
        {
            SetGraphic(Image.CreateRectangle(width, height, col));
            this.X = x;
            this.Y = y;
        }
    }
}
