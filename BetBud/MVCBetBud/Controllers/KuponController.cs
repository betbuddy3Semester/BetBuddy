using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            Kamp[] ListeAfKampe = SR.GetAlleKampe();
            return View(ListeAfKampe);
        }

        // POST: Kupon/Create
        [HttpPost]
        public ActionResult OpretKupon(int KampId, string Odds1, string OddsX, string Odds2, string Bekraeft, string bettingPoint)
        {
            try
            {

               if (!string.IsNullOrEmpty(Odds1))
                {
                    return RedirectToAction("Odds1");
                }
                else if (!string.IsNullOrEmpty(OddsX))
                {
                    return RedirectToAction("OddsX");
                }
                else if (!string.IsNullOrEmpty(Odds2))
                {
                    return RedirectToAction("Odds2");
                }
                else if (!string.IsNullOrEmpty(Bekraeft))
                {
                    return RedirectToAction("be");
                }
                return RedirectToAction("OpretKupon");
            }
            catch
            {
                return View();
            }
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
