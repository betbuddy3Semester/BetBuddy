using ModelLibrary.Interface_Bruger;
using ModelLibrary.Bruger;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ModelLibrary.Bruger
{
    [DataContract] 
    public class Bruger : IBruger

    {
        [DataMember]
        public int BrugerId { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public string BrugerNavn { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Navn { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}