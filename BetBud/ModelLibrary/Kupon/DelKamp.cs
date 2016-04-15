using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Kupon
{
    public class DelKamp : IDelKamp
    {
        public bool Valgt1 { get; set; }
        public bool ValgtX { get; set; }
        public bool Valgt2 { get; set; }
        public IKamp Kampe { get; set; }

        public bool KampRigtig()
        {
            if (Kampe.Vundet1 == Valgt1)
            {
                return true;
            }
            else if (Kampe.VundetX == ValgtX)
            {
                return true;
            }

            else if (Kampe.Vundet2 == Valgt2)
            {
                return true;
            }

            return false;


        }

        public double GetOdds()
        {
            if (Valgt1)
            {
                return Kampe.Odds1;
            }

            else if (ValgtX)
            {
                return Kampe.OddsX;
            }

            else
            {
                return Kampe.Odds2;
            }
            

        }
    }
}
