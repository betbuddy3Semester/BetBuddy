using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ModelLibrary.Bruger {
    [DataContract]
    public class ReservedNames : IReservedNames {
        [DataMember, Key]
        public int ReservedNameId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
    }
}