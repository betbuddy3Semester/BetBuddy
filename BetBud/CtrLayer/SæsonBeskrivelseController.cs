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

        public string RedigerBeskrivelse(string nyBeskrivelse)
        {
            using (BetBudContext db = new BetBudContext())
            {

                SæsonBeskrivelse sb = db.AktuelSæsonInfo.Last();
                sb.Beskrivelse = nyBeskrivelse;
                db.SaveChanges();

            }
            return nyBeskrivelse;
        }

        public string RedigerSlutDato(string nySlutDato)
        {
            
            using (BetBudContext db = new BetBudContext())
            {

                SæsonBeskrivelse sb = db.AktuelSæsonInfo.Last();
                sb.SlutDato = nySlutDato;
                db.SaveChanges();

            }
            return nySlutDato;
        }

        public string RedigerStartDato(string nyStartDato)
        {

            using (BetBudContext db = new BetBudContext())
            {

                SæsonBeskrivelse sb = db.AktuelSæsonInfo.Last();
                sb.SlutDato = nyStartDato;
                db.SaveChanges();

            }
            return nyStartDato;
        }

        public SæsonBeskrivelse OpdaterSæsonBeskrivelse(string beskrivelse, string start, string slut)
        {
            using (BetBudContext db = new BetBudContext())
            {
                SæsonBeskrivelseController sc = new SæsonBeskrivelseController();
                sc.RedigerBeskrivelse(beskrivelse);
                sc.RedigerSlutDato(slut);
                sc.RedigerStartDato(start);
                db.SaveChanges();
            }
            return HentNuværendeSæson();
        }


    }
    }

