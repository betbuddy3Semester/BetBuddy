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

        ServiceReference.ServicesClient SR = new ServiceReference.ServicesClient();

        // GET: Kupon
        public ActionResult Index()
        {
            Kamp[] alleKampe = SR.GetAlleKampe();
            return View(alleKampe);
        }

        // GET: Kupon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kupon/Create
        public ActionResult OpretKupon()
        {

            Kupon kupon = new Kupon();

            if (Session["kupon"] != null)
            {
                kupon = (Kupon) Session["kupon"];

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

        // POST: Kupon/Create
        [HttpPost]
        public ActionResult OpretKupon(int KampId, string Odds1, string OddsX, string Odds2)
        {
            try
            {

                return RedirectToAction("OpretKupon");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult PostOdds1()
        {
            int kampId = Convert.ToInt32( Request.Form["item.KampId"]);
            Kupon kupon = (Kupon) Session["kupon"];
          
            Kamp valgtKamp = SR.FindKamp(kampId);
            SR.TilføjKamp(kupon, valgtKamp, true, false, false);
            Session["kupon"] = SR.GetKupon();

            
            
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
    }
}
