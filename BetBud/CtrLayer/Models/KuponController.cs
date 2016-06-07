using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CtrLayer.Interfaces;
using DALBetBud.Context;
using ModelLibrary.Models.Bruger;
using ModelLibrary.Models.Kupon;

namespace CtrLayer.Models {
    public class KuponController : IKuponController {
        // instance variable af kupon 
        public Kupon NyKupon;

        // Metode til at oprette kuponen og returnere en ny kupon til KuponControlleren 
        public Kupon OpretKupon() {
            NyKupon = new Kupon();
            return NyKupon;
        }

        // Metode til at tilføje en kamp til kuponen. Kalder metoden TilføjKamp i modellaget.  Kontrollere at kuponen er
        // oprettet. Search igennem delKampe og tilføjer den valgte kamp der er i delKamp, hvis kampId passer overens med hinanden. Returnere 
        // variablen fundet. Hvis den valgte kamp ikke er  i listen delKampe, returneres kupon uden kampen.
        // Det vil sige at hvis kampen allerede er på kuponen, så skal den ikke tilføjes.
        public Kupon TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2, Kupon kupon) {
            bool fundet = false;
            foreach (DelKamp delKamp in kupon.delKampe) {
                if (delKamp.Kampe.KampId == kamp.KampId) {
                    fundet = true;
                }
            }
            if (kupon != null && fundet == false) {
                kupon.TilføjKamp(kamp, valgt1, valgtX, valgt2);
            }
            return kupon;
        }

        // Metode til at fjerne en kamp fra sin kupon. Først kontrollere metoden om der er en kupon, og fjerner derefter 
        // den valgte kamp.
        public Kupon FjernKamp(Kamp kamp, Kupon kupon) {
            if (kupon != null) {
                kupon.FjernKamp(kamp);
            }
            return kupon;
        }

        // Metode til at lave oddsudregningen fra modellaget. Kontrollere om kuponen findes og laver derefter
        // udregningen på de valgte kampe og returnere det samlede odds. Hvis ikke kuponen er oprettet returnes 0,0. 
        public double OddsUdregning() {
            if (NyKupon != null) {
                return NyKupon.OddsUdregning();
            }
            return 0.0;
        }

        // Metode til at udregne den mulige gevist som brugeren kan vinde. MuligGevinst kalder metoden fra modellaget
        // som udregner gevisten. Kontrollere om kuponen er oprettet, og returnere denne med den mulige gevinst. Hvis ikke kuponen er oprettet
        // returneres 0,0.

        public double MuligGevinst(Kupon kupon) {
            if (kupon != null) {
                return kupon.MuligGevist();
            }
            return 0.0;
        }

        // Metode til at bekræfte kuponen. Der oprettes en ny forbindelse til databasen via BetBudContext klassen. 
        // For hver kamp der er i listen delKampe, sendes ind i variablen kamp. 
        // Unchanged betyder at objektet kamp ikke bliver ændret i Databasen, 
        // Samme sker med kupon.bruger. Kuponen bliver tilføjet og gemt. 
        public bool BekræftKupon(Kupon kupon) {
            kupon.CreateDateTime = DateTime.Now;
            if (kupon.delKampe.Count > 0) {
                using (BetBudContext db = new BetBudContext()) {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction(IsolationLevel.ReadCommitted)
                        ) {
                        try {
                            foreach (DelKamp kamp in kupon.delKampe) {
                                db.Entry(kamp.Kampe).State = EntityState.Unchanged;
                            }
                            db.Entry(kupon.Bruger).State = EntityState.Modified;
                            Setting setting = db.Settings.FirstOrDefault(x => x.name == "Sæson");
                            kupon.SæsonId = int.Parse(setting.value);
                            db.Kuponer.Add(kupon);
                            db.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception) {
                            transaction.Rollback();
                        }
                    }
                }
            }
            return false;
        }

        // Metode der henter alle kampe i Databasen. Der oprettes en ny forbindelse til databasen som returnere Kampe på en liste. 
        public IEnumerable<Kamp> GetAlleKampe() {
            using (BetBudContext db = new BetBudContext()) {
                return db.Kampe.ToList();
            }
        }

        // Metode der bruges til at finde en kamp udfra kampId i databasen. Der opretter en ny forbindelse til databasen via BetBudContext,  
        // den kamp der stemmer overens med kampId ´et sendes bliver gemt i lokal variablen kamp som efterfølgende bliver returneret.
        public Kamp FindKamp(int kampId) {
            using (BetBudContext db = new BetBudContext()) {
                Kamp kamp = db.Kampe.Find(kampId);
                return kamp;
            }
        }

        // Metode til at hente alle brugerens allerede eksisterende kuponer. Der oprettes en ny forbindelse til databasen via BetBudContext.
        // Databasen returnere alle brugerens kuponer hvis brugerId stemmer overens med brugerId og tilføjer disse til en liste.
        public IEnumerable<Kupon> GetAlleKuponer(Bruger bruger) {
            using (BetBudContext db = new BetBudContext()) {
                return
                    db.Kuponer.Include(x => x.delKampe.Select(y => y.Kampe))
                        .Include(x => x.Bruger)
                        .Where(allebrugerkuponger => allebrugerkuponger.BrugerId == bruger.BrugerId)
                        .ToList();
            }
        }

        //Metode til at hente kuponen
        public Kupon GetKupon() {
            return NyKupon;
        }

        // Metode til at Set kuponen, this.NyKupon da det er den pågældende kupon i metoden der er tale om.
        public void SetKupon(Kupon kupon) {
            NyKupon = kupon;
        }

        // Metode til at fjerne kuponen. 

        public void FjernKupon() {
            NyKupon = null;
        }

        public void ApiGetKampe() {
            Setting apiSetting = getLastApiCall();
            string lastApiDate = "http://odds.mukuduk.dk/?timeStamp=" + apiSetting.value;
            XElement oddsUrl = XElement.Load(lastApiDate);
            Kamp[] kampe =
                oddsUrl.Elements("kamp")
                    .Select(
                        p =>
                            new Kamp {
                                HoldVsHold = p.Element("text").Value,
                                Odds1 = double.Parse(p.Element("odds1").Value, CultureInfo.InvariantCulture),
                                OddsX = double.Parse(p.Element("oddsx").Value, CultureInfo.InvariantCulture),
                                Odds2 = double.Parse(p.Element("odds2").Value, CultureInfo.InvariantCulture),
                                KampStart = DateTime.Parse(p.Element("kampStart").Value),
                                Aflyst = bool.Parse(p.Element("aflyst").Value),
                                Vundet1 = bool.Parse(p.Element("vundet1").Value),
                                VundetX = bool.Parse(p.Element("vundetx").Value),
                                Vundet2 = bool.Parse(p.Element("vundet2").Value),
                                KampId = int.Parse(p.Element("KampId").Value)
                            })
                    .ToArray();
            if (kampe.Any())
                storeNewKampe(kampe);

            apiSetting.value = DateTime.Now + "";
            updateSetting(apiSetting);

            UpdateKamp();
            ModtagBelønning();
            new ReservedNamesController().CheckAndRemoveExistName();
        }

        private void ModtagBelønning() {
            List<Kupon> readyKupons = new List<Kupon>();
            using (BetBudContext db = new BetBudContext()) {
                readyKupons =
                    db.Kuponer.Include(x => x.delKampe.Select(y => y.Kampe))
                        .Where(x => x.Kontrolleret.Equals(false))
                        .Include(c => c.Bruger)
                        .ToList();
            }

            foreach (Kupon kupon in readyKupons) {
                Debug.WriteLine("kuponer");

                bool kuponklar = true;
                foreach (DelKamp delkamp in kupon.delKampe) {
                    if (!delkamp.Kampe.VundetX && !delkamp.Kampe.Vundet1 && !delkamp.Kampe.Vundet2) {
                        kuponklar = false;
                        break;
                    }
                    Debug.WriteLine("kampe");
                }

                if (kuponklar) {
                    Debug.WriteLine("kupon klar");
                    GivPoint(kupon);
                }
            }
        }

        private void GivPoint(Kupon kupon) {
            kupon.Bruger.Point += kupon.MuligGevist();
            kupon.Kontrolleret = true;

            using (BetBudContext db = new BetBudContext()) {
                using (DbContextTransaction transaction = db.Database.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        Debug.WriteLine("gem");
                        db.Entry(kupon).State = EntityState.Modified;
                        db.Entry(kupon.Bruger).State = EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e) {
                        Debug.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        private Setting getLastApiCall() {
            using (BetBudContext db = new BetBudContext()) {
                return db.Settings.First(x => x.name == "lastApiCall");
            }
        }

        private void updateSetting(Setting setting) {
            using (BetBudContext db = new BetBudContext()) {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void storeNewKampe(Kamp[] kamp) {
            using (BetBudContext db = new BetBudContext()) {
                List<Kamp> list = kamp.ToList();
                List<Kamp> onlyNew = new List<Kamp>();
                foreach (Kamp k in list)
                {
                    if(db.Kampe.Find(k.KampId) == null)
                    {
                        onlyNew.Add(k);
                    }
                }
                kamp = onlyNew.ToArray();
                db.Kampe.AddRange(kamp);
                db.SaveChanges();
            }
        }

        private void UpdateKamp() {
            IEnumerable<Kamp> kampList = new List<Kamp>();

            using (BetBudContext db = new BetBudContext()) {
                kampList =
                    db.Kampe.Where(x => x.KampStart < DateTime.Now && !x.Vundet1 && !x.Vundet2 && !x.VundetX).ToList();
            }

            if (kampList.Any()) {
                foreach (Kamp kamp in kampList) {
                    Debug.WriteLine("do game update");
                    string lastApiDate = "http://odds.mukuduk.dk/?kampId=" + kamp.KampId;
                    XElement oddsUrl = XElement.Load(lastApiDate);
                    Kamp kampe =
                        oddsUrl.Elements("kamp")
                            .Select(
                                p =>
                                    new Kamp {
                                        HoldVsHold = p.Element("text").Value,
                                        Odds1 = double.Parse(p.Element("odds1").Value),
                                        OddsX = double.Parse(p.Element("oddsx").Value),
                                        Odds2 = double.Parse(p.Element("odds2").Value),
                                        KampStart = DateTime.Parse(p.Element("kampStart").Value),
                                        Aflyst = bool.Parse(p.Element("aflyst").Value),
                                        Vundet1 = bool.Parse(p.Element("vundet1").Value),
                                        VundetX = bool.Parse(p.Element("vundetx").Value),
                                        Vundet2 = bool.Parse(p.Element("vundet2").Value),
                                        KampId = int.Parse(p.Element("KampId").Value)
                                    })
                            .First();
                    kamp.Vundet1 = kampe.Vundet1;
                    kamp.VundetX = kampe.VundetX;
                    kamp.Vundet2 = kampe.Vundet2;
                    using (BetBudContext db = new BetBudContext()) {
                        Debug.WriteLine("save Game");
                        db.Entry(kamp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }

        public IEnumerable<Kamp> getIkkeSpilletKampe() {
            using (BetBudContext db = new BetBudContext()) {
                return db.Kampe.Where(x => x.KampStart > DateTime.Now).ToList();
            }
        }
    }
}