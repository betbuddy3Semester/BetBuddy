using ModelLibrary.Models.Bruger;

namespace ModelLibrary.Interfaces.SeasonInterface {
    public interface ISæsonBruger {
        #region Properties

        Bruger Bruger { get; set; }
        double BrugerPoints { get; set; }

        #endregion

    }
}