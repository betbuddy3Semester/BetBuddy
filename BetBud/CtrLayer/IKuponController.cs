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
        bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        bool FjernKamp(Kamp kamp);
        double OddsUdregning();
        double MuligGevist();
        bool BekræftKupon();
    }
}
