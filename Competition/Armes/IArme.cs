using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Competition.Armes
{
    interface IArme
    {
        int CapaciteChargeur
        {
            get;
            set;
        }

        int QuantiteBallesDansChargeur
        {
            get;
            set;
        }

        int QuantiteTotaleBalles
        {
            get;
            set;
        }

        void Update(GameTime gameTime);
        void CommenceATirer(GameTime gameTime);
        void FiniDeTirer(GameTime gameTime);



    }
}