using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ModelLibrary.SeasonInterface {
    [DataContract]
    public class Sæson : ISæson {
        [DataMember, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SæsonId { get; set; }

        [DataMember]
        public List<SæsonBruger> SæsonBrugere { get; set; }

        [DataMember]
        public string SæsonNavn { get; set; }

        [DataMember]
        public DateTime SæsonPeriode { get; set; }

        [DataMember]
        public double SæsonPris { get; set; }
    }
}