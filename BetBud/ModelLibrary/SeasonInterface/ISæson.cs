using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelLibrary.SeasonInterface
{
    interface ISæson
    {
        IEnumerable<SæsonBruger> SæsonBrugere { get; set; }
        DateTime SæsonPeriode { get; set; }
        String SæsonNavn { get; set; }
        double SæsonPris { get; set; }

        bool SæsonAfslutning { get; set; }




    }
}
