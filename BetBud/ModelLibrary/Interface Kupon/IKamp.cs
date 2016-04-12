using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ModelLibrary
{
    public interface IKamp
    {
        string HoldVsHold { get; set; }
        double Odds1{ get; set; }
        double OddsX { get; set; }
        double Odds2 { get; set; }

        bool Vundet1 { get; set; }
        bool VundetX { get; set; }
        bool Vundet2 { get; set; }

        DateTime KampStart { get; set; }
        bool Aflyst { get; set; }

        void KampNr();
        string KampResultat();
        bool ErValgt();




    }
}