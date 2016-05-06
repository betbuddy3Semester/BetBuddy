using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CtrLayer;
using ModelLibrary.Bruger;
using ModelLibrary.Chat;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    public class Services : IServices
    {
        DelKamp tempDelKamp = new DelKamp();
        Kupon tempKupon = new Kupon();
        #region BrugerService
        [DataMember]
        BrugerController brugerCtrl = new BrugerController();


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
           Bruger b = brugerCtrl.logIndBruger(bNavn, pWord);
            return b;
        }

        #endregion

        #region KuponService
        KuponController NyKuponController = new KuponController();

        public Kupon TilføjKamp(Kupon kupon, Kamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            Kupon fundetData = NyKuponController.TilføjKamp(kamp, valgt1, valgtX, valgt2, kupon);
            return fundetData;
        }

        public bool FjernKamp(Kamp kamp)
        {
            bool dataFjernes = NyKuponController.FjernKamp(kamp);
            return dataFjernes;
        }

        public double OddsUdregning()
        {
            return NyKuponController.OddsUdregning();
        }

        public double MuligGevist()
        {
            return NyKuponController.MuligGevist();
        }

        public bool BekræftKupon(Kupon kupon)
        {
            return NyKuponController.BekræftKupon(kupon);
        }

        public Kamp FindKamp(int KampId)
        {
            return NyKuponController.FindKamp(KampId);
        }

        public IEnumerable<Kamp> GetAlleKampe()
        {
            return NyKuponController.GetAlleKampe();
        }

        public IEnumerable<Kupon> GetAlleKuponer(Bruger bruger)
        {
            return NyKuponController.GetAlleKuponer(bruger);
        }

        public Kupon NyKupon()
        {
            return NyKuponController.OpretKupon();
        }


        #endregion

        #region ChatService
        //Detaljeret forklaring i control laget og model laget

        [DataMember] // Todo - Få forklaring af hvorfor dette skal være en datamember
        ChatHub _chatHub = new ChatHub();

        /// <summary>
        /// Denne metode opretter en server
        /// </summary>
        /// <param name="serverName">Serverens navn</param>
        /// <param name="serverPort">Serverens port</param>
        /// <param name="bufferSize">Bufferens størrelse</param>
        public void OpretServer(string serverName, int serverPort, int bufferSize)
        {
            _chatHub.OpretServer(serverName, serverPort, bufferSize);
        }

        /// <summary>
        /// Denne metode sletter en server
        /// </summary>
        /// <param name="serverId">Serverens id</param>
        public void DeleteServer(int serverId)
        {
            _chatHub.DeleteServer(serverId);
        }

        /// <summary>
        /// Denne metode opdaterer en servers information
        /// </summary>
        /// <param name="serverId">Serverens id, bruges i dette tilfælde til at finde serveren</param>
        /// <param name="serverName">Serverens navn</param>
        /// <param name="serverPort">Serverens port</param>
        /// <param name="bufferSize">Serverens buffer størrelse</param>
        public void UpdateServer(int serverId, string serverName, int serverPort, int bufferSize)
        {
            _chatHub.UpdateServer(serverId, serverName, serverPort, bufferSize);
        }

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
        public Client JoinServer(int port)
        {
            return _chatHub.JoinServer(port);
        }

        #endregion

    }
}
