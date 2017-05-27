using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competition.Armes;
using Competition.Entity;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Competition.Jeu.Tiles;

namespace Competition.Jeu
{
    public class ScreenJeu : IPartieDeJeu
    {

        Map _map;
        private Entity.EntityManager em;
        private Entity.Player m_Player;
        public ScreenJeu()
        {
            _map = new Map(20, 20, RobotWar.Screen.ClientBounds);
            m_Player = new Player(TextureManager.TextureTerre,new Vector2(250,250),new Vector2(100,50), new Vector2(0,0), new Weapons[] {new Pistol()});
            EntityManager.InitInstance(m_Player,_map);
            
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _map.Draw(spriteBatch, RobotWar.Screen.ClientBounds);
            m_Player.Draw(spriteBatch, RobotWar.Screen.ClientBounds);
        }

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
