using System.Collections.Generic;
using ModelLibrary.Kupon;

namespace ModelLibrary.Interface_Kupon {
    public interface IKupon {
        bool Kontrolleret { get; set; }
        double Point { get; set; }
        List<DelKamp> delKampe { get; set; }
        Bruger.Bruger Bruger { get; set; }
        int SæsonId { get; set; }
        bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        bool FjernKamp(Kamp kamp);
        double OddsUdregning();
        double MuligGevist();
    }
}