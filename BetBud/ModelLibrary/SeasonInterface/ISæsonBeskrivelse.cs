namespace ModelLibrary.SeasonInterface {
    internal interface ISæsonBeskrivelse {
        int SæsonBeskrivelseId { get; set; }
        string StartDato { get; set; }
        string SlutDato { get; set; }
        string Beskrivelse { get; set; }
    }
}