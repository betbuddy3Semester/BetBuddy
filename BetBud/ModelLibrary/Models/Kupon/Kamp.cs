using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using ModelLibrary.Interfaces.Interface_Kupon;

namespace ModelLibrary.Models.Kupon {
    [DataContract]
    public class Kamp : IKamp {
        #region Properties

        [DataMember, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KampId { get; set; }

        [DataMember]
        public string HoldVsHold { get; set; }

        [DataMember]
        public double Odds1 { get; set; }

        [DataMember]
        public double OddsX { get; set; }

        [DataMember]
        public double Odds2 { get; set; }

        [DataMember]
        public bool Vundet1 { get; set; }

        [DataMember]
        public bool VundetX { get; set; }

        [DataMember]
        public bool Vundet2 { get; set; }

        [DataMember]
        public DateTime KampStart { get; set; }

        [DataMember]
        public bool Aflyst { get; set; }

        #endregion

    }
}