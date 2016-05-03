using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Kupon;
using DALBetBud.Context;
using System.Runtime.Serialization;

namespace CtrLayer
{

    public class KuponController : IKuponController
    {
        // instance var
        public Kupon NyKupon;
        
        public KuponController()
        {
            
        }
        

        // Metode til at oprette kuponen. 

        public void OpretKupon()
        {
            NyKupon = new Kupon();
        }

        public Kupon GetKupon()
        {
            return NyKupon;
        }

        public void SetKupon(Kupon kupon)
        {
            this.NyKupon = kupon;
        }

        // Metode til at fjerne kuponen.

        public void FjernKupon()
        {
            NyKupon = null;
        }

        // Metode til at tilføje en kamp til kuponen. Kalder metoden TilføjKamp i modellaget. Kontrollere at kuponen er
        // oprettet.

        public Kupon TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2, Kupon kupon)
        {
            if (kupon != null)
            {
                kupon.TilføjKamp(kamp, valgt1, valgtX, valgt2);
            }
            return kupon;
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

        public IEnumerable<Kamp> GetAlleKampe()
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
