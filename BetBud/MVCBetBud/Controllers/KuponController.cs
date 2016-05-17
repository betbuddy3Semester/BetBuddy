using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBetBud.Models;
using MVCBetBud.ServiceReference;

namespace MVCBetBud.Controllers
{
    public class KuponController : Controller
    {
        // Instans variabel der opretter en ny Service kaldet SR. Det er SR der håndtere kaldende og pakker/udpakker objekterne.  
        ServiceReference.ServicesClient SR = new ServiceReference.ServicesClient();

        // GET: Kupon - Metode som der bruger session til at kontrollere om brugeren er på session. Hvis brugerens session eksisterer hentes 
        // brugeren ved et brugerId, og henter derefter alle brugerens kuponer som sendes til viewet. 
        public ActionResult Kuponer()
        {
            if (Session["brugerSession"] != null)
            {


                Bruger bruger = SR.getBruger((int)Session["brugerSession"]);

                Kupon[] alleKuponer = SR.GetAlleKuponer(bruger);

                return View(alleKuponer);
            }
            return RedirectToAction("index", "home");
        }

        // GET: Kupon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Metoden OpretKupon - Kontrollere om session eksisterer, hvis den gør hentes den igangværnede kupon og en liste af alle kampe udfra 
        // brugerens brugerId. 
        // Hvis ikke brugeren ikke er på session, oprettes en ny kupon og listen af alle kampe som sættes på brugerens brugerId
        // Brugeren hentes via dennes brugerId som bliver læst fra session. 
        //  
        public ActionResult OpretKupon()
        {
            if (Session["brugerSession"] != null)
            {
                Kupon kupon = SR.NyKupon();
                Bruger bruger = SR.getBruger((int)Session["brugerSession"]);
                kupon.Bruger = bruger;
                kupon.BrugerId = bruger.BrugerId;
                if (Session["kupon"] != null)
                {
                    kupon = (Kupon)Session["kupon"];

                }
                else
                {
                    Session["kupon"] = kupon;
                }
                Kamp[] ListeAfKampe = SR.GetAlleKampe();
                OpretKuponController modelOpretKupon = new OpretKuponController();
                modelOpretKupon.kupon = kupon;
                modelOpretKupon.AlleKampe = ListeAfKampe;
                return View(modelOpretKupon);
            }
            return RedirectToAction("index", "home");
        }

        // POST: Kupon/Create - POST metoden for opretKupon, viser hvad der sker efter brugeren har tilføjet kampe til sin kupon. 
        // Først kontrollere den om det er den rigtige kupon der er i dennes session - og det indtastet " bettingpoint" bliver sat på kuponen.
        // Hvis kuponen bliver bekræftet, sendes den til retur til brugeren.
        [HttpPost]
        public ActionResult OpretKupon(double bettingPoint)
        {
            if (bettingPoint <=0.0)
            {
                return RedirectToAction("OpretKupon");
            }
            try
            {
                Kupon kupon = (Kupon)Session["kupon"];
                kupon.Point = bettingPoint;
                if (SR.BekræftKupon(kupon))
                {
                    return RedirectToAction("index");
                }

                return RedirectToAction("OpretKupon");
            }
            catch
            {
                return View();
            }
        }

        // PostOdds1 - Metode til at tilføje odds 1 på kuponen. 
        // Kontrollere at det er den rigtige kupon på session. 
        // Finder den valgte kamp udfra kampId - og tilføjer kampen til variablen valgtKupon
        // Variablen valgtKupon gemmes i sessionen kupon, som vises i viewet. 
        [HttpPost]
        public ActionResult PostOdds1()
        {
            int kampId = Convert.ToInt32(Request.Form["item.KampId"]);
            Kupon kupon = (Kupon)Session["kupon"];

            Kamp valgtKamp = SR.FindKamp(kampId);
            Kupon valgtKupon = SR.TilføjKamp(kupon, valgtKamp, true, false, false);
            Session["kupon"] = valgtKupon;



            return RedirectToAction("OpretKupon");
        }


        // PostOddsX - Metode til at tilføje odds X på kuponen. 
        // Kontrollere at det er den rigtige kupon på session. 
        // Finder den valgte kamp udfra kampId - og tilføjer kampen til variablen valgtKupon
        // Variablen valgtKupon gemmes i sessionen kupon, som vises i viewet.
        [HttpPost]
        public ActionResult PostOddsX()
        {
            int kampId = Convert.ToInt32(Request.Form["item.KampId"]);
            Kupon kupon = (Kupon)Session["kupon"];

            Kamp valgtKamp = SR.FindKamp(kampId);
            Kupon valgtKupon = SR.TilføjKamp(kupon, valgtKamp, false, true, false);
            Session["kupon"] = valgtKupon;



            return RedirectToAction("OpretKupon");
        }
        
        // PostOdds2 - Metode til at tilføje odds 2 på kuponen. 
        // Kontrollere at det er den rigtige kupon på session. 
        // Finder den valgte kamp udfra kampId - og tilføjer kampen til variablen valgtKupon
        // Variablen valgtKupon gemmes i sessionen kupon, som vises i viewet.
        [HttpPost]
        public ActionResult PostOdds2()
        {
            int kampId = Convert.ToInt32(Request.Form["item.KampId"]);
            Kupon kupon = (Kupon)Session["kupon"];

            Kamp valgtKamp = SR.FindKamp(kampId);
            Kupon valgtKupon = SR.TilføjKamp(kupon, valgtKamp, false, false, true);
            Session["kupon"] = valgtKupon;



            return RedirectToAction("OpretKupon");
        }

        // GET: Kupon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kupon/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kupon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kupon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // Post metode til at fjerne valgte kampe fra sin kupon.
        // 
        [HttpPost]
        public ActionResult FjernKamp()
        {
            int KampId = Convert.ToInt32(Request.Form["FjernKamp"]);
            Kupon kupon = (Kupon)Session["kupon"];

            Kamp valgtKamp = SR.FindKamp(KampId);
            Kupon valgtKupon = SR.FjernKamp(valgtKamp,kupon);
            Session["kupon"] = valgtKupon;

            return RedirectToAction("OpretKupon");
        }

        // Metode til at rydde hele sin kupon. 
        // Hvis kuponen er på session sættes kupon til null, og derved fjernes alle de valgte kampe. 
        // Man sendes til siden "opretKupon" 
        public ActionResult RydKupon()
        {
            if (Session["kupon"] != null )
            {
                Session["kupon"] = null;
            }
            return RedirectToAction("OpretKupon");
        }

        public ActionResult ApiGetKampe()
        {

            return View();
        }
    }
}
