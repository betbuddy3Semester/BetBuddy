using System.Linq;
using DALBetBud.Context;
using ModelLibrary.SeasonInterface;

namespace CtrLayer {
    internal class SæsonBeskrivelseController : ISæsonBeskrivelseController {
        public SæsonBeskrivelse HentNuværendeSæson() {
            SæsonBeskrivelse sb;
            using (BetBudContext db = new BetBudContext()) {
                sb = db.AktuelSæsonInfo.LastOrDefault();
            }
            return sb;
        }

        public SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut) {
            using (BetBudContext db = new BetBudContext()) {
                SæsonBeskrivelse sb = HentNuværendeSæson();
                sb.Beskrivelse = beskrivelse;
                sb.SlutDato = slut;
                sb.StartDato = start;
                db.SaveChanges();
            }
            return HentNuværendeSæson();
        }
    }
}