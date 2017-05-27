using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Competition.Jeu.Tiles
{
    class TileBarricade : Tile
    {
        public TileBarricade(int x, int y, Map parent) : base(x, y, parent, true, true, false)
        { }

        public override TileType Type => TileType.Barricade;

        public override Texture2D Texture => TextureManager.TextureBarricade;

    }
}
