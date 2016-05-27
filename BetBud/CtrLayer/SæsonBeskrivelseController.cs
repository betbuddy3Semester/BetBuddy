using System.Data.Entity;
using System.Linq;
using DALBetBud.Context;
using ModelLibrary.SeasonInterface;

namespace CtrLayer {
    public class SæsonBeskrivelseController : ISæsonBeskrivelseController {

        public SæsonBeskrivelse HentNuværendeSæson() {
            SæsonBeskrivelse sb;
            using (BetBudContext db = new BetBudContext()) {
                sb = db.AktuelSæsonInfo.OrderByDescending(x => x.SæsonBeskrivelseId).FirstOrDefault();
            }
            
            return sb;
        }

        public SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut) {
            using (BetBudContext db = new BetBudContext()) {
                SæsonBeskrivelse sb = HentNuværendeSæson();
                sb.Beskrivelse = beskrivelse;
                sb.SlutDato = slut;
                sb.StartDato = start;
                db.Entry(sb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return HentNuværendeSæson();
        }
    }
}