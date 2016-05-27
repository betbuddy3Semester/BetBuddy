using System.Collections.Generic;
using System.ServiceModel;
using CtrLayer.Models;
using ModelLibrary.Models.Bruger;
using ModelLibrary.Models.Kupon;
using ModelLibrary.Models.Sæson;

namespace WCFBetBuddy {
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Services : IServices {
        private DelKamp tempDelKamp = new DelKamp();
        private Kupon tempKupon = new Kupon();

        #region SæsonBeskrivelse

        private readonly SæsonBeskrivelseController _sbc = new SæsonBeskrivelseController();

        public SæsonBeskrivelse RedigerBeskrivelse(string beskrivelse, string start, string slut) {
            _sbc.OpdaterSæsonBeskrivelse(beskrivelse, start, slut);
            return _sbc.HentNuværendeSæson();
        }

        public SæsonBeskrivelse HentBeskrivelse() {
            return _sbc.HentNuværendeSæson();
        }

        #endregion

        #region Season

        private readonly SæsonController sæsonController = new SæsonController();

        public void AfslutSæson() {
            sæsonController.SæsonAfslutning();
        }

        #endregion

        #region BrugerService

        private readonly BrugerController brugerCtrl = new BrugerController();

        public Bruger getBruger(int id) {
            return brugerCtrl.getBruger(id);
        }

        public Bruger getBrugerEfterBrugernavn(string bnavn) {
            return brugerCtrl.GetBrugerEfterBrugerNavn(bnavn);
        }

        public IEnumerable<Bruger> getBrugere() {
            return brugerCtrl.getBrugere();
        }

        public void opdaterBruger(Bruger bruger) {
            brugerCtrl.opdaterBruger(bruger);
        }

        public void opretBruger(Bruger bruger) {
            brugerCtrl.opretBruger(bruger);
        }

        public void sletBruger(int id) {
            brugerCtrl.sletBruger(id);
        }

        public Bruger logInd(string bNavn, string pWord) {
            Bruger b = brugerCtrl.logIndBruger(bNavn, pWord);
            return b;
        }

        public void AddPoints(double Amount, Bruger b, string navn) {
            brugerCtrl.AddPoints(Amount, navn, b);
        }

        public void SubtractPoints(double Amount, Bruger b, string navn) {
            brugerCtrl.SubtractPoints(Amount, navn, b);
        }

        public IEnumerable<Bruger> getHighscores() {
            return brugerCtrl.getHighscores();
        }

        #endregion

        #region KuponService

        //Oprettes en ny KuponController som hedderNyKuponController
        private readonly KuponController NyKuponController = new KuponController();

        // Metode til at kalde TilføjKamp i controllerlaget og videresender parametrelisten og holder den returnerede kupon. 
        //Og returnere den valgte kupon
        public Kupon TilføjKamp(Kupon kupon, Kamp kamp, bool valgt1, bool valgtX, bool valgt2) {
            Kupon fundetData = NyKuponController.TilføjKamp(kamp, valgt1, valgtX, valgt2, kupon);
            return fundetData;
        }

        // Metode FjernKamp som sendes videre til controller laget, hvor kamp og kupon holdes i dataFjernet og returnere kun kupon
        public Kupon FjernKamp(Kamp kamp, Kupon kupon) {
            Kupon dataFjernes = NyKuponController.FjernKamp(kamp, kupon);
            return dataFjernes;
        }

        // Kalder metoden i controller laget og retunere denne
        public double OddsUdregning() {
            return NyKuponController.OddsUdregning();
        }

        // Kalder metoden i controller laget og retunere denne
        public double MuligGevist(Kupon kupon) {
            return NyKuponController.MuligGevinst(kupon);
        }

        // Kalder metoden i controller laget og retunere denne
        public bool BekræftKupon(Kupon kupon) {
            return NyKuponController.BekræftKupon(kupon);
        }

        // Kalder metoden FindKamp i controller laget og retunere denne
        public Kamp FindKamp(int kampId) {
            return NyKuponController.FindKamp(kampId);
        }

        // Kalder metoden GetAlleKampe i controller laget og retunere denne
        public IEnumerable<Kamp> GetAlleKampe() {
            return NyKuponController.GetAlleKampe();
        }

        // Kalder metoden i controller laget og retunere denne
        public IEnumerable<Kupon> GetAlleKuponer(Bruger bruger) {
            return NyKuponController.GetAlleKuponer(bruger);
        }

        // Kalder metoden i controller laget og retunere denne
        public Kupon NyKupon() {
            return NyKuponController.OpretKupon();
        }

        //Kalder metoden i controller laget og returnerer intet.
        public void GetKampFromApi() {
            NyKuponController.ApiGetKampe();
        }

        //Kalder metoden i controller laget og returnerer en liste af kampe der ikke er spillet endnu.
        public IEnumerable<Kamp> getIkkeSpilletKampe() {
            return NyKuponController.getIkkeSpilletKampe();
        }

        #endregion

        #region ReservedNamesService

        private readonly ReservedNamesController ctr = new ReservedNamesController();

        public IEnumerable<string> FeedBackReservedNames(string text, int id) {
            return ctr.FeedBackReservedNames(text, id);
        }

        #endregion
    }
}