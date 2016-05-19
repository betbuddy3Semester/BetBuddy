namespace ModelLibrary.Interface_Bruger
{
    public interface IBruger
    {
        string Navn { get; set; }
        string Email { get; set; }
        string BrugerNavn { get; set; }
        string Password { get; set; }
        string Alias { get; set; }
        double Point { get; set; }
    }
}