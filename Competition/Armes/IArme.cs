using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Competition.Armes
{
    public abstract class Arme
    {
        public Arme(int pCapaciteChargeur, int pQuantiteTotalBalles)//EntityManager pentityManager)
        {
            m_CapaciteChargeur = pCapaciteChargeur;
            m_QuantiteBallesDansChargeur = pCapaciteChargeur;
            m_QuantiteTotalBalles = pQuantiteTotalBalles;
            //entityManager = pentityManager;
        }

        //EntityManager entityManager;

        protected int m_CapaciteChargeur;
        protected int m_QuantiteBallesDansChargeur;
        protected int m_QuantiteTotalBalles;

        public abstract int CapaciteChargeur
        {
            get;
            set;
        }

        public abstract int QuantiteBallesDansChargeur
        {
            get;
            set;
        }

        public abstract int QuantiteTotaleBalles
        {
            get;
            set;
        }

        public abstract void  Update(GameTime gameTime);
        public abstract void  CommenceATirer(GameTime gameTime);
        public abstract void  FiniDeTirer(GameTime gameTime);
        
        

    }
}