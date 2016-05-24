using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DALBetBud.Context;
using ModelLibrary.Bruger;

namespace CtrLayer {
    public class ReservedNamesController : IReservedNamesController {
        public ReservedNames GetReservedNames(int id) {
            using (BetBudContext db = new BetBudContext()) {
                return db.ReservedNames.SingleOrDefault(x => x.ReservedNameId.Equals(id));
            }
        }

        public IEnumerable<ReservedNames> GetAllReservedNames() {
            using (BetBudContext db = new BetBudContext()) {
                return db.ReservedNames.ToList();
            }
        }

        public void CreateReservedName(ReservedNames reserved) {
            using (BetBudContext db = new BetBudContext()) {
                db.ReservedNames.Add(reserved);
            }
        }

        public void CreateMultipleReservedNames(IEnumerable<ReservedNames> listofReservedNames) {
            using (BetBudContext db = new BetBudContext()) {
                db.ReservedNames.AddRange(listofReservedNames);
            }
        }

        public void UpdateReservedName(ReservedNames reserved) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(reserved).State = EntityState.Modified;
            }
        }

        public void DeleteReservedName(ReservedNames reserved) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(reserved).State = EntityState.Deleted;
            }
        }
    }
}