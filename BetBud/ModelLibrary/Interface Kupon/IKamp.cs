using System;

namespace ModelLibrary
{
    public interface IKamp
    {
        int KampId { get; set; }
        string HoldVsHold { get; set; }
        double Odds1 { get; set; }
        double OddsX { get; set; }
        double Odds2 { get; set; }

        bool Vundet1 { get; set; }
        bool VundetX { get; set; }
        bool Vundet2 { get; set; }


        bool Aflyst { get; set; }
        DateTime KampStart { get; set; }

        //string KampResultat();
    }
}