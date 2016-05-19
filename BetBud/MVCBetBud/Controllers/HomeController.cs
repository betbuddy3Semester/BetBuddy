﻿using System.Web.Mvc;
using MVCBetBud.Models;
using MVCBetBud.ServiceReference;

namespace MVCBetBud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServicesClient SR = new ServicesClient();

        public ActionResult Index()
        {
            var k = SR.GetAlleKampe();
            var b = SR.getHighscores();
            var ofc = new OpretForsideController();
            ofc.AlleKampe = k;
            ofc.brugere = b;
            return View(ofc);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}