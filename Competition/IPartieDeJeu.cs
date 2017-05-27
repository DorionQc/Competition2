using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Competition
{
    public interface IPartieDeJeu
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
