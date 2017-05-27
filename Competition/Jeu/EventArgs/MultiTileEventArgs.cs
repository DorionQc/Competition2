using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Jeu.EventArgs
{
    public class MultiTileEventArgs
    {
        public Tile Source;
        public Tile[] Tiles;

        public MultiTileEventArgs(Tile source, Tile[] tiles)
        {
            Source = source;
            Tiles = tiles;
        }
    }
}
