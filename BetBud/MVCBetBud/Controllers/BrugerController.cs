using MVCBetBud.BrugerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBetBud.Controllers
{
    public class BrugerController : Controller
    {
        BrugerServiceReference.BrugerServiceClient BSR = new BrugerServiceReference.BrugerServiceClient();
        // GET: Bruger
        public ActionResult Index()
        {
            
            return View(BSR.getBrugere());
        }

        // GET: Bruger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bruger/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Bruger/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Bruger b = new Bruger();
                b.BrugerNavn = collection.
                BSR.opretBruger(b);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bruger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bruger/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bruger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bruger/Delete/5
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
