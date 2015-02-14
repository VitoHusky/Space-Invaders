using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Pickup : Entity
    {
        #region Private Variables
        private Int16 PickupType = 0;
        private Image img = null;
        private Speed speed = null;
        #endregion
        #region Public Variables
        #endregion

        #region Constructor
        public Pickup(float x, float y, Int16 type)
            : base(x, y)
        {
            this.PickupType = type;
            switch (type)
            {
                case (int)Global.PICKUPTYPES.UPGRADE_WEAPON_PRIMARY:
                    img = new Image(Assets.GRAPHIC_UPGRADE_WEAPON);
                    break;
            }
            this.X = x;
            this.Y = y;
            this.speed = new Speed(Global.SPEED_PICKUP_MAX);
            this.speed.Y = Rand.Int(2, Global.SPEED_PICKUP_MAX);
            img.CenterOrigin();
            this.SetGraphic(img);

            CircleCollider col = new CircleCollider((int)this.img.HalfWidth, (int)Global.HIT_TYPES.PICKUP);
            col.CenterOrigin();
            this.AddCollider(col);
        }
        #endregion
        #region Public Overrrdes
        public override void Update()
        {
            base.Update();

            this.Y += speed.Y;
            if (this.Y > Game.Instance.Height)
                this.RemoveSelf();
        }
        #endregion 
        #region Public Functions
        public void Destroy()
        {
            this.RemoveSelf();
        }
        #endregion
        #region Private Functions
        #endregion

    }
}
