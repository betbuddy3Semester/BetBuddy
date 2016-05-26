using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.SeasonInterface;
using DALBetBud.Context;

namespace CtrLayer
{
    class SæsonBeskrivelseController : ISæsonBeskrivelseController
    {


        public SæsonBeskrivelse HentNuværendeSæson()
        {
            SæsonBeskrivelse sb;
            using (BetBudContext db = new BetBudContext())
            {
                sb = db.AktuelSæsonInfo.Last();
            }
            return sb;
        }
        
        public SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut)
        {
            using (BetBudContext db = new BetBudContext())
            {
                SæsonBeskrivelse sb = HentNuværendeSæson();
                sb.Beskrivelse = beskrivelse;
                sb.SlutDato = slut;
                sb.StartDato = start;
                db.SaveChanges();
            }
            return HentNuværendeSæson();
        }
    }
}

