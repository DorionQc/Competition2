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
        public static Texture2D TextureTerre;

        public static void init(ContentManager Content)
        {
            TextureBarricade = Content.Load<Texture2D>("Textures/TileBarricade");
            TextureTerre = Content.Load<Texture2D>("Textures/wood");
        }
    }
}
