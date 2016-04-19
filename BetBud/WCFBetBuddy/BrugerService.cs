using ModelLibrary.Bruger;
using System;
using System.Linq;
using DALBetBud.Context;
using CtrLayer;
using System.Collections.Generic;

namespace WCFBetBuddy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BrugerService : IBrugerService
    {
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
    }
}


      