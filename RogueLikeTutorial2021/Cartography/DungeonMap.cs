using GoRogue.MapGeneration;
using RogueLikeTutorial2021.Helpers;
using SadRogue.Integration.FieldOfView.Memory;
using SadRogue.Integration.Maps;
using SadRogue.Primitives;
using SadRogue.Primitives.GridViews;

namespace RogueLikeTutorial2021.Cartography
{
    public class DungeonMap : RogueLikeMap
    {
        public DungeonMap(int width, int height, Point viewSize) : base(width, height, 4, Distance.Chebyshev,
            viewSize: viewSize)
        {
            GenerateDungeon();
        }

        private void GenerateDungeon()
        {
            var generator = new Generator(Width, Height);
            generator.ConfigAndGenerateSafe(gen =>
            {
                // gen.AddSteps(DefaultAlgorithms.RectangleMapSteps());
                gen.AddSteps(DefaultAlgorithms.BasicRandomRoomsMapSteps(minRooms:10, maxRooms:20, roomMinSize: 5, roomMaxSize:12));
            });

            var generatedMap = generator.Context.GetFirst<ISettableGridView<bool>>("WallFloor");
            
            AllComponents.Add(new DimmingMemoryFieldOfViewHandler(Constants.TileDimFactor));

            foreach (var position in this.Positions())
            {
                var walkable = generatedMap[position];
                var glyph = walkable ? (int)SpriteTiles.FLOOR : (int)SpriteTiles.WALL;
                SetTerrain(new MemoryAwareRogueLikeCell(position, Swatch.Stone, Color.Black, glyph, 0, walkable,
                    walkable));
            }
        }
    }
}