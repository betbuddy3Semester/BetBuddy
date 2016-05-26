using System;
using System.Collections.Generic;

namespace ModelLibrary.SeasonInterface {
    internal interface ISæson {
        List<SæsonBruger> SæsonBrugere { get; set; }
        DateTime SæsonPeriode { get; set; }
        string SæsonNavn { get; set; }
        double SæsonPris { get; set; }
        SæsonBeskrivelse SæsonInfo { get; set; }
    }
}