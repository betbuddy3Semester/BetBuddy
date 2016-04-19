using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Kupon;
using DALBetBud.Context;

namespace CtrLayer
{
    public class KuponController : IKuponController
    {
        // instance var
        private static KuponController NyKuponController;
        public Kupon NyKupon;



        private KuponController()
        {

        }

        // Oprettelse af KuponController (Singleton pattern for at oprette en instance af KuponControlleren)

        public static KuponController GetKuponController()
        {
            if (NyKuponController == null)
            {
                NyKuponController = new KuponController();
            }
            return NyKuponController;
        }

        // Metode til at oprette kuponen. 

        public void OpretKupon()
        {
            NyKupon = new Kupon();

        }

        // Metode til at fjerne kuponen.

        public void FjernKupon()
        {
            NyKupon = null;
        }

        // Metode til at tilføje en kamp til kuponen. Kalder metoden TilføjKamp i modellaget. Kontrollere at kuponen er
        // oprettet.

        public bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            if (NyKupon != null)
            {
                return NyKupon.TilføjKamp(kamp, valgt1, valgtX, valgt2);
            }
            return false;
        }

        // Metode til at fjerne en kamp fra sin kupon. Først kontrollere metoden om der er en kupon, og fjerner derefter 
        // den valgte kamp.

        public bool FjernKamp(Kamp kamp)
        {
            if (NyKupon != null)
            {
                return NyKupon.FjernKamp(kamp);
            }
            return false;
        }

        // Metode til at lave oddsudregningen fra modellaget. Kontrollere om kuponen findes og laver derefter
        // udregningen på de valgte kampe og returnere det samlet odds

        public double OddsUdregning()
        {
            if (NyKupon != null)
            {
                return NyKupon.OddsUdregning();
            }
            return 0.0;
        }

        // Metode til at udregne den mulige gevist som brugeren kan vinde. MuligGevist kalder metoden fra modellaget
        // som udregner gevisten. 

        public double MuligGevist()
        {
            if (NyKupon != null)
            {
                return NyKupon.MuligGevist();
            }
            return 0.0;
        }


        public bool BekræftKupon()
        {
            using (BetBudContext db = new BetBudContext())
            {
                try
                {
                    db.Kuponer.Add(NyKupon);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {

                    return false;
                }

            }

        }

        // Metode der henter alle kampe i Databasen

        public List<Kamp> GetAlleKampe()
        {
            using (BetBudContext db = new BetBudContext())
            {
                return db.Kampe.ToList();
            }
        }

        // Metode til at finde en kamp udfra kampId. 

        public Kamp FindKamp(int KampId)
        {
            using (BetBudContext db = new BetBudContext())
            {
                Kamp kamp = db.Kampe.Find(KampId);
                return kamp;
            }
        }
    }
}
