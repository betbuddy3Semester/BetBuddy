using System.Collections.Generic;
using CtrLayer;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    public class Services : IServices
    {
        private DelKamp tempDelKamp = new DelKamp();
        private Kupon tempKupon = new Kupon();

        #region BrugerService

        private readonly BrugerController brugerCtrl = new BrugerController();

        public Bruger getBruger(int id)
        {
            return brugerCtrl.getBruger(id);
        }

        public Bruger getBrugerEfterBrugernavn(string bnavn)
        {
            return brugerCtrl.GetBrugerEfterBrugerNavn(bnavn);
        }

        public IEnumerable<Bruger> getBrugere()
        {
            return brugerCtrl.getBrugere();
        }

        public void opdaterBruger(Bruger bruger)
        {
            brugerCtrl.opdaterBruger(bruger);
        }

        public void opretBruger(Bruger bruger)
        {
            brugerCtrl.opretBruger(bruger);
        }

        public void sletBruger(int id)
        {
            brugerCtrl.sletBruger(id);
        }

        public Bruger logInd(string bNavn, string pWord)
        {
            var b = brugerCtrl.logIndBruger(bNavn, pWord);
            return b;
        }

        public void AddPoints(double Amount, Bruger b, string navn)
        {
            brugerCtrl.AddPoints(Amount, navn, b);
        }

        public void SubtractPoints(double Amount, Bruger b, string navn)
        {
            brugerCtrl.SubtractPoints(Amount, navn, b);
        }

        public IEnumerable<Bruger> getHighscores()
        {
            return brugerCtrl.getHighscores();
        }

        #endregion

        #region KuponService

        //Oprettes en ny KuponController som hedderNyKuponController
        private readonly KuponController NyKuponController = new KuponController();

        // Metode til at kalde TilføjKamp i controllerlaget og videresender parametrelisten og holder den returnerede kupon. 
        //Og returnere den valgte kupon
        public Kupon TilføjKamp(Kupon kupon, Kamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            var fundetData = NyKuponController.TilføjKamp(kamp, valgt1, valgtX, valgt2, kupon);
            return fundetData;
        }

        // Metode FjernKamp som sendes videre til controller laget, hvor kamp og kupon holdes i dataFjernet og returnere kun kupon.
        public Kupon FjernKamp(Kamp kamp, Kupon kupon)
        {
            var dataFjernes = NyKuponController.FjernKamp(kamp, kupon);
            return dataFjernes;
        }

        // Kalder metoden i controller laget og retunere denne.
        public double OddsUdregning()
        {
            return NyKuponController.OddsUdregning();
        }

        // Kalder metoden i controller laget og retunere denne.
        public double MuligGevist()
        {
            return NyKuponController.MuligGevist();
        }

        // Kalder metoden i controller laget og retunere denne.
        public bool BekræftKupon(Kupon kupon)
        {
            return NyKuponController.BekræftKupon(kupon);
        }

        // Kalder metoden FindKamp i controller laget og retunere denne.
        public Kamp FindKamp(int KampId)
        {
            return NyKuponController.FindKamp(KampId);
        }

        // Kalder metoden GetAlleKampe i controller laget og retunere denne.
        public IEnumerable<Kamp> GetAlleKampe()
        {
            return NyKuponController.GetAlleKampe();
        }

        // Kalder metoden i controller laget og retunere denne.
        public IEnumerable<Kupon> GetAlleKuponer(Bruger bruger)
        {
            return NyKuponController.GetAlleKuponer(bruger);
        }

        // Kalder metoden i controller laget og retunere denne.
        public Kupon NyKupon()
        {
            return NyKuponController.OpretKupon();
        }

        //Kalder metoden i controller laget og returnerer intet.
        public void GetKampFromApi()
        {
            NyKuponController.ApiGetKampe();
        }

        //Kalder metoden i controller laget og returnerer en liste af kampe der ikke er spillet endnu.
        public IEnumerable<Kamp> getIkkeSpilletKampe()
        {
            return NyKuponController.getIkkeSpilletKampe();
        }

        #endregion

        #region ChatService

        //Detaljeret forklaring i control laget og model laget

        // Todo - Få forklaring af hvorfor dette skal være en datamember
        private readonly ChatHub _chatHub = new ChatHub();

        /// <summary>
        ///     Denne metode opretter en server
        /// </summary>
        /// <param name="serverName">Serverens navn</param>
        /// <param name="serverPort">Serverens port</param>
        /// <param name="bufferSize">Bufferens størrelse</param>
        public void OpretServer(string serverName, int serverPort, int bufferSize)
        {
            _chatHub.OpretServer(serverName, serverPort, bufferSize);
        }

        /// <summary>
        ///     Denne metode sletter en server
        /// </summary>
        /// <param name="serverId">Serverens id</param>
        public void DeleteServer(int serverId)
        {
            _chatHub.DeleteServer(serverId);
        }

        /// <summary>
        ///     Denne metode opdaterer en servers information
        /// </summary>
        /// <param name="serverId">Serverens id, bruges i dette tilfælde til at finde serveren</param>
        /// <param name="serverName">Serverens navn</param>
        /// <param name="serverPort">Serverens port</param>
        /// <param name="bufferSize">Serverens buffer størrelse</param>
        public void UpdateServer(int serverId, string serverName, int serverPort, int bufferSize)
        {
            _chatHub.UpdateServer(serverId, serverName, serverPort, bufferSize);
        }

        /*
        /// <summary>
        /// Denne metode returnerer en liste af servere
        /// </summary>
        /// <param name="serverName">Serverens navn</param>
        /// <returns></returns>
        public List<AServer> FindServers(string serverName)
        {
            return _chatHub.FindServers(serverName);
        }
        
        /// <summary>
        /// Denne metode returnerer en specifik server
        /// </summary>
        /// <param name="serverId">Serverens id</param>
        /// <returns></returns>
        public AServer FindSpecificAServer(int serverId)
        {
            return _chatHub.FindSpecificAServer(serverId);
        }
        
        /// <summary>
        /// Denne metode joiner en server på en specifik port
        /// </summary>
        /// <param name="port">Porten som client socketen skal tilslutte</param>
        /// <returns></returns>
        public Client JoinServer(int port, Client client)
        {
            return _chatHub.JoinServer(port, client);
        }
        */

        #endregion
    }
}