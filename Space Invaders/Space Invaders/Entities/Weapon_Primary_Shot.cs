﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace Space_Invaders.Entities
{
    class Weapon_Primary_Shot : Entity
    {
        public const int MaxWeaponMode = 4;

        private Sound shotsound = null;
        private Speed speed = new Speed(10.0f);

        private Color color = null;
        private Image image = null;
        private int weaponMode = 0;

        public Weapon_Primary_Shot(float StartX, float StartY, int weaponLevel, bool playSound = true)
            : base()
        {
            Layer = 100;

            for (int i = 0; i < weaponLevel; i++)
            {
                if (weaponMode == MaxWeaponMode)
                    weaponMode = 0;
                weaponMode++;
            }

            // Die Farbe des Schusses
            switch (weaponMode)
            {
                case 1:
                    this.color = Color.Red;
                    break;
                case 2:
                    this.color = Color.Blue;
                    break;
                case 3:
                    this.color = Color.Green;
                    break;
                case 4:
                    this.color = Color.White;
                    break;
            }
            //Allgemeine Eigenschaften
            switch (weaponMode)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    speed.Y = -5.0f;
                    this.image = Image.CreateRectangle(1, 5, this.color);
                    shotsound = new Sound(Assets.SOUND_WEAPON_MACHINE_GUN);
                    break;
            }

            this.SetGraphic(this.image);

            this.X = StartX;
            this.Y = StartY;
            if (playSound)
                shotsound.Play();
        }
        public override void Removed()
        {
            base.Removed();
            shotsound.Stop();
        }
        public override void Update()
        {
            base.Update();
            this.Y += speed.Y;
            if (this.color != null)
                Scene.Add(new Entities.Weapon_Shot_Trail(this.X, this.Y, this.color));
            if (this.Y <= Global.GAME_INTERFACE_HEIGHT + 1)
            {
                Scene.Remove(this);
            }
        }
    }
}
