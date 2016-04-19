using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    public class Services : IBrugerService, IKuponService
    {
        public bool BekræftKupon()
        {
            throw new NotImplementedException();
        }

        public Kamp FindKamp(int KampId)
        {
            throw new NotImplementedException();
        }

        public bool FjernKamp(Kamp kamp)
        {
            throw new NotImplementedException();
        }

        public List<Kamp> GetAlleKampe()
        {
            throw new NotImplementedException();
        }

        public Bruger getBruger(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bruger> getBrugere()
        {
            throw new NotImplementedException();
        }

        public Bruger getBrugerEfterBrugernavn(string bnavn)
        {
            throw new NotImplementedException();
        }

        public double MuligGevist()
        {
            throw new NotImplementedException();
        }

        public double OddsUdregning()
        {
            throw new NotImplementedException();
        }

        public void opdaterBruger(Bruger bruger)
        {
            throw new NotImplementedException();
        }

        public void opretBruger(Bruger bruger)
        {
            throw new NotImplementedException();
        }

        public void sletBruger(int id)
        {
            throw new NotImplementedException();
        }

        public bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            throw new NotImplementedException();
        }
    }
}
