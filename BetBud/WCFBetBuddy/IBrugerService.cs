using ModelLibrary.Bruger;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFBetBuddy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBrugerService
    {
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

       
    }

   
}
