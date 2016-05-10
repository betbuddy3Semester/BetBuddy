using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DALBetBud.Context;
using ModelLibrary.Bruger;

namespace CtrLayer
{
    public class BrugerController : IBrugerController
    {
        public Bruger getBruger(int id)
        {
            using (var db = new BetBudContext())
            {
                return db.Brugere.Find(id);
            }
        }

        public IEnumerable<Bruger> getBrugere()
        {
            using (var db = new BetBudContext())
            {
                return db.Brugere.ToList();
            }
        }

        public void opdaterBruger(Bruger bruger)
        {
            using (var db = new BetBudContext())
            {
                db.Entry(bruger).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void opretBruger(Bruger bruger)
        {
            //Email constraints 
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var matchEmail = regex.Match(bruger.Email);

            //Number constraints
            var regx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
            var matchName = regx.Match(bruger.Navn);
            bruger.Password = Encode(bruger.Password);


            if (matchEmail.Success && matchName.Success)

            {
                using (var db = new BetBudContext())
                {
                    db.Brugere.Add(bruger);
                    db.SaveChanges();
                }
            }
        }

        public void sletBruger(int id)
        {
            using (var db = new BetBudContext())
            {
                var bruger = new Bruger();
                bruger.BrugerId = id;
                db.Entry(bruger).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Bruger GetBrugerEfterBrugerNavn(string bnavn)
        {
            using (var db = new BetBudContext())
            {
                return db.Brugere.First(b => b.BrugerNavn == bnavn);
            }
        }

        public Bruger logIndBruger(string bNavn, string pWord)
        {
            using (var db = new BetBudContext())

            {
                var passHash = Encode(pWord);
                var bruger = db.Brugere.Where(x => x.BrugerNavn.Equals(bNavn) && x.Password.Equals(passHash)).FirstOrDefault();

                return bruger;
            }
        }


        public string Encode(string value)
        {
            var hash = SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }
}