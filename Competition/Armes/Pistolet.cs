using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Competition.Armes
{
    class Pistolet : OldArme
    {
        private bool m_PeutTirer;
        public Pistolet(int pCapaciteChargeur, int pQuantiteTotalBalles) :base(pCapaciteChargeur,pQuantiteTotalBalles)
        {
            m_PeutTirer = true;
        }

        public override bool FullAuto
        {
            get { return false; }
        }

        public override void Update(GameTime gameTime, Vector2 Orientation)
        {
            if (IsShooting && m_PeutTirer)
            {
                m_PeutTirer = false;
                IsShooting = false;
                if (gameTime.TotalGameTime.TotalMilliseconds - m_TempsDernierTir > m_TempsEntreChaqueTir)
                {
                    if (QuantiteBallesDansChargeur > 0)
                    {
                        Tirer(Orientation);
                        QuantiteBallesDansChargeur--;
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        public override void CommenceATirer(GameTime gameTime)
        {
            IsShooting = true;
        }

        public override void FiniDeTirer(GameTime gameTime)
        {
            m_PeutTirer = true;
        }

        private void Tirer(Vector2 Orientation)
        {
            //TODO Implement shooting mecanics


        }

        
        
    }
}
