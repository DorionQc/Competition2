using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Competition.Jeu.Tiles;
using Competition.Jeu.EventArgs;


namespace Competition.Jeu
{
    [Flags]
    public enum CollisionSide
    {
        None = 0,
        Up = 1,
        Left = 2,
        Down = 4,
        Right = 8
    };

    public struct CollisionInfo
    {
        public CollisionSide Side;
        public Tile Tile;

        public CollisionInfo(CollisionSide side, Tile tile)
        {
            this.Side = side;
            this.Tile = tile;
        }
    }

//    public delegate void OnDropBombHandler(object sender, TileEventArgs e);
    public delegate void OnGetDropHandler(object sender, TileEventArgs e);
    public delegate void OnChangeTileHandler(object sender, MultiTileEventArgs e);
    public delegate void OnCollideWithBlockHandler(object sender, BlockCollisionEventArgs e);
//    public delegate void OnBombExplodeHandler(object sender, TileEventArgs e);

    public delegate void OnGenericMultiblockEventHandler(object sender, MultiTileEventArgs e);
    public delegate void OnGenericBlockEventHandler(object sender, TileEventArgs e);

    public enum EntityType
    {
        Joueur = 0,
        Bomb,
        
    };

    public abstract class Entity
    {
        private int _x;
        private int _y;

        /// <summary>
        /// Lancé lorsque l'entité meurt
        /// </summary>
//        public event OnDieHandler Died;

  //      protected void FireDied(object sender, CancellableEventArgs e)
  //      {
  //          Died?.Invoke(sender, e);
  //      }

        protected Entity(int x, int y, Map m, bool registered, int id)
        {
            IsRegistered = registered;
            _x = x;
            _y = y;
            Map = m;
            Size = 15;
            IsDead = false;
            ID = id == 0 ? (int)DateTime.Now.Ticks ^ (x << 16) ^ y : id;
        }

        /// <summary>
        /// Indique si l'entité est morte
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Identifiant pseudo-unique de l'entité
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Position en X de l'entité, en pixel
        /// </summary>
        public int X
        {
            get { return _x; }
            set { if (value >= 0 && value < Map.NoTile * Map.EntityPixelPerTile) _x = value; }
        }

        /// <summary>
        /// Position en Y de l'entité, en pixel
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { if (value >= 0 && value < Map.NoTile * Map.EntityPixelPerTile) _y = value; }
        }

        /// <summary>
        /// Grosseur de l'entité
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Carte contenant l'entité
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// Indique si l'entité est contenue dans l'EntityManager
        /// </summary>
        public bool IsRegistered { get; }

        /// <summary>
        /// Type de l'entité
        /// </summary>
        public abstract EntityType Type { get; }

        /// <summary>
        /// Calcule et donne un tableau contenant les cases dans lesquelles se trouve l'entité
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Tile[] GetTilesIn(int x, int y)
        {
            int n = 1, i = 0;
            int x1, x2, y1, y2;
            bool bx, by;
            Tile[] ret;

            x1 = (x - Size) / Map.EntityPixelPerTile;
            x2 = (x + Size - 1) / Map.EntityPixelPerTile;
            y1 = (y - Size) / Map.EntityPixelPerTile;
            y2 = (y + Size - 1) / Map.EntityPixelPerTile;

            if (y2 >= Map.NoTile)
            {
                y2 = Map.NoTile - 1;
                if (y1 >= Map.NoTile)
                    y1 = Map.NoTile - 1;
            }

            if (x2 >= Map.NoTile)
            {
                x2 = Map.NoTile - 1;
                if (x1 >= Map.NoTile)
                    x1 = Map.NoTile - 1;
            }
            if (x1 < 0)
            {
                x1 = 0;
                if (x2 < 0)
                    x2 = 0;
            }
            if (y1 < 0)
            {
                y1 = 0;
                if (y2 < 0)
                    y2 = 0;
            }
            bx = (x1 != x2);
            by = (y1 != y2);
            if (bx) n <<= 1;
            if (by) n <<= 1;
            ret = new Tile[n];

            ret[i++] = Map[x1, y1];

            if (bx) ret[i++] = Map[x2, y1];
            if (by) ret[i++] = Map[x1, y2];
            if (bx && by) ret[i] = Map[x2, y2];
            return ret;
        }

        public abstract void Tick(long deltaTime);

        public abstract void Draw(SpriteBatch sb, float width);

        public abstract void Draw(SpriteBatch sb, float width, Color color);

    }


}


