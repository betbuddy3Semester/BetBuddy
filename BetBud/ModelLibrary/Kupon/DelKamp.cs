using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Kupon
{
    public class DelKamp : IDelKamp
    {
        public bool Valgt1 { get; set; }
        public bool ValgtX { get; set; }
        public bool Valgt2 { get; set; }
        public IKamp Kampe { get; set; }
        public bool KampRigtig()
        {
            throw new NotImplementedException();
        }

        public double GetOdds()
        {
            throw new NotImplementedException();
        }
    }
}
