using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Competition.Jeu.Tiles;

namespace Competition.Jeu
{
    public class ScreenJeu : IPartieDeJeu
    {

        Map _map;
        

        public ScreenJeu()
        {
            _map = new Map(30, 50, RobotWar.Screen.ClientBounds);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _map.Draw(spriteBatch, RobotWar.Screen.ClientBounds);
        }

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
