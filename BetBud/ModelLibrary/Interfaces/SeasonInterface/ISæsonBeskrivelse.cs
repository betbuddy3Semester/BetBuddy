namespace ModelLibrary.Interfaces.SeasonInterface {
    public interface ISæsonBeskrivelse {
        #region Properties

        int SæsonBeskrivelseId { get; set; }
        string StartDato { get; set; }
        string SlutDato { get; set; }
        string Beskrivelse { get; set; }

        #endregion

    }
}