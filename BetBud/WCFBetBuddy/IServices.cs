using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFBetBuddy
{
    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        void startServices();

    }
}
