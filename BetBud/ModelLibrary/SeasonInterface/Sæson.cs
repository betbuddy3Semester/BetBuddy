using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Kupon;
using System.Runtime.Serialization;

namespace ModelLibrary.SeasonInterface
{
    [DataContract]
    public class Sæson : ISæson
    {
        
        [DataMember, Key]
        public int SæsonId { get; set; }
        [DataMember]
        public IEnumerable<SæsonBruger> SæsonBrugere { get; set; }
        [DataMember]
        public string SæsonNavn { get; set; }
        [DataMember]
        public DateTime SæsonPeriode { get; set; }
        [DataMember]
        public double SæsonPris { get; set; }
        
    }
}
