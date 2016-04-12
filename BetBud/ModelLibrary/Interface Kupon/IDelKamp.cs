using System.Reflection.Emit;

namespace ModelLibrary
{
    public interface IDelKamp
    {
        bool Valgt1 { get; set; }
        bool ValgtX { get; set; }
        bool Valgt2 { get; set; }
        
        IKampe Kampe { get; set; }

        bool KampRigtig();

        double GetOdds();

    }

}