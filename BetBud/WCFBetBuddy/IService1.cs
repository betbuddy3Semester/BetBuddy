using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFBetBuddy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFBetBuddy.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool _boolValue = true;
        string _stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return _boolValue; }
            set { _boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return _stringValue; }
            set { _stringValue = value; }
        }
    }
}
