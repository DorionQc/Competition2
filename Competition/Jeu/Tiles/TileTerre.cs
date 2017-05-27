using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Competition.Jeu.Tiles
{
    public class TileTerre : Tile
    {
        public TileTerre(int x, int y, Map parent) : base(x, y, parent, false, true, true)
        { }

        public override Texture2D Texture
        {
            get
            {
                return TextureManager.TextureTerre;
            }
        }

        public override TileType Type
        {
            get
            {
                return TileType.Terre;
            }
        }
    }
}
