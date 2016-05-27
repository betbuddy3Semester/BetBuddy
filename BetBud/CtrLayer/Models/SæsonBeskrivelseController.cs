using System.Data.Entity;
using System.Linq;
using CtrLayer.Interfaces;
using DALBetBud.Context;
using ModelLibrary.Models.Sæson;

namespace CtrLayer.Models {
    internal class SæsonBeskrivelseController : ISæsonBeskrivelseController {
        #region Methods

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

        #endregion
    }
}