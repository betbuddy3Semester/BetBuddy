using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;
using ModelLibrary.Interface_Bruger;

namespace ModelLibrary.Bruger {
    public class ReservedNames : IReservedNames {
        [DataMember, Key]
        public int ReservedNameId { get; set; }
        [DataMember]
        public IPAddress IpAddress { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
    }
}