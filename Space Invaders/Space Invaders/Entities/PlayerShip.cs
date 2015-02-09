using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class PlayerShip : Entity
    {
        #region Private Variables
        private Text RocketText = new Text(20);

        private Image MainModel = new Image(Assets.GRAPHIC_PLAYER_SHIP);
        private Session PlayerSession = null;
        private float BaseY = 0;
        private Random rand = new Random();

        private Weapon_Primary WeaponPrimary = new Weapon_Primary();
        private Weapon_Secondary WeaponSecondary = new Weapon_Secondary();
        #endregion

        #region Constructor
        public PlayerShip(Session session)
            : base()
        {
            this.MainModel.CenterOrigin();
            this.Graphic = this.MainModel;
            this.PlayerSession = session;

            this.X = Game.Instance.HalfWidth;
            this.Y = Game.Instance.Height - MainModel.HalfHeight - 20;
            this.BaseY = this.Y;

            WeaponSecondary.GiveAmmo(5);
        }
        #endregion

        #region Public Overrides
        public override void Update()
        {
            if (Scene.Timer % 10 == 0)
                this.Y = this.BaseY + rand.Next(-10, 10);
            base.Update();
            #region Ship Based Displays
            RocketText.String = WeaponSecondary.GetAmmo().ToString("00");
            RocketText.X = this.X + this.MainModel.HalfWidth;
            RocketText.Y = this.Y - this.MainModel.HalfHeight;
            #endregion
            #region Movement Controls
            // Move to the left
            if (this.PlayerSession.Controller.Left.Down)
            {
                if (this.X > 3.0f + MainModel.HalfWidth)
                    this.X -= 3.0f;
            }
            // Move to the right
            else if (this.PlayerSession.Controller.Right.Down)
            {
                if (this.X < Game.Instance.Width - MainModel.HalfWidth - 3.0f)
                    this.X += 3.0f;
            }
            #endregion
            #region Weapon Controls
            // Shoot the Primary Weapon
            if (this.PlayerSession.Controller.X.Down)
            {
                this.WeaponPrimary.Shoot(this.X, this.Y);
                
            }
            // Shoot the Secondary Weapon
            if (this.PlayerSession.Controller.Circle.Down)
            {
                this.WeaponSecondary.Shoot(this.X, this.Y);
                //this.WeaponPrimary.Upgrade();
            }
            #endregion
        }
        public override void Render()
        {
            base.Render();
            Draw.Graphic(RocketText);
        }
        #endregion 
    }
}
