using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

            foreach (var image in bodies.Values.Concat(tiles.Values).With(defaultImage).Where(i => Equals(i.RawFormat, ImageFormat.Gif)))
                ImageAnimator.Animate(image, (sender, args) => { });
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

        public void SetBodyImage<T>(T body, Image image)
            where T : Body
        {
            var type = body.GetType();
            if (Equals(image.RawFormat, ImageFormat.Gif))
                ImageAnimator.Animate(image, (sender, args) => { });
            bodies[type] = image;
        }
    }
}