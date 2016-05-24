using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelLibrary.SeasonInterface
{
    [DataContract]
    public class SæsonBruger : ISæsonBruger
    {
        [DataMember]
        public int BrugerID { get; set; }
        [DataMember]
        public List<int> BrugerPoints { get; set; }
    }
}