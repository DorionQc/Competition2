using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Penumbra;

namespace Competition.Jeu.Tiles
{

    public enum TileType
    {
        Terre,
        Grass,
        Roche,
        Arbre,
        Barricade
    }

    public abstract class Tile
    {
        protected Tile(int x, int y, Map m, bool solid, bool breakable, bool letsFireThrough)
        {
            X = x;
            Y = y;
            Map = m;
            IsSolid = solid;
            IsBreakable = breakable;
            LetsFireThrough = letsFireThrough;

            if (solid)
            {
                Hull = Hull.CreateRectangle(new Vector2(x * Map.Width + Map.Width / 2, y * Map.Width + Map.Width / 2), new Vector2(Map.Width, Map.Width));
                RobotWar.Penumbra.Hulls.Add(Hull);
            }
        }

        public Hull Hull { get; }

        /// <summary>
        /// Indice vertical dans le tableau de la carte
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Indice vertical dans le tableau de la carte
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// La carte qui contient cette case
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// Indique si la case est destructible ou non
        /// </summary>
        public bool IsBreakable { get; set; }

        /// <summary>
        /// Indique si la case est en processus de destruction
        /// </summary>
        public bool IsBreaking
        {
            get { /*return Fire != null;*/ return false; }
            set { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Référence vers le feu contenu dans cette case, ou null
        /// </summary>
        //public Fire Fire { get; set; }

        /// <summary>
        /// Indique si le feu peut traverser librement cette case
        /// </summary>
        public bool LetsFireThrough { get; set; }

        /// <summary>
        /// Indique si le joueur peut traverser librement cette case
        /// </summary>
        public virtual bool IsSolid { get; set; }

        public abstract Texture2D Texture { get; }

        public abstract TileType Type { get; }

        public virtual void Draw(SpriteBatch sb, float width)
        {

            sb.Draw(Texture, new Rectangle((int)(X * width), (int)(Y * width), (int)width, (int)width), Color.White);
        }

        public override string ToString()
        {
            return $"{Type} at {X}, {Y}";
        }
    }
    
}
