using System.Collections.Generic;
using System.ServiceModel;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    [ServiceContract]
    internal interface IServices
    {
        #region Ikupon

        [OperationContract]
        Kupon TilføjKamp(Kupon kupon, Kamp kamp, bool valgt1, bool valgtX, bool valgt2);

        [OperationContract]
        Kupon FjernKamp(Kamp kamp, Kupon kupon);

        [OperationContract]
        double OddsUdregning();

        [OperationContract]
        double MuligGevist();

        [OperationContract]
        bool BekræftKupon(Kupon kupon);

        [OperationContract]
        Kamp FindKamp(int KampId);

        [OperationContract]
        IEnumerable<Kamp> GetAlleKampe();

        [OperationContract]
        IEnumerable<Kupon> GetAlleKuponer(Bruger bruger);

        [OperationContract]
        Kupon NyKupon();

        [OperationContract]
        void GetKampFromApi();

        #endregion

        #region IBruger

        //Returner den enkelte bruger ud fra id
        [OperationContract]
        Bruger getBruger(int id);

        [OperationContract]
        Bruger getBrugerEfterBrugernavn(string bnavn);

        //Returner alle brugere
        [OperationContract]
        IEnumerable<Bruger> getBrugere();

        [OperationContract]
        void opretBruger(Bruger bruger);

        [OperationContract]
        void opdaterBruger(Bruger bruger);

        [OperationContract]
        void sletBruger(int id);

        [OperationContract]
        Bruger logInd(string bNavn, string pWord);

        [OperationContract]
        IEnumerable<Bruger> getHighscores();

        #endregion

        #region IChatHub

        [OperationContract]
        void OpretServer(string serverName, int serverPort, int bufferSize);

        [OperationContract]
        void DeleteServer(int serverId);

        [OperationContract]
        void UpdateServer(int serverId, string serverName, int serverPort, int bufferSize);

        /*
        [OperationContract]
        List<AServer> FindServers(string serverName);
        
        [OperationContract]
        AServer FindSpecificAServer(int serverId);
        
        [OperationContract]
        Client JoinServer(int port, Client client);
        */

        #endregion
    }
}