using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class TextObject : Entity
    {
        public TextObject(string text, int x, int y, string font = "Arial", int size = 20)
            : base()
        {
            SetGraphic(new Entities.textObjectText(text, x, y, font, size));

        }
    }
    class textObjectText : Text
    {
        public textObjectText(string text, int x, int y, string font, int size)
            : base()
        {
            this.String = text;
            this.X = x;
            this.Y = y;
            this.FontSize = size;
            this.CenterTextOriginX();
        }
    }
}
