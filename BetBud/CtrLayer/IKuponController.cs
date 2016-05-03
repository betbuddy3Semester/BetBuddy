using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Kupon;

namespace CtrLayer
{
    public interface IKuponController
    {
        void OpretKupon();
        Kupon TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2, Kupon kupon);
        bool FjernKamp(Kamp kamp);
        double OddsUdregning();
        double MuligGevist();
        bool BekræftKupon();
        IEnumerable<Kamp>GetAlleKampe();
        Kamp FindKamp(int KampId);
    }
}
