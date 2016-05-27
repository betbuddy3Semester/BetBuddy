using System;

namespace ModelLibrary.Interfaces.Interface_ReservedNames {
    public interface IReservedNames {
        #region Properties

        int ReservedNameId { get; set; }

        string UserName { get; set; }

        DateTime Time { get; set; }

        #endregion

    }
}