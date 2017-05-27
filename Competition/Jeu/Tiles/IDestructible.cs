using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Competition.Entity;




namespace Competition.Jeu.Tiles
{
    public interface IDestructible
    {
        int PointDeVie { get; set; }
        int Damage(Entity.Entity Source, int Degats, Vector2 Velocite);
        int Damage(Entity.Entity Source, int Degats, Vector2 Velocite, Entity.Entity Bullet);
    }
}
