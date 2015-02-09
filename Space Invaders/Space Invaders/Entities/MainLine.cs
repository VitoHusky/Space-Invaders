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
        /// <summary>
        /// Constructor of the Line
        /// </summary>
        /// <param name="width">The width of the line</param>
        /// <param name="height">The height of the line</param>
        /// <param name="x">The x coordinate of the line</param>
        /// <param name="y">The y coordinate of the line</param>
        /// <param name="col">The color of the line</param>
        public MainLine(int width, int height, int x, int y, Color col)
            : base()
        {
            SetGraphic(Image.CreateRectangle(width, height, col));
            this.X = x;
            this.Y = y;
        }
    }
}
