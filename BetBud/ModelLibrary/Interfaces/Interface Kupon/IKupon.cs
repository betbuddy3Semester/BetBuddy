using System.Collections.Generic;
using ModelLibrary.Models.Bruger;
using ModelLibrary.Models.Kupon;

namespace ModelLibrary.Interfaces.Interface_Kupon {
    public interface IKupon {
        #region Properties

        bool Kontrolleret { get; set; }
        double Point { get; set; }
        List<DelKamp> delKampe { get; set; }
        Bruger Bruger { get; set; }
        int SæsonId { get; set; }

        #endregion

        #region Methods

        bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        bool FjernKamp(Kamp kamp);
        double OddsUdregning();
        double MuligGevist();

        #endregion
    }
}