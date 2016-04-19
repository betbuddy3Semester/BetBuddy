using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CtrLayer;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    class KuponService : IKuponService
    {
        KuponController NyKuponController = KuponController.GetKuponController();

        public bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            bool fundetData = NyKuponController.TilføjKamp(kamp, valgt1, valgtX, valgt2);
            return fundetData;
        }

        public bool FjernKamp(Kamp kamp)
        {
            bool dataFjernes = NyKuponController.FjernKamp(kamp);
            return dataFjernes;
        }

        public double OddsUdregning()
        {
            return NyKuponController.OddsUdregning();
        }

        public double MuligGevist()
        {
            return NyKuponController.MuligGevist();
        }

        public bool BekræftKupon()
        {
            return NyKuponController.BekræftKupon();
        }

        public Kamp FindKamp(int KampId)
        {
            return NyKuponController.FindKamp(KampId);
        }

        public List<Kamp> GetAlleKampe()
        {
            return NyKuponController.GetAlleKampe();
        }
    }
}
