using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Competition.Armes
{
    public abstract class OldArme
    {
        public OldArme(int pCapaciteChargeur, int pQuantiteTotalBalles)//EntityManager pentityManager)
        {
            m_CapaciteChargeur = pCapaciteChargeur;
            m_QuantiteBallesDansChargeur = pCapaciteChargeur;
            m_QuantiteTotalBalles = pQuantiteTotalBalles;
            //entityManager = pentityManager;
            IsShooting = false;
            m_TempsDernierTir = 0;
            m_TempsEntreChaqueTir = 0;
            IsReloading = false;
        }

        //EntityManager entityManager;

        public abstract bool FullAuto
        {
            get;
        }

        protected int m_CapaciteChargeur;
        protected int m_QuantiteBallesDansChargeur;
        protected int m_QuantiteTotalBalles;
        protected int m_CapaciteTotalBalles;

        protected double m_TempsDernierTir;
        protected double m_TempsEntreChaqueTir;

        protected bool IsShooting;
        protected bool IsReloading;

        public int CapaciteChargeur
        {
            get { return m_CapaciteChargeur; }
            set { m_CapaciteChargeur = value; }
        }

        public int QuantiteBallesDansChargeur
        {
            get { return m_QuantiteBallesDansChargeur; }
            set { m_QuantiteBallesDansChargeur = value; }
        }

        public int QuantiteTotalBalles
        {
            get { return m_QuantiteTotalBalles; }
            set { m_QuantiteTotalBalles = value; }
        }

        public int CapaciteTotalBalles
        {
            get { return m_CapaciteTotalBalles; }
            set { m_CapaciteTotalBalles = value; }
        }

        public abstract void  Update(GameTime gameTime, Vector2 Orientation);
        public abstract void  CommenceATirer(GameTime gameTime);
        public abstract void  FiniDeTirer(GameTime gameTime);
        
        

    }
}