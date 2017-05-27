using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Competition.Jeu.Tiles;

namespace Competition.Jeu.EventArgs
{
    public class TileEventArgs
    {
        public Tile Tile;

        public TileEventArgs(Tile tile)
        {
            this.Tile = tile;
        }
    }
}
