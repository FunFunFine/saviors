using System;
using System.Collections.Generic;
using System.Drawing;
using PhysX;

namespace Drawing
{
    public class PictureLibrary : IPictureLibrary
    {
        private readonly Dictionary<Tile, Image> tiles;
        private readonly Dictionary<Type, Image> bodies;
        private readonly Image defaultImage;

        public PictureLibrary(Dictionary<Tile, Image> tiles, Dictionary<Type, Image> bodies, Image defaultImage)
        {
            this.tiles = tiles;
            this.bodies = bodies;
            this.defaultImage = defaultImage;
        }

        public Image GetTileImage(Tile tile)
        {
            return !tiles.ContainsKey(tile) ? defaultImage : tiles[tile];
        }

        public Image GetBodyImage<T>(T body)
            where T : Body
        {
            var type = body.GetType();
            return !bodies.ContainsKey(type) ? defaultImage : bodies[type];
        }
    }
}