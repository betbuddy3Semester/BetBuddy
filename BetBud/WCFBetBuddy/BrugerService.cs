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
        BrugerController BC = new BrugerController();

        public Bruger getBruger(int id)
        {
            return BC.getBruger(id);
        }

        public IEnumerable<Bruger> getBrugere()
        {
            return BC.getBrugere();
        }

        public void opdaterBruger(Bruger bruger)
        {
            BC.opdaterBruger(bruger);
        }

        public void opretBruger(Bruger bruger)
        {
            BC.opretBruger(bruger);
        }

        public void sletBruger(int id)
        {
            BC.sletBruger(id);
        }
    }
}


      