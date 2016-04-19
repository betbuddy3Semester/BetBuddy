using DALBetBud.Context;
using ModelLibrary.Bruger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Text.RegularExpressions;

namespace CtrLayer
{
    public class BrugerController : IBrugerController
    {
        public Bruger getBruger(int id)
        {
            using (BetBudContext db = new BetBudContext())
            {

                return db.Brugere.Find(id);

            }

        }

        public Bruger GetBrugerEfterBrugerNavn(String bnavn)
        {
            using (BetBudContext db = new BetBudContext())
            {

                return db.Brugere.First(b => b.BrugerNavn == bnavn);
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
            //Email constraints 
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match matchEmail = regex.Match(bruger.Email);

            //Number constraints
            Regex regx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
            Match matchName = regx.Match(bruger.BrugerNavn);


        
            if (matchEmail.Success && matchName.Success)
            
            {
                using (BetBudContext db = new BetBudContext())
                {
                    db.Brugere.Add(bruger);
                    db.SaveChanges();
                }

            }
            else
            {

            }


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

