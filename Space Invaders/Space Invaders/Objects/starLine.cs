using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Objects
{
    class starLine : Entity
    {
        Image imageLine = Image.CreateRectangle(20, 2, Color.White);
        public starLine(int x, int y) : base()
        {
            SetGraphic(imageLine);
            this.Y = y;
            this.X = x;
           
        }
    }
}
