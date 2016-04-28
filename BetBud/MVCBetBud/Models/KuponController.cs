using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBetBud.Controllers;
using MVCBetBud.ServiceReference;

namespace MVCBetBud.Models
{
    public class OpretKuponController
    {
        //Kupon
        public Kupon kupon{get; set;}
        public Kamp[] AlleKampe { get; set; }
    }
}
