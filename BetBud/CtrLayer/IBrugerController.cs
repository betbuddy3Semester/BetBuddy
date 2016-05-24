using System.Collections.Generic;
using ModelLibrary.Bruger;

namespace CtrLayer
{
    public interface IBrugerController
    {
        //Returner den enkelte bruger ud fra id

        Bruger getBruger(int id);

        //Returner alle brugere

        IEnumerable<Bruger> getBrugere();


        void opretBruger(Bruger bruger);


        void opdaterBruger(Bruger bruger);


        void sletBruger(int id);
    }
}