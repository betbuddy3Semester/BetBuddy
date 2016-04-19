using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Kupon;

namespace WCFBetBuddy
{
    [ServiceContract]
    interface IKuponService
    {
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
        List<Kamp> GetAlleKampe();
    }
}
