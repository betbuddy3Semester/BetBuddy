﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CtrLayer.Interfaces;
using DALBetBud.Context;
using ModelLibrary.Models.Bruger;

namespace CtrLayer.Models {
    public class BrugerController : IBrugerController {
        #region Methods

        public Bruger getBruger(int id) {
            using (BetBudContext db = new BetBudContext()) {
                return db.Brugere.Find(id);
            }
        }

        public IEnumerable<Bruger> getBrugere() {
            using (BetBudContext db = new BetBudContext()) {
                return db.Brugere.DefaultIfEmpty().ToList();
            }
        }

        public void opdaterBruger(Bruger bruger) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(bruger).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void opretBruger(Bruger bruger) {
            //Email constraints 
            Match matchEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(bruger.Email);

            //Number constraints
            Match matchName = new Regex(@"^[a-åA-Å' '-'\s]{1,40}$").Match(bruger.Navn);
            bruger.Password = GenerateSaltedHash(bruger.Password);

            bruger.Point = 10000;
            //Brugernavn constraints 1-24 karaktere, Skal starte med a-z, Må indeholde .,-_, må ikke ende på .,-_
            Match matchBruger = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9\._\-]{0,23}[^.-]$").Match(bruger.BrugerNavn);
            //var matchBrugernavn = new Regex(@"(\.|\-|\._|\-_)$").Match(bruger.BrugerNavn);
            Bruger b = GetBrugerEfterBrugerNavn(bruger.BrugerNavn);

            if (matchEmail.Success && matchName.Success && matchBruger.Success && b == null) {
                using (BetBudContext db = new BetBudContext()) {
                    db.Brugere.Add(bruger);
                    db.SaveChanges();
                }
            }
        }

        public void sletBruger(int id) {
            using (BetBudContext db = new BetBudContext()) {
                Bruger bruger = new Bruger();
                bruger.BrugerId = id;
                db.Entry(bruger).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Bruger GetBrugerEfterBrugerNavn(string bnavn) {
            using (BetBudContext db = new BetBudContext()) {
                return db.Brugere.FirstOrDefault(b => b.BrugerNavn == bnavn);
            }
        }

        public Bruger logIndBruger(string bNavn, string pWord) {
            using (BetBudContext db = new BetBudContext()) {
                string passHash = GenerateSaltedHash(pWord);
                Bruger bruger = db.Brugere.FirstOrDefault(x => x.BrugerNavn.Equals(bNavn) && x.Password.Equals(passHash));

                return bruger;
            }
        }

        //Hash password - salt password og hash igen.
        private string GenerateSaltedHash(string password) {
            byte[] hashPass = Encoding.UTF8.GetBytes(Encode(password));
            byte[] endPass = new byte[hashPass.Length*2];
            for (int i = 0; i < hashPass.Length; i++) {
                endPass[i*2] = hashPass[i];
                endPass[i*2 + 1] = hashPass[hashPass.Length - 1 - i];
            }
            return Encode(Convert.ToBase64String(endPass));
        }

        //Opret en password hash.
        private string Encode(string value) {
            SHA1 hash = SHA1.Create();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }

        public void AddPoints(double amount, string navn, Bruger b) {
            using (BetBudContext db = new BetBudContext()) {
                b = GetBrugerEfterBrugerNavn(navn);

                b.Point += amount;

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void SubtractPoints(double amount, string navn, Bruger b) {
            using (BetBudContext db = new BetBudContext()) {
                b = GetBrugerEfterBrugerNavn(navn);

                b.Point -= amount;

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<Bruger> getHighscores() {
            using (BetBudContext db = new BetBudContext()) {
                //var result = db.Brugere.GroupBy(x => x.Navn).Select(g => g.OrderByDescending(x => x.Point));
                IOrderedQueryable<Bruger> result = db.Brugere.OrderByDescending(x => x.Point);
                return result.ToList();
                //return result;
            }
        }

        #endregion

    }
}