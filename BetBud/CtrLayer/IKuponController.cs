using System.Collections.Generic;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace CtrLayer {
    // KuponController interface med dennes metoder
    public interface IKuponController {
        Kupon OpretKupon();
        Kupon TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2, Kupon kupon);
        Kupon FjernKamp(Kamp kamp, Kupon kupon);
        double OddsUdregning();
        double MuligGevinst(Kupon kupon);
        bool BekræftKupon(Kupon kupon);
        IEnumerable<Kamp> GetAlleKampe();
        Kamp FindKamp(int kampId);
        IEnumerable<Kupon> GetAlleKuponer(Bruger bruger);
    }
}