using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.SeasonInterface
{
    interface ISæsonBruger
    {
        Bruger.Bruger Bruger { get; set; }
        double BrugerPoints { get; set; }
    }
}
