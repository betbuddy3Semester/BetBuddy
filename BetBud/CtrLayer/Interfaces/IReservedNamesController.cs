using System.Collections.Generic;
using ModelLibrary.Interfaces;
using ModelLibrary.Models;
using ModelLibrary.Models.ReservedNames;

namespace CtrLayer.Interfaces {
    public interface IReservedNamesController {
        #region Methods

        ReservedNames GetReservedNames(int id);

        IEnumerable<ReservedNames> GetAllReservedNames();

        void CreateReservedName(ReservedNames reserved);

        void CreateMultipleReservedNames(IEnumerable<ReservedNames> listofReservedNames);

        void UpdateReservedName(ReservedNames reserved);

        void DeleteReservedName(ReservedNames reserved);

        #endregion

    }
}