using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DALBetBud.Context;
using ModelLibrary.Bruger;
using System.Collections;

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
            var matchEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(bruger.Email);

            //Number constraints
            var matchName = new Regex(@"^[a-åA-Å' '-'\s]{1,40}$").Match(bruger.Navn);
            bruger.Password = GenerateSaltedHash(bruger.Password);

            //Brugernavn constraints 1-24 karaktere
            //Skal starte med a-z
            // må indeholde .,-_
            //Må ikke ende på .,-_
            var matchBruger = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9\._\-]{0,23}[^.-]$").Match(bruger.BrugerNavn);
            //var matchBrugernavn = new Regex(@"(\.|\-|\._|\-_)$").Match(bruger.BrugerNavn);
            Bruger b = GetBrugerEfterBrugerNavn(bruger.BrugerNavn);


            if (matchEmail.Success && matchName.Success && matchBruger.Success && b == null)
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
                return db.Brugere.FirstOrDefault(b => b.BrugerNavn == bnavn);
            }
        }

        public Bruger logIndBruger(string bNavn, string pWord)
        {
            using (var db = new BetBudContext())
            {
                var passHash = GenerateSaltedHash(pWord);
                var bruger = db.Brugere.Where(x => x.BrugerNavn.Equals(bNavn) && x.Password.Equals(passHash)).FirstOrDefault();

                return bruger;
            }
        }

        //hash password - salt password og hash igen
        private string GenerateSaltedHash(String password)
        {
            byte[] hashPass = Encoding.UTF8.GetBytes(Encode(password));
            byte[] endPass = new byte[hashPass.Length * 2];
            for (var i = 0; i < hashPass.Length; i++)
            {
                endPass[i * 2] = hashPass[i];
                endPass[(i * 2) + 1] = hashPass[hashPass.Length - 1 - i];
            }
            return Encode(Convert.ToBase64String(endPass));
        }


        //Opret en password hash
        private string Encode(string value)
        {
            var hash = SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }

        public void AddPoints(double amount, string navn, Bruger b)
        {

            using (var db = new BetBudContext())
            {
                b = GetBrugerEfterBrugerNavn(navn);

                b.Point += amount;

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void SubtractPoints(double amount, string navn, Bruger b)
        {

            using (var db = new BetBudContext())
            {
                b = GetBrugerEfterBrugerNavn(navn);

                b.Point -= amount;

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();

            }


        }

        /*public Bruger getHighscores()

        {

            using (var db = new BetBudContext())
            {
                var result = db.Brugere.GroupBy(x => x.Navn).Select(g => g.OrderByDescending(x => x.Point).First());
                return result;
            }
            
        }
        */

        /*public List<Bruger> getHighscores()
        {
            using (var db = new BetBudContext())
            {
                List<Bruger> TopBruger = new List<Bruger>();
                Bruger topB = GetBrugerEfterBrugerNavn(db.Brugere.Select(p => p.Point).Max));
                TopBruger.Add(topB);
                return TopBruger;
                
            }

        }*/




    }
}