using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ModelLibrary.Interfaces.Interface_ReservedNames;

namespace ModelLibrary.Models.ReservedNames {
    [DataContract]
    public class ReservedNames : IReservedNames {
        #region Properties

        [DataMember, Key]
        public int ReservedNameId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        #endregion

    }
}