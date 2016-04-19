using ModelLibrary.Interface_Bruger;
using System;
using System.Collections.Generic;
using ModelLibrary.Kupon;

namespace ModelLibrary
{
    public interface IKupon
    {
        /**
        * Oprettelse af kupon
        */
        bool TilføjKamp(Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        bool FjernKamp(Kamp kamp);
        double OddsUdregning();
        double MuligGevist();
        bool BekræftKupon();

        

        
        /**
        * Kontrol/indløsning af kupon
        */
        bool KontrolAfKupon();
        bool Kontrolleret { get; set; }
        double Point { get; set; }
        List<DelKamp> DelKampe { get; set; }
        IBruger Bruger { get; set; }
        
        
        


        
    }
}