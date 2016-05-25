using DALBetBud.Context;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;
using ModelLibrary.SeasonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrLayer
{
    public class SæsonController : ISæsonController
    {
        BrugerController BC = new BrugerController();
        KuponController KC = new KuponController();

        public void SæsonAfslutning()
        {
            Sæson s = new Sæson();
            List<SæsonBruger> sbs = new List<SæsonBruger>();
            foreach(var bruger  in BC.getBrugere())
            {
                var sb = new SæsonBruger();
                sb.Bruger = bruger;
                sb.BrugerPoints = bruger.Point;
                sbs.Add(sb);
            }
            s.SæsonBrugere = sbs;
            using (BetBudContext db = new BetBudContext())
            {
                db.Sæsoner.Add(s);
                db.SaveChanges();
            }
            foreach (var bruger in BC.getBrugere())
            {

                bruger.Point = 10000;
                
            }
            using (BetBudContext db = new BetBudContext())
            {
                Setting setting = db.Settings.Where(x => x.name == "Sæson").FirstOrDefault();
                int sæsonId = int.Parse(setting.value);
                setting.value = (sæsonId++) + "";
                db.Entry(setting).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
              
        }

    }
}
