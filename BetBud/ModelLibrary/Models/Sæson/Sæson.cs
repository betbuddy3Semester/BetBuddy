using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using ModelLibrary.Interfaces.SeasonInterface;

namespace ModelLibrary.Models.Sæson {
    [DataContract]
    public class Sæson : ISæson {
        #region Properties

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

        [DataMember]
        public SæsonBeskrivelse SæsonInfo { get; set; }

        #endregion

    }
}