using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ModelLibrary.SeasonInterface {
    [DataContract]
    public class SæsonBeskrivelse : ISæsonBeskrivelse {
        [DataMember]
        public string Beskrivelse { get; set; }

        [DataMember, Key]
        public int SæsonBeskrivelseId { get; set; }

        [DataMember]
        public string SlutDato { get; set; }

        [DataMember]
        public string StartDato { get; set; }
    }
}