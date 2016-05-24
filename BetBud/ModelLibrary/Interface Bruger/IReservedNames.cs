using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interface_Bruger {
    public interface IReservedNames {
        int ReservedNameId { get; set; }

        IPAddress IpAddress { get; set; }

        string UserName { get; set; }

        DateTime Time { get; set; }
    }
}