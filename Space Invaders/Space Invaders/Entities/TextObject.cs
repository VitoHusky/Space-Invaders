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
        private string font = "";
        private int size = 0;
        private String text = "";
        private textObjectText obj = null;
        private int x;
        private int y;
        public TextObject(string text, int x, int y, string font = "Arial", int size = 20)
            : base()
        {
            this.font = font;
            this.size = size;
            this.x = x;
            this.text = text;
            this.y = y;
            obj = new Entities.textObjectText(text, x, y, font, size);
            SetGraphic(obj);
        }
        public void CenterOriginY()
        {
            obj = new Entities.textObjectText(this.text, x, y, font, size);
            obj.CenterOrigin();
            SetGraphic(obj);
        }
        public void SetString(string str)
        {
            SetGraphic(new Entities.textObjectText(str, this.x, this.y, font, size));
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
