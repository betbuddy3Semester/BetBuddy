using ModelLibrary.Bruger;
using System;
using System.Linq;
using DALBetBud.Context;


namespace WCFBetBuddy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BrugerService : IBrugerService
    {



        public Bruger getBruger(int id)
        {
            using (BetBudContext db = new BetBudContext())
            {

                return db.Brugere.Find(id);

            }
        }

        public System.Collections.Generic.IEnumerable<Bruger> getBrugere()
        {
            using (BetBudContext db = new BetBudContext())
            {

                return db.Brugere.ToList();

            }
        }

        public void opdaterBruger(Bruger bruger)
        {
            using (BetBudContext db = new BetBudContext())
            {

                db.Entry(bruger).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void opretBruger(Bruger bruger)
        {
            throw new NotImplementedException();
        }

        public void sletBruger(int id)
        {
            using (BetBudContext db = new BetBudContext())
            {

                Bruger bruger = new Bruger();
                bruger.BrugerId = id;
                db.Entry(bruger).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}