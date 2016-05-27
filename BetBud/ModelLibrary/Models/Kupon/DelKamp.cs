using System.Runtime.Serialization;
using ModelLibrary.Interfaces.Interface_Kupon;

namespace ModelLibrary.Models.Kupon {
    [DataContract]
    public class DelKamp : IDelKamp {
        #region Properties

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

        #endregion

        #region Methods

        public bool KampRigtig() {
            if (Kampe.Vundet1 == Valgt1) {
                return true;
            }
            if (Kampe.VundetX == ValgtX) {
                return true;
            }
            if (Kampe.Vundet2 == Valgt2) {
                return true;
            }
            return false;
        }

        public double GetOdds() {
            if (Valgt1) {
                return Kampe.Odds1;
            }
            if (ValgtX) {
                return Kampe.OddsX;
            }
            return Kampe.Odds2;
        }

        #endregion

    }
}