using System.Text.RegularExpressions;
using System.Web.Mvc;
using MVCBetBud.ServiceReference;

namespace MVCBetBud.Controllers {
    public class BrugerController : Controller {
        private readonly ServicesClient SR = new ServicesClient();
        // GET: Bruger
        public ActionResult Index() {
            //var session = HttpContext.Current.Session;
            //if (Request.IsAuthenticated)
            if (Session["brugerSession"] != null) {
                // Bruger b = SR.getBrugerEfterBrugernavn(User.Identity.Name);
                Bruger b = SR.getBruger((int) Session["brugerSession"]);
                return View(b);
            }

            return RedirectToAction("index", "Home");
        }

        public ActionResult GetApi(string text) {
            int reservId = 0;
            if (Session["ReservationId"] != null) {
                reservId = (int)Session["ReservationId"];
            }
            var reservedName = SR.FeedBackReservedNames(text, reservId);
            Session["ReservationId"] = reservedName["id"];
            return Json(reservedName["statussearch"]);
        }

        // GET: login side
        public ActionResult Login() {
            if (Session["brugerSession"] != null) {
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string brugerNavn, string kodeord) {
            Bruger b = SR.logInd(brugerNavn, kodeord);
            if (b != null) {
                //FormsAuthentication.SetAuthCookie(b.BrugerNavn, true);
                Session["brugerSession"] = b.BrugerId;
            }
            return RedirectToAction("index");
        }

        // GET: logout af bruger
        public ActionResult Logout() {
            if (Session["brugerSession"] != null) {
                Session["brugerSession"] = null;
                return RedirectToAction("Index");
            }
            return RedirectToAction("login");
        }

        // GET: Bruger/Details/5
        public ActionResult Details(int id) {
            if (Session["brugerSession"] != null) {
                // Bruger b = SR.getBrugerEfterBrugernavn(User.Identity.Name);
                Bruger b = SR.getBruger((int) Session["brugerSession"]);
                return View(b);
            }

            return RedirectToAction("index", "Home");
        }

        // GET: Bruger/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Bruger/Create
        [HttpPost]
        public ActionResult Create(Bruger b) {
            //Email constraints 
            Match matchEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(b.Email);

            //Number constraints
            Match matchName = new Regex(@"^[a-åA-Å' '-'\s]{1,40}$").Match(b.Navn);


            //Brugernavn constraints 1-24 karaktere
            //Skal starte med a-z
            // må indeholde .,-_
            //Må ikke ende på .,-_
            Match matchBruger = new Regex(@"^[a-zA-Z0-9\._\-]{0,23}$").Match(b.BrugerNavn);

            Bruger bcheck = SR.getBrugerEfterBrugernavn(b.BrugerNavn);


            if (matchEmail.Success && matchName.Success && matchBruger.Success && bcheck == null) {
                try {
                    SR.opretBruger(b);
                    return RedirectToAction("Index");
                }
                catch {
                    return View();
                }
            }
            if (!matchEmail.Success) {
                Session["BrugerErrorEmail"] = "Der er fejl i din email.";
            }
            if (!matchName.Success) {
                Session["BrugerErrorNavn"] = "Dit navn kan ikke indeholde tal";
            }
            if (!matchBruger.Success) {
                Session["BrugerErrorBrugernavn"] = "Der er fejl i brugernavn";
            }
            if (bcheck != null) {
                Session["BrugerErrorBruger"] = "Brugeren eksistere allerede";
            }
            return View();
        }

        // GET: Bruger/Edit/5
        public ActionResult Edit(int id) {
            Bruger b = SR.getBruger(id);
            return View(b);
        }

        // POST: Bruger/Edit/5
        [HttpPost]
        public ActionResult Edit(Bruger b) {
            try {
                SR.opdaterBruger(b);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Bruger/Delete/5
        public ActionResult Delete(int id) {
            Bruger b = SR.getBruger(id);
            return View(b);
        }

        // POST: Bruger/Delete/5
        [HttpPost]
        public ActionResult Delete(Bruger b) {
            try {
                SR.sletBruger(b.BrugerId);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}