using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Interface_Healthbar : Entity
    {
        private Double CurrentHealthPercent = 0;
        private PlayerShip ship = null;

        private const int MAX_WIDTH = 100;


        public Interface_Healthbar(float x, float y, PlayerShip ship)
            : base(x, y)
        {
            this.ship = ship;
        }

        public override void Render()
        {
            base.Render();
            Draw.Graphic(Image.CreateRectangle((int)(MAX_WIDTH / 100 * ship.GetHealthPercent()), 10, Color.Red));
        }
    }
}
