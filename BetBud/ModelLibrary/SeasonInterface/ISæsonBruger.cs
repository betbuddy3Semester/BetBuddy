using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.SeasonInterface
{
    interface ISæsonBruger
    {
        int BrugerID { get; set; }
        List<int> BrugerPoints { get; set; }
    }
}
