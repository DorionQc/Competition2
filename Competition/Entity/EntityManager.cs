using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Competition.Jeu;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Competition.Entity
{
    public class EntityManager
    {
        // Singleton! :D
        private List<Entity> _entities;

        private object someLock;

        private static EntityManager _instance;
        
        private EntityManager() : this(null, null) { }

        private EntityManager(Player player, Map m)
        {
            _entities = new List<Entity>();
            Player = player;
            Map = m;
            someLock = new object();
        }

        public static EntityManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("Instance inexistante. Utilisez InitInstance avant d'utiliser l'instance");
                return _instance;
            }
        }

        public static void InitInstance(Player player, Map m)
        {
            if (_instance != null)
            {
                _instance._entities = new List<Entity>();
                _instance.Player = player;
                _instance.Map = m;
            }
            _instance = new EntityManager(player, m);
        }

        public List<Entity> Entities => _entities;

        public Player Player { get; set; }

        public Map Map { get; set; }

        public void Add(Entity e)
        {
            lock (someLock)
            {
                _entities.Add(e);
            }
        }

        public bool Remove(Entity e)
        {
            lock (someLock)
            {
                return _entities.Remove(e);
            }
        }

        public void TickPlayer(GameTime gameTime)
        {
            //TODO : Logique de tick du joueur (mouvement, etc)
        }

        public void TickEntities(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sb, Rectangle clientRect)
        {

        }

        public void DrawPlayers(SpriteBatch sb, Rectangle clientRect)
        {

        }

    }
}
