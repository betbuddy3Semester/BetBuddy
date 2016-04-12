using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Interface_Bruger;

namespace ModelLibrary.Kupon
{
    public class Kupon : IKupon
    {
        public void TilføjKamp(IKamp kamp, bool valgt1, bool valgtX, bool valgt2)
        {
            throw new NotImplementedException();
        }

        public void FjernKamp(IKamp kamp)
        {
            throw new NotImplementedException();
        }

        public double OddsUdregning()
        {
            throw new NotImplementedException();
        }

        public double MuligGevist()
        {
            throw new NotImplementedException();
        }

        public bool BekræftKupon()
        {
            throw new NotImplementedException();
        }

        public bool KontrolAfKupon()
        {
            throw new NotImplementedException();
        }

        public bool Kontrolleret { get; }
        public double Point { get; set; }
        public List<IDelKamp> DelKampe { get; set; }
        public IBruger Bruger { get; set; }
    }
}
