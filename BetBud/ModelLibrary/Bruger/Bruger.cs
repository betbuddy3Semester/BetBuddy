using ModelLibrary.Interface_Bruger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Bruger
{
    class Bruger : IBruger 
    
      {
            public string Alias
            { get; set; }

            public string BrugerNavn
            { get; set; }

            public string Email
            { get; set; }

            public string Navn
            { get; set; }
        }
    }

