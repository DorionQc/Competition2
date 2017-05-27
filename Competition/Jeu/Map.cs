using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Competition.Jeu.Tiles;

using Penumbra;


namespace Competition.Jeu
{
    
    public class Map
    {
        private readonly Tile[,] _cases;
        private int _width;
        private int _height;

        private readonly Random _random;

        // Nombre d'unités contenus dans une case, utilisées par les entités
        public const int EntityPixelPerCase = 30;

        /// <summary>
        /// Tile width, in pixel
        /// </summary>
        public float TileWidth;

        public int Width => _width;
        public int Height => _height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Width">Width, in tile units</param>
        /// <param name="Height">Height, in tile units</param>
        /// <param name="clientRect">Window. Assuming this is full screen</param>
        public Map(int Width, int Height, Rectangle clientRect)
        {
            _width = Width;
            _height = Height;
            _cases = new Tile[_width, _height];
            _random = new Random();

            TileWidth = Math.Min((float)clientRect.Width / _width, (float)clientRect.Height / _height);

            // Remplissage aléatoire de la carte
            for (int x = 1; x < _width - 1; x++)
                for (int y = 1; y < _height - 1; y++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                        this[x, y] = new TileTerre(x, y, this);
                    else if (_random.Next() % 2 != 0)
                        this[x, y] = new TileBarricade(x, y, this);
                    else
                        this[x, y] = new TileTerre(x, y, this);
                }

            for (int x = 0; x < _width - 1; x++)
            {
                this[x, 0] = new TileBarricade(x, 0, this);
                this[_width - 1 - x, _height - 1] = new TileBarricade(_width - 1 - x, _height - 1, this);
                

            }

            for (int y = 0; y < _height - 1; y++)
            {
                this[_width - 1, y] = new TileBarricade(_width - 1, y, this);
                this[0, _height - 1 - y] = new TileBarricade(0, _height - 1 - y, this);
            }

            // Génération des coins

            int i = 1;
            this[1, 1] = new TileTerre(1, 1, this);
            this[1, _height - 2] = new TileTerre(1, _height - 2, this);
            this[_width - 2, 1] = new TileTerre(_width - 2, 1, this);
            this[_width - 2, _height - 2] = new TileTerre(_width - 2, _height - 2, this);
            bool tld = true, tlr = true, trd = true, trl = true, blu = true, blr = true, bru = true, brl = true;
            while (i < 4 && (tld || tlr || trd || trl || blu || blr || bru || brl))
            {
                if (tld)
                {
                    this[1, 1 + i] = new TileTerre(1, 1 + i, this);
                    if (_random.Next() % 7 == 0) tld = false;
                }
                if (tlr)
                {
                    this[1 + i, 1] = new TileTerre(1 + i, 1, this);
                    if (_random.Next() % 7 == 0) tlr = false;
                }
                if (trd)
                {
                    this[_width - 2, 1 + i] = new TileTerre(_width - 2, 1 + i, this);
                    if (_random.Next() % 7 == 0) trd = false;
                }
                if (trl)
                {
                    this[_width - 2 - i, 1] = new TileTerre(_width - 2 - i, 1, this);
                    if (_random.Next() % 7 == 0) trl = false;
                }
                if (blu)
                {
                    this[1, _height - 2 - i] = new TileTerre(1, _height - 2 - i, this);
                    if (_random.Next() % 7 == 0) blu = false;
                }
                if (blr)
                {
                    this[1 + i, _height - 2] = new TileTerre(1 + i, _height - 2, this);
                    if (_random.Next() % 7 == 0) blr = false;
                }
                if (bru)
                {
                    this[_width - 2, _height - 2 - i] = new TileTerre(_width - 2, _height - 2 - i, this);
                    if (_random.Next() % 7 == 0) bru = false;
                }
                if (brl)
                {
                    this[_width - 2 - i, _height - 2] = new TileTerre(_width - 2 - i, _height - 2, this);
                    if (_random.Next() % 7 == 0) brl = false;
                }
                i++;
            }
        }

        // Indexeur pour aller chercher facilement des cases
        public Tile this[int x, int y]
        {
            get
            {
                if (x >= 0 && y >= 0 && x < _width && y < _height)
                    return _cases[x, y];
                throw new IndexOutOfRangeException($"{x}, {y} is outside the range 0-{_width - 1}, 0-{_height - 1}");
            }
            set
            {
                if (x >= 0 && y >= 0 && x < _width && y < _height)
                {
                    if (this[x, y] != null)
                    {

                        if (this[x, y].Hull != null)
                        {/*
                            RobotWar.Penumbra.Hulls.Remove(this[x, y].Hull);
                            if (RobotWar.Joueurs != null)
                                foreach (Light light in RobotWar.Joueurs[0].Lights)
                                {
                                    light.Position += Vector2.One;
                                    light.Position -= Vector2.One;
                                }
                            */
                        }
                        /*
                        if (this[x, y].Fire != null)
                            this[x, y].Fire = null;

                        TileTerre vide = this[x, y] as TileTerre;
                        if (vide != null)
                            if (vide.ContainsBomb)
                                vide.Bomb = null;
                                */
                    }

                    _cases[x, y] = value;
                }
            }
        }


        public void Draw(SpriteBatch sb, Rectangle clientRect)
        {
            foreach (Tile c in _cases)
                c.Draw(sb, TileWidth);
        }

        /// <summary>
        /// Tries to place a bonus at the specified spot in the map
        /// </summary>
        /// <param name="x">X coords of the case to place a bonus in</param>
        /// <param name="y">Y coords of the case to place a bonus in</param>
        /// <returns>True if a bonus was place, false otherwise</returns>
        public bool MakeRandomBonus(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _width || y >= _height)
                return false;
            if (!(this[x, y] is TileBarricade))
                return false;

            if (_random.Next() % 3 != 0)
                return false;

            //this[x, y] = new CaseBonus(x, y, this, _random);
            return true;

        }
    }

}
