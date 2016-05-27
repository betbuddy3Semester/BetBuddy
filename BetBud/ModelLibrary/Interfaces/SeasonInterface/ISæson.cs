using System;
using System.Collections.Generic;
using ModelLibrary.Models.Sæson;

namespace ModelLibrary.Interfaces.SeasonInterface {
    public interface ISæson {
        #region Properties

        List<SæsonBruger> SæsonBrugere { get; set; }
        DateTime SæsonPeriode { get; set; }
        string SæsonNavn { get; set; }
        double SæsonPris { get; set; }
        SæsonBeskrivelse SæsonInfo { get; set; }

        #endregion

    }
}