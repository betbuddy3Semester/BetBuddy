using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using DALBetBud.Context;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;
using ModelLibrary.SeasonInterface;

namespace CtrLayer {
    public class SæsonController : ISæsonController {
        private readonly BrugerController brugerController = new BrugerController();

        public void SæsonAfslutning() {
            Setting setting = null;
            SæsonBeskrivelse sb = null;
            using (BetBudContext db = new BetBudContext()) {
                setting = db.Settings.FirstOrDefault(x => x.name == "Sæson");
                sb = db.AktuelSæsonInfo.OrderByDescending(x => x.SæsonBeskrivelseId).FirstOrDefault();
            }

            int sæsonId = int.Parse(setting.value);

            Sæson sæson = new Sæson {
                SæsonId = sæsonId,
                SæsonNavn = "test",
                SæsonPris = 0.0,
                SæsonPeriode = DateTime.Now,
                SæsonInfo = sb
            };

            sæson.SæsonBrugere = new List<SæsonBruger>();
            foreach (Bruger bruger in brugerController.getBrugere()) {
                sæson.SæsonBrugere.Add(new SæsonBruger {Bruger = bruger, BrugerPoints = bruger.Point});
            }

            sæsonId++;
            setting.value = sæsonId + "";
            foreach (SæsonBruger sæsonBruger in sæson.SæsonBrugere) {
                sæsonBruger.Bruger.Point = 10000;
            }
            GemSæson(sæson, setting);
        }

        private void GemSæson(Sæson sæson, Setting setting) {
            using (BetBudContext db = new BetBudContext()) {
                using (DbContextTransaction tranction = db.Database.BeginTransaction()) {
                    try {
                        foreach (SæsonBruger sæsonBruger in sæson.SæsonBrugere) {
                            db.Entry(sæsonBruger.Bruger).State = EntityState.Modified;
                        }
                        db.Entry(setting).State = EntityState.Modified;
                        db.Entry(sæson.SæsonInfo).State = EntityState.Unchanged;
                        db.Sæsoner.Add(sæson);
                        db.AktuelSæsonInfo.Add(new SæsonBeskrivelse {Beskrivelse = "sæson!"});

                        db.SaveChanges();
                        tranction.Commit();
                    }
                    catch (Exception e) {
                        tranction.Rollback();
                        Debug.WriteLine(e);
                    }
                }
            }
        }
    }
}