using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Bruger
{
    [DataContract]
    public class Bruger : IBruger 
    
      {

            public string Alias
            { get; set; }

            public string BrugerNavn
            { get; set; }

            public string Email
            { get; set; }

            public string Navn
            { get; set; }


        //Giver brugeren et ID
        [Key]
        [DatabaseGe ]
            public int BrugerId 
            { get; set; }
      }
    }

