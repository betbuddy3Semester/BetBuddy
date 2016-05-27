using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ModelLibrary.Interfaces.SeasonInterface;

namespace ModelLibrary.Models.Sæson {
    [DataContract]
    public class SæsonBeskrivelse : ISæsonBeskrivelse {
        #region Properties

        [DataMember]
        public string Beskrivelse { get; set; }

        [DataMember, Key]
        public int SæsonBeskrivelseId { get; set; }

        [DataMember]
        public string SlutDato { get; set; }

        [DataMember]
        public string StartDato { get; set; }

        #endregion

    }
}