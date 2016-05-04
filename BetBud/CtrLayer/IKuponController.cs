using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace CtrLayer
{
    public interface IKuponController
    {
        Kupon OpretKupon();
        Kupon TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2, Kupon kupon);
        bool FjernKamp(Kamp kamp);
        double OddsUdregning();
        double MuligGevist();
        bool BekræftKupon(Kupon kupon);
        IEnumerable<Kamp>GetAlleKampe();
        Kamp FindKamp(int KampId);
        IEnumerable<Kupon> GetAlleKuponer(Bruger bruger);
    }
}
