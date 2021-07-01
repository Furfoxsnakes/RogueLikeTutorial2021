using SadRogue.Primitives;

namespace RogueLikeTutorial2021.Helpers
{
    public class Constants
    {
        public const float TileDimFactor = 0.7f;
    }

    public class Swatch
    {
        // http://paletton.com/#uid=73d0u0k5qgb2NnT41jT74c8bJ8X
        // https://roguesharp.wordpress.com/2016/03/05/roguesharp-v3-tutorial-color-palette/
        
        public static readonly Color Primary = new Color(68, 82, 79);
        public static readonly Color Secondary = new Color(72, 77, 85);
        public static readonly Color Alternate = new Color(129, 121, 107);
        public static readonly Color Compliment = new Color(129, 116, 107);
        
        // http://pixeljoint.com/forum/forum_posts.asp?TID=12795
        public static readonly Color DarkWood = new Color(20, 12, 28);
        public static readonly Color Blood = new Color(208, 70, 72);
        public static readonly Color Water = new Color(48, 52, 109);
        public static readonly Color Stone = new Color(117, 113, 97);
        public static readonly Color LightSkin = new Color(222, 238, 214);

        public static readonly Color Player = LightSkin;
    }
}