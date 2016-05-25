using MVCBetBud.ServiceReference;

namespace MVCBetBud.Models
{
    public class OpretKuponController
    {
        //Kupon
        public Kupon kupon { get; set; }
        public Kamp[] AlleKampe { get; set; }
    }

    public class OpretForsideController
    {
        //Kupon
        public Bruger[] brugere { get; set; }
        public Kamp[] AlleKampe { get; set; }
    }

    public class VundetKupon
    {
        public Kupon kupon { get; set; }
        public bool vundet { get; set; }
        public double muligGevinst { get; set; }
    }
}
