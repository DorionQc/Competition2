using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competition.Armes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Competition.Entity
{
    class Player : Entity
    {
        private Weapons[] m_WeaponList;
        public Player(Texture2D[] EntityTextures, Vector2 StartPosition, Vector2 StartSize, Vector2 StartVelocity, Weapons[] pWeapons, double AnimationTimerStart = 0.0,
            double AnimationTimerDuration = 1000.0/*millisecondes*/, bool AnimationLoop = true) :base(EntityTextures, StartPosition, StartSize, StartVelocity, AnimationTimerStart, AnimationTimerDuration, AnimationLoop)
        {
            m_WeaponList = new Weapons[1];
            m_WeaponList[0] = new Pistol();
        }

    }
}
