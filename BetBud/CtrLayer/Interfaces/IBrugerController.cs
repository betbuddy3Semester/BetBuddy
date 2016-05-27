using System.Collections.Generic;
using ModelLibrary.Models.Bruger;

namespace CtrLayer.Interfaces {
    public interface IBrugerController {
        #region Properties

        Bruger getBruger(int id);

        #endregion

        #region Methods

        IEnumerable<Bruger> getBrugere();

        void opretBruger(Bruger bruger);

        void opdaterBruger(Bruger bruger);

        void sletBruger(int id);

        #endregion

    }
}