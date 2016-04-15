using System.Reflection.Emit;

namespace ModelLibrary
{
    public interface IDelKamp
    {
        IKamp Kampe { get; set; }
        bool Valgt1 { get; set; }
        bool ValgtX { get; set; }
        bool Valgt2 { get; set; }
        
        bool KampRigtig();

        double GetOdds();

    }

}