using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Kupon
{
    public class Kamp : IKamp
    {
        public int KampId { get; set; }
        public string HoldVsHold { get; set; }
        public double Odds1 { get; set; }
        public double OddsX { get; set; }
        public double Odds2 { get; set; }
        public bool Vundet1 { get; set; }
        public bool VundetX { get; set; }
        public bool Vundet2 { get; set; }
        public DateTime KampStart { get; set; }
        public bool Aflyst { get; set; }
        public void KampNr()
        {
            throw new NotImplementedException();
        }

        public string KampResultat()
        {
            throw new NotImplementedException();
        }

        public bool ErValgt()
        {
            throw new NotImplementedException();
        }
    }
}
