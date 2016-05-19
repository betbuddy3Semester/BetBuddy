using System.Runtime.Serialization;

namespace ModelLibrary.Kupon
{
    [DataContract]
    public class DelKamp : IDelKamp
    {
        [DataMember]
        public int DelKampId { get; set; }

        [DataMember]
        public int KampId { get; set; }

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
            if (Kampe.VundetX == ValgtX)
            {
                return true;
            }

            if (Kampe.Vundet2 == Valgt2)
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

            if (ValgtX)
            {
                return Kampe.OddsX;
            }

            return Kampe.Odds2;
        }
    }
}