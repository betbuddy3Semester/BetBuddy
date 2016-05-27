using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ModelLibrary.Interfaces.SeasonInterface;

namespace ModelLibrary.Models.Sæson {
    [DataContract]
    public class SæsonBruger : ISæsonBruger {
        #region Properties

        [DataMember, Key]
        public int SæsonBrugerId { get; set; }

        [DataMember]
        public Bruger.Bruger Bruger { get; set; }

        [DataMember]
        public double BrugerPoints { get; set; }

        #endregion

    }
}