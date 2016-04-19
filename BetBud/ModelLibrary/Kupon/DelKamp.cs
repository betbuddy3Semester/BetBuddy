using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Kupon
{
    [DataContract]
    public class DelKamp : IDelKamp
    {
        [DataMember]
        public bool Valgt1 { get; set; }
        [DataMember]
        public bool ValgtX { get; set; }
        [DataMember]
        public bool Valgt2 { get; set; }
        [DataMember]
        public Kamp Kampe { get; set; }
        
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
