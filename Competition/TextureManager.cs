using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;

namespace Competition
{
    public static class TextureManager
    {
        public static Texture2D TextureBarricade;
        public static Texture2D[] TextureTerre;

        public static void init(ContentManager Content)
        {
            //Environnement
            TextureBarricade = Content.Load<Texture2D>("Textures/TileBarricade");
<<<<<<< HEAD
<<<<<<< HEAD
            TextureTerre = Content.Load<Texture2D>("Textures/wood");
=======
=======
>>>>>>> 14d1bb2bfb60a74b14c1d0aae9048b85f3265337

            //Arrière-Plan
            TextureTerre = new Texture2D[2];
            TextureTerre[0] = Content.Load<Texture2D>("Textures/TileTerre1.png");
            TextureTerre[1] = Content.Load<Texture2D>("Textures/TileTerre2.png");

            //Personnages

<<<<<<< HEAD
>>>>>>> 14d1bb2bfb60a74b14c1d0aae9048b85f3265337
=======
>>>>>>> 14d1bb2bfb60a74b14c1d0aae9048b85f3265337
        }
    }
}
