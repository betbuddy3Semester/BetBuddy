using ModelLibrary.Models.Kupon;

namespace ModelLibrary.Interfaces.Interface_Kupon {
    public interface IDelKamp {
        #region Properties

        Kamp Kampe { get; set; }
        bool Valgt1 { get; set; }
        bool ValgtX { get; set; }
        bool Valgt2 { get; set; }

        #endregion

        #region Methods

        bool KampRigtig();
        double GetOdds();

        #endregion

    }
}