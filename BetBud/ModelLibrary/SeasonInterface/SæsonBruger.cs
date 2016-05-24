using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelLibrary.SeasonInterface
{
    [DataContract]
    public class SæsonBruger : ISæsonBruger
    {
        [DataMember]
        public int SæsonBrugerId { get; set; }
        [DataMember]
        public Bruger.Bruger Bruger { get; set; }
        [DataMember]
        public int BrugerPoints { get; set; }
    }
}