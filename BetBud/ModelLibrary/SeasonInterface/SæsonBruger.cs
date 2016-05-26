using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ModelLibrary.SeasonInterface {
    [DataContract]
    public class SæsonBruger : ISæsonBruger {
        [DataMember, Key]
        public int SæsonBrugerId { get; set; }

        [DataMember]
        public Bruger.Bruger Bruger { get; set; }

        [DataMember]
        public double BrugerPoints { get; set; }
    }
}