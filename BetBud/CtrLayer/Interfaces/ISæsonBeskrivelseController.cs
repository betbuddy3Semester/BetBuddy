using ModelLibrary.Interfaces.SeasonInterface;
using ModelLibrary.Models.Sæson;

namespace CtrLayer.Interfaces {
    internal interface ISæsonBeskrivelseController {
        #region Methods

        SæsonBeskrivelse HentNuværendeSæson();

        SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut);

        #endregion

    }
}