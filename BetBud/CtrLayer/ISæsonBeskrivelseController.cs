using ModelLibrary.SeasonInterface;

namespace CtrLayer {
    internal interface ISæsonBeskrivelseController {
        SæsonBeskrivelse HentNuværendeSæson();

        SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut);
    }
}