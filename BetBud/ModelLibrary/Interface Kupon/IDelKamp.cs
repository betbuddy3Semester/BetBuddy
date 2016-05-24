using System.Reflection.Emit;
using ModelLibrary.Kupon;

namespace ModelLibrary
{
    public interface IDelKamp
    {
        Kamp Kampe { get; set; }
        bool Valgt1 { get; set; }
        bool ValgtX { get; set; }
        bool Valgt2 { get; set; }
        
        bool KampRigtig();

        double GetOdds();

    }

}