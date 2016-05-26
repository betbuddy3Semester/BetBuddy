using System;

namespace ModelLibrary.Interface_Bruger {
    public interface IReservedNames {
        int ReservedNameId { get; set; }
        string UserName { get; set; }
        DateTime Time { get; set; }
    }
}