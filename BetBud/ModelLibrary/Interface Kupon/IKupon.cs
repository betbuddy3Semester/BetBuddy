using ModelLibrary.Interface_Bruger;
using System;
using System.Collections.Generic;

namespace ModelLibrary
{
    public interface IKupon
    {
        /**
        * Oprettelse af kupon
        */
        void TilføjKamp(IKamp kamp, bool valgt1, bool valgtX, bool valgt2);
        void FjernKamp(IKamp kamp);
        double OddsUdregning();
        double MuligGevist();
        bool BekræftKupon();
        List<IDelKamp> SorteretKampe(); 

        
        /**
        * Kontrol/indløsning af kupon
        */
        bool KontrolAfKupon();
        bool Kontrolleret { get; set; }
        double Point { get; set; }
        List<IDelKamp> DelKampe { get; set; }
        IBruger Bruger { get; set; }
        
        
        


        
    }
}