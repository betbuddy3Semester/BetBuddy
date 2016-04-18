using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ModelLibrary.Kupon;

namespace BetBudTest.TestKupon
{
    public class KampTest
    {
        public Kamp kamp1 = new Kamp()
        {
            HoldVsHold = "Liverpool - Man UTD",
            Odds1 = 1.33,
            OddsX = 3.2,
            Odds2 = 18.0,
            Vundet1 = false,
            VundetX = false,
            Vundet2 = false,
            KampStart = new DateTime(),
            Aflyst = false,
        };

        public Kamp kamp2 = new Kamp()
        {
            HoldVsHold = "Chelsea - Norwich",
            Odds1 = 1.8,
            OddsX = 2.8,
            Odds2 = 3.5,
            Vundet1 = false,
            VundetX = false,
            Vundet2 = false,
            KampStart = new DateTime(),
            Aflyst = false,
        };

        public KampTest() { 
        kamp2.KampStart = kamp2.KampStart.AddDays(2);
        }

    }
}
