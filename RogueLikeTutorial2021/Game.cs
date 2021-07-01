using System;
using RogueLikeTutorial2021.Cartography;
using RogueLikeTutorial2021.Entities;
using SadConsole;
using SadConsole.Components;
using SadRogue.Primitives.GridViews;

namespace RogueLikeTutorial2021
{
    class Game
    {
        public static int GameWidth = 80;
        public static int GameHeight = 50;
        public static int DungeonWidth = 100;
        public static int DungeonHeight = 100;

        public static DungeonMap Map;
        public static Player Player;

        static void Main(string[] args)
        {
            SadConsole.Game.Create(GameWidth, GameHeight, "Fonts/Kenny.font");
            SadConsole.Game.Instance.OnStart = Init;
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            SadConsole.Game.Instance.MonoGameInstance.Window.Title = "r/RogueLikeDev Tutorial 2021";

            Map = new DungeonMap(DungeonWidth, DungeonHeight, (GameWidth, GameHeight));
            Player = new Player(Map.WalkabilityView.RandomPosition(true));
            Map.AddEntity(Player);
            Player.CalculateFOV();
            
            // center the view on the player
            Map.AllComponents.Add(new SurfaceComponentFollowTarget(){ Target = Player});

            GameHost.Instance.Screen = Map;
        }
    }
}