using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Bruger;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    [ServiceContract]
    interface IServices
    {
        #region Ikupon

        
        [OperationContract]
        bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        [OperationContract]
        bool FjernKamp(Kamp kamp);
        [OperationContract]
        double OddsUdregning();
        [OperationContract]
        double MuligGevist();
        [OperationContract]
        bool BekræftKupon();
        [OperationContract]
        Kamp FindKamp(int KampId);
        [OperationContract]
        IEnumerable<Kamp> GetAlleKampe();
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
        #endregion

    }


}
