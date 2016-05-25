using System;
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
                db.SaveChanges();
            }
        }

        public void CreateMultipleReservedNames(IEnumerable<ReservedNames> listofReservedNames) {
            using (BetBudContext db = new BetBudContext()) {
                db.ReservedNames.AddRange(listofReservedNames);
                db.SaveChanges();
            }
        }

        public void UpdateReservedName(ReservedNames reserved) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(reserved).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteReservedName(ReservedNames reserved) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(reserved).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        private bool CheckIfNameExistsInBrugerDb(string text) {
            using (BetBudContext db = new BetBudContext()) {
                if (db.Brugere.FirstOrDefault(x => x.BrugerNavn.ToLower().Equals(text.ToLower())) == null) {
                    if (db.ReservedNames.FirstOrDefault(y => y.UserName.ToLower().Equals(text.ToLower())) == null) {
                        return false;
                    }
                }

                return true;
            }
        }

        public Dictionary<string, string> FeedBackReservedNames(string text, int id) {
            Dictionary<string, string> returnList = new Dictionary<string, string>();
            bool feedbackVar = CheckIfNameExistsInBrugerDb(text);
            if (!feedbackVar) {
                ReservedNames name = new ReservedNames {
                    Time = DateTime.Now,
                    UserName = text
                };
                if (id > 0) {
                    name.ReservedNameId = id;
                    UpdateReservedName(name);
                    returnList["id"] = name.ReservedNameId + "";

                    returnList["statussearch"] = "bruger navn er ledig og reseveret på ny";
                }
                else {
                    CreateReservedName(name);
                    returnList["id"] = name.ReservedNameId + "";

                    returnList["statussearch"] = "bruger navn er ledig og reseveret";
                }
            }
            else {
                returnList["id"] = id + "";

                returnList["statussearch"] = "bruger navn er optaget";
            }
            return returnList;
        }
    }
}