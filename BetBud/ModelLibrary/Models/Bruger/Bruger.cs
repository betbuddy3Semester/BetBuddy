using System.Runtime.Serialization;
using ModelLibrary.Interfaces.Interface_Bruger;

namespace ModelLibrary.Models.Bruger {
    [DataContract]
    public class Bruger : IBruger {
        #region Properties

        [DataMember]
        public int BrugerId { get; set; }

        [DataMember]
        public string Navn { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string BrugerNavn { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public double Point { get; set; }

        #endregion

    }
}