using MVCBetBud.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBetBud.Controllers
{
    public class BrugerController : Controller
    {
        ServiceReference.ServicesClient SR = new ServiceReference.ServicesClient();
        // GET: Bruger
        public ActionResult Index()
        {
            
            return View(SR.getBrugere());
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
        public ActionResult Create(Bruger b)
        {
            try
            {
                SR.opretBruger(b);
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
            Bruger b = SR.getBruger(id);
            return View(b);
        }

        // POST: Bruger/Edit/5
        [HttpPost]
        public ActionResult Edit(Bruger b)
        {
            try
            {
                // TODO: Add update logic here
                SR.opdaterBruger(b);
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
            Bruger b = SR.getBruger(id);
            return View(b);
        }

        // POST: Bruger/Delete/5
        [HttpPost]
        public ActionResult Delete(Bruger b)
        {
            try
            {
                // TODO: Add delete logic here
                SR.sletBruger(b.BrugerId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
