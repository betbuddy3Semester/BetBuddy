using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrLayer
{
    interface ISæsonController
    {
        BrugerController NyBrugerController { get; set; }
        KuponController NyKuponController { get; set; }

        

        DateTime SæsonStart();
        DateTime SæsonAfslutning();
    }
}
