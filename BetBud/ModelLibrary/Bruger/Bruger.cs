using ModelLibrary.Interface_Bruger;

namespace ModelLibrary.Bruger
{
    public class Bruger : IBruger

    {
        public int BrugerId { get; set; }

        public string Alias { get; set; }

        public string BrugerNavn { get; set; }

        public string Email { get; set; }

        public string Navn { get; set; }
    }
}