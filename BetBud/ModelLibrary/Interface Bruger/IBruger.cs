using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interface_Bruger
{
    public interface IBruger
    {
        string Navn { get; set; }
        string BrugerNavn { get; set; }
        string Email { get; set; }
        string Alias { get; set; }
        string Password { get; set; }
        }
    }

