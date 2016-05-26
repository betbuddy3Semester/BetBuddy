using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.SeasonInterface
{
    interface ISæsonBeskrivelse
    {
        int BeskrivelseId { get; set; }
        string StartDato{ get; set; }
        string SlutDato { get; set; }
        string Beskrivelse { get; set; }

    }
}
