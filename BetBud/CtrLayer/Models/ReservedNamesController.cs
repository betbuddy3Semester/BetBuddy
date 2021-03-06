﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CtrLayer.Interfaces;
using DALBetBud.Context;
using ModelLibrary.Models.ReservedNames;
using System.Transactions;
namespace CtrLayer.Models {
    public class ReservedNamesController : IReservedNamesController {
        #region Methods

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

        public void UpdateOrInsetReservedName(ReservedNames reserved) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(reserved).State = reserved.ReservedNameId > 0 ? EntityState.Modified : EntityState.Added;
                db.SaveChanges();
            }
        }

        public void CheckAndRemoveExistName() {
            using (BetBudContext db = new BetBudContext()) {
                List<ReservedNames> toRemove =
                    db.ReservedNames.Where(y => DbFunctions.AddMinutes(y.Time, 5) < DateTime.Now).ToList();
                foreach (ReservedNames reservedNamese in toRemove) {
                    db.Entry(reservedNamese).State = EntityState.Deleted;
                }
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
        // tilføj transaction scope
        public IEnumerable<string> FeedBackReservedNames(string text, int id) {
            List<string> returnList = new List<string>();
            using (TransactionScope scope = new TransactionScope())
            {
                bool feedbackVar = CheckIfNameExistsInBrugerDb(text);
                if (!feedbackVar)
                {
                    ReservedNames name = new ReservedNames {Time = DateTime.Now, UserName = text};
                    if (id > 0)
                    {
                        name.ReservedNameId = id;
                        UpdateReservedName(name);
                        returnList.Add(name.ReservedNameId + "");

                        returnList.Add("Brugernavn er ledigt og reseveret på ny");
                        returnList.Add("2");
                    }
                    else
                    {
                        CreateReservedName(name);
                        returnList.Add(name.ReservedNameId + "");
                        returnList.Add("Brugernavn er ledigt og reseveret");
                        returnList.Add("3");
                    }
                }
                else
                {
                    if (id > 0)
                    {
                        ReservedNames name = new ReservedNames {ReservedNameId = id};
                        DeleteReservedName(name);
                    }
                    returnList.Add("0");

                    returnList.Add("Brugernavn er optaget");
                    returnList.Add("1");
                }
                scope.Complete();
            }
            return returnList;
        }

        #endregion
    }
}