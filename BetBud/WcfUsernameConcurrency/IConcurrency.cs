using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfUsernameConcurrency
{
    [ServiceContract]
    public interface IConcurrency
    {
        [OperationContract]
        IEnumerable<string> FeedBackReservedNames(string text, int id);
        
    }
}
