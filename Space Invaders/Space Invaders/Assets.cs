using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Assets
    {
        private const string BASE_DIR = "../../Assets";
        public const string GRAPHIC_PLAYER_SHIP_1 = BASE_DIR + "/Graphics/Ship_Level_1.png";
        public const string GRAPHIC_PLAYER_SHIP_2 = BASE_DIR + "/Graphics/Ship_Level_2.png";
        public const string GRAPHIC_PLAYER_SHIP_3 = BASE_DIR + "/Graphics/Ship_Level_3.png";
        public const string GRAPHIC_TITLE_BACKGROUND = BASE_DIR + "/Graphics/TitleBackground.png";
        public const string GRAPHIC_WEAPON_ROCKET_LAUNCHER = BASE_DIR + "/Graphics/Weapon_Rocket_Launcher.png";
        public const string GRAPHIC_ENEMY_SHIP = BASE_DIR + "/Graphics/Enemy.png";

        // Upgrades
        public const string GRAPHIC_PICKUP_UPGRADE_WEAPON_PRIMARY   = BASE_DIR + "/Graphics/Pickup_Upgrade_Weapon_Primary.png";
        public const string GRAPHIC_PICKUP_AMMO_ROCKET				= BASE_DIR + "/Graphics/Pickup_Upgrade_Ammo_Rocket.png";
        public const string GRAPHIC_PICKUP_POWERUP_INV				= BASE_DIR + "/Graphics/Pickup_Upgrade_Powerup_Inv.png";
        public const string GRAPHIC_PICKUP_POWERUP_HEALTH			= BASE_DIR + "/Graphics/Pickup_Upgrade_Powerup_Health.png";
        public const string GRAPHIC_PICKUP_POWERUP_LEVEL_UP			= BASE_DIR + "/Graphics/Pickup_Upgrade_Powerup_Level_up.png";
        public const string GRAPHIC_PICKUP_POWERUP_PLAYER_SHIP		= BASE_DIR + "/Graphics/Pickup_Upgrade_Powerup_Player_Ship.png";
        public const string GRAPHIC_PICKUP_DEGRADE_WEAPON_PRIMARY	= BASE_DIR + "/Graphics/Pickup_Degrade_Weapon_Primary.png";
        public const string GRAPHIC_PICKUP_AMMO_ROCKET_LOOSE		= BASE_DIR + "/Graphics/Pickup_Ammo_Rocket_Loose.png";
        public const string GRAPHIC_PICKUP_DEGRADE_50HEALTH			= BASE_DIR + "/Graphics/Pickup_Degrade_Health.png";
        public const string GRAPHIC_PICKUP_UPGRADE_SPEED			= BASE_DIR + "/Graphics/Pickup_Upgrade_Speed.png";
        public const string GRAPHIC_PICKUP_DEGRADE_SPEED            = BASE_DIR + "/Graphics/Pickup_Deegrade_Speed.png";
        
        public const string SPRITE_EXPLOSION = BASE_DIR + "/Graphics/Sprite_Explosion.png";

        public const string FONT_AMERICAN_CAPTAIN = BASE_DIR + "/Fonts/American Captain.ttf";
        public const string FONT_HOMINIS = BASE_DIR + "/Fonts/HOMINIS.ttf";
        public const string FONT_DIGITAL = BASE_DIR + "/Fonts/digital-7.ttf";

        public const string SOUND_TITLE_MUSIC = BASE_DIR + "/Sounds/MenueMusic.ogg";
        public const string SOUND_WEAPON_MACHINE_GUN = BASE_DIR + "/Sounds/Weapon_Machine_Gun.ogg";
        public const string SOUND_WEAPON_ROCKET_LAUNCHER_START = BASE_DIR + "/Sounds/Weapon_Rocket_Launcher_Start.ogg";
        public const string SOUND_WEAPON_ROCKET_LAUNCHER_FLY = BASE_DIR + "/Sounds/Weapon_Rocket_Launcher_Fly.ogg";
        public const string SOUND_WEAPON_ROCKET_LAUNCHER_FINAL = BASE_DIR + "/Sounds/Weapon_Rocket_Launcher_Finale.ogg";
        public const string SOUND_EFFECTS_EXPLOSION = BASE_DIR + "/Sounds/Effects_Explosion.ogg";
        public const string SOUND_EFFECTS_PICKUP_PICKUP = BASE_DIR + "/Sounds/Effects_Pickup_Pickup.ogg";
        public const string SOUND_LEVELUP = BASE_DIR + "/Sounds/Levelup.ogg";

        public static string[] SOUND_GAME_MUSIC = (new string[] {
            "../../Assets/Sounds/GameMusic/23_Wasteland_Battle_.ogg"
        });
    }
}
