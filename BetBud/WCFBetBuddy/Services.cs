using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CtrLayer;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    public class Services : IServices
    {
        #region BrugerService
        [DataMember]
        BrugerController brugerCtrl = new BrugerController();


        public Bruger getBruger(int id)
        {
            return brugerCtrl.getBruger(id);
        }

        public Bruger getBrugerEfterBrugernavn(string bnavn)
        {
            return brugerCtrl.GetBrugerEfterBrugerNavn(bnavn);
        }

        public IEnumerable<Bruger> getBrugere()
        {
            return brugerCtrl.getBrugere();
        }

        public void opdaterBruger(Bruger bruger)
        {
            brugerCtrl.opdaterBruger(bruger);
        }

        public void opretBruger(Bruger bruger)
        {
            brugerCtrl.opretBruger(bruger);
        }

        public void sletBruger(int id)
        {
            brugerCtrl.sletBruger(id);
        }
        #endregion

        #region KuponService
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
        #endregion


    }
}
