using ModelLibrary.Interface_Bruger;

namespace ModelLibrary.Bruger
{
    public class BrugerStub : IBruger
    {
        public BrugerStub()
        {
            BrugerNavn = "BrugerNavn";
            Alias = "Alias";
            Email = "Email";
            Navn = "Navn";
        }

        public string Navn { get; set; }
        public string BrugerNavn { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
    }
}