using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interface_Bruger
{
    public class BrugerInterfaceTest : IBruger
    {
        public string Navn { get; set; }

        public BrugerInterfaceTest()
        {
            Navn = "Bente";
        }

    }
}
