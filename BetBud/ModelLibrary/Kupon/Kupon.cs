using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ModelLibrary.Kupon
{
    [DataContract]
    public class Kupon : IKupon
    {
        public Kupon()
        {
            delKampe = new List<DelKamp>();
        }

        [DataMember]
        public int BrugerId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int KuponId { get; set; }

        [DataMember]
        public DateTime CreateDateTime { get; set; }

        [DataMember]
        public Bruger.Bruger Bruger { get; set; }

        [DataMember]
        public bool Kontrolleret { get; set; }

        [DataMember]
        public List<DelKamp> delKampe { get; set; }

        [DataMember]
        public double Point { get; set; }


        // Metode til at tilføje kampe til kuponen. 
        // Tilføj kamp hvis kampen og valgt er lig med 1 - hvis valgt = 2 så bliver kampen ikke tilføjet da det vil sige at brugeren
        // har forsøgt at tilføje den samme kamp to gange. 
        public bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            if (kamp != null && ((valgt1 ? 1 : 0) + (valgtX ? 1 : 0) + (valgt2 ? 1 : 0) == 1))
            {
                DelKamp nyDelKamp = new DelKamp();

                nyDelKamp.Kampe = kamp;
                nyDelKamp.KampId = kamp.KampId;
                nyDelKamp.Valgt1 = valgt1;
                nyDelKamp.ValgtX = valgtX;
                nyDelKamp.Valgt2 = valgt2;
                delKampe.Add(nyDelKamp);


                return true;
            }
            return false;
        }

        // Metode til at fjerne kampe fra kuponen. Gennemgår listen udfra index og finder index nr. 
        //og fjerner derefter kampen fra index placeringen.
        public bool FjernKamp(Kamp kamp)
        {
            if (kamp != null)
            {
                for (int i = 0; i < delKampe.Count; i++)
                {
                    if (delKampe[i].Kampe.KampId.Equals(kamp.KampId))
                    {
                        delKampe.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }

        // Metode til at udregne alle valgte kampe på kuponen, og give et samlet odds retur. oddsResultat er kampene lagt sammen 
        // der så ganges med hinanden for at få det samlet odds.
        public double OddsUdregning()
        {
            double oddsResultat = 1;
            foreach (DelKamp HverDelKamp in delKampe)
            {
                oddsResultat *= HverDelKamp.GetOdds();
            }

            oddsResultat = Math.Round(oddsResultat, 2);
            return oddsResultat;
        }

        // Metoder der genbruger OddsUdregning og ganger den med det ønsket antal point som brugeren ønsker at 
        //bruge på kuponen. Math.Round runder gevisten op således der kun er 2(Derfor: point,2) decimaler i den mulige gevinst.
        public double MuligGevist()
        {
            return Math.Round(OddsUdregning()*Point, 2);
        }

        public bool BekræftKupon()
        {
            throw new NotImplementedException();
        }

        public bool KontrolAfKupon()
        {
            throw new NotImplementedException();
        }
    }
}