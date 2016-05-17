using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using DALBetBud.Context;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace CtrLayer
{
    public class KuponController : IKuponController
    {
        // instance variable af kupon 
        public Kupon NyKupon;

        // Konstruktør for KuponController


        // Metode til at oprette kuponen og returnere en ny kupon til KuponControlleren 

        public Kupon OpretKupon()
        {
            NyKupon = new Kupon();
            return NyKupon;
        }

        // Metode til at tilføje en kamp til kuponen. Kalder metoden TilføjKamp i modellaget.  Kontrollere at kuponen er
        // oprettet. Search igennem delKampe og tilføjer den valgte kamp der er i delKamp, hvis kampId passer overens med hinanden. Returnere 
        // variablen fundet. Hvis den valgte kamp ikke er  i listen delKampe, returneres kupon uden kampen.
        // Det vil sige at hvis kampen allerede er på kuponen, så skal den ikke tilføjes.

        public Kupon TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2, Kupon kupon)
        {
            var fundet = false;
            foreach (var delKamp in kupon.delKampe)
            {
                if (delKamp.Kampe.KampId == kamp.KampId)
                {
                    fundet = true;
                }
            }
            if (kupon != null && fundet == false)
            {
                kupon.TilføjKamp(kamp, valgt1, valgtX, valgt2);
            }
            return kupon;
        }


        // Metode til at fjerne en kamp fra sin kupon. Først kontrollere metoden om der er en kupon, og fjerner derefter 
        // den valgte kamp.

        public Kupon FjernKamp(Kamp kamp, Kupon kupon)
        {
            if (kupon != null)
            {
                kupon.FjernKamp(kamp);
            }
            return kupon;
        }

        // Metode til at lave oddsudregningen fra modellaget. Kontrollere om kuponen findes og laver derefter
        // udregningen på de valgte kampe og returnere det samlede odds. Hvis ikke kuponen er oprettet returnes 0,0. 

        public double OddsUdregning()
        {
            if (NyKupon != null)
            {
                return NyKupon.OddsUdregning();
            }
            return 0.0;
        }

        // Metode til at udregne den mulige gevist som brugeren kan vinde. MuligGevist kalder metoden fra modellaget
        // som udregner gevisten. Kontrollere om kuponen er oprettet, og returnere denne med den mulige gevinst. Hvis ikke kuponen er oprettet
        // returneres 0,0.

        public double MuligGevist()
        {
            if (NyKupon != null)
            {
                return NyKupon.MuligGevist();
            }
            return 0.0;
        }

        // Metode til at bekræfte kuponen. Der oprettes en ny forbindelse til databasen via BetBudContext klassen. 
        // For hver kamp der er i listen delKampe, sendes ind i variablen kamp. 
        // Unchanged betyder at objektet kamp ikke bliver ændret i Databasen, 
        // Samme sker med kupon.bruger. Kuponen bliver tilføjet og gemt. 
        public bool BekræftKupon(Kupon kupon)
        {
            kupon.CreateDateTime = DateTime.Now;
            using (var db = new BetBudContext())
            {
                foreach (var kamp in kupon.delKampe)
                {
                    db.Entry(kamp.Kampe).State = EntityState.Unchanged;
                }
                db.Entry(kupon.Bruger).State = EntityState.Unchanged;
                db.Kuponer.Add(kupon);
                db.SaveChanges();
                return true;
            }
        }

        // Metode der henter alle kampe i Databasen. Der oprettes en ny forbindelse til databasen som returnere Kampe på en liste. 
        public IEnumerable<Kamp> GetAlleKampe()
        {
            using (var db = new BetBudContext())
            {
                return db.Kampe.ToList();
            }
        }

        // Metode der bruges til at finde en kamp udfra kampId i databasen. Der opretter en ny forbindelse til databasen via BetBudContext,  
        // den kamp der stemmer overens med kampId ´et sendes bliver gemt i lokal variablen kamp som efterfølgende bliver returneret.

        public Kamp FindKamp(int KampId)
        {
            using (var db = new BetBudContext())
            {
                var kamp = db.Kampe.Find(KampId);
                return kamp;
            }
        }

        // Metode til at hente alle brugerens allerede eksisterende kuponer. Der oprettes en ny forbindelse til databasen via BetBudContext.
        // Databasen returnere alle brugerens kuponer hvis brugerId stemmer overens med brugerId og tilføjer disse til en liste.
        public IEnumerable<Kupon> GetAlleKuponer(Bruger bruger)
        {
            using (var db = new BetBudContext())
            {
                return
                    db.Kuponer.Include(x => x.delKampe.Select(y => y.Kampe))
                        .Include(x => x.Bruger)
                        .Where(allebrugerkuponger => allebrugerkuponger.BrugerId == bruger.BrugerId)
                        .ToList();
            }
        }

        //Metode til at hente kuponen
        public Kupon GetKupon()
        {
            return NyKupon;
        }

        // Metode til at Set kuponen, this.NyKupon da det er den pågældende kupon i metoden der er tale om.
        public void SetKupon(Kupon kupon)
        {
            NyKupon = kupon;
        }

        // Metode til at fjerne kuponen. 

        public void FjernKupon()
        {
            NyKupon = null;
        }

        public void ApiGetKampe()
        {
            var apiSetting = getLastApiCall();
            var lastApiDate = "http://odds.mukuduk.dk/?timeStamp="+ apiSetting.value;

            //var xdocu = new XmlDocument();

            

            var oddsUrl = XElement.Load( lastApiDate);
            var kampe = oddsUrl.Elements("kamp").Select(p => new Kamp
            {
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
            }).ToArray();
            if (kampe.Any())
                storeNewKampe(kampe);

            apiSetting.value = DateTime.Now + "";
            updateSetting(apiSetting);
        }

        private Setting getLastApiCall()
        {
            using (var db = new BetBudContext())
            {
                return db.Settings.Where(x => x.name == "lastApiCall").First();
            }
        }

        private void updateSetting(Setting setting)
        {
            using (var db = new BetBudContext())
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void storeNewKampe(Kamp[] kamp)
        {
            using (var db = new BetBudContext())
            {
                db.Kampe.AddRange(kamp);
                db.SaveChanges();
            }
        }
    }
}