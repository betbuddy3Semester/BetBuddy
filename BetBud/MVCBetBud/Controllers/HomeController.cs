using MVCBetBud.Models;
using MVCBetBud.ServiceReference;
using System.Web.Mvc;

namespace MVCBetBud.Controllers
{
    public class HomeController : Controller
    {

        ServiceReference.ServicesClient SR = new ServiceReference.ServicesClient();
        public ActionResult Index()
        {
            Kamp[] k = SR.GetAlleKampe();
            Bruger[] b = SR.getBrugere();
            OpretForsideController ofc = new OpretForsideController();
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