namespace ModelLibrary.Interfaces.Interface_Bruger {
    public interface IBruger {
        #region Properties

        string Navn { get; set; }
        string Email { get; set; }
        string BrugerNavn { get; set; }
        string Password { get; set; }
        string Alias { get; set; }
        double Point { get; set; }

        #endregion

    }
}