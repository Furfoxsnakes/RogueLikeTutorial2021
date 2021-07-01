using System;
using GoRogue.Components;
using GoRogue.GameFramework;
using RogueLikeTutorial2021.Helpers;
using SadConsole.Entities;
using SadRogue.Integration;
using SadRogue.Integration.Components;
using SadRogue.Primitives;

namespace RogueLikeTutorial2021.Entities
{
    public class Player : RogueLikeEntity
    {
        public Player(Point position) : base(position, Swatch.Player, Color.Black, (int)SpriteTiles.PLAYER, walkable: false)
        {
            Moved += OnMoved;

            AllComponents.Add(new PlayerControlsComponent());

            IsFocused = true;
        }
        
        public void CalculateFOV()
        {
            CurrentMap?.PlayerFOV.Calculate(Position, 7, CurrentMap.DistanceMeasurement);
        }
        
        private void OnMoved(object? sender, GameObjectPropertyChanged<Point> e)
        {
            CalculateFOV();
        }
    }
}