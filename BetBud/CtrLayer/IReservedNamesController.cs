using System.Collections.Generic;
using ModelLibrary.Bruger;

namespace CtrLayer {
    public interface IReservedNamesController {
        ReservedNames GetReservedNames(int id);

        IEnumerable<ReservedNames> GetAllReservedNames();

        void CreateReservedName(ReservedNames reserved);

        void CreateMultipleReservedNames(IEnumerable<ReservedNames> listofReservedNames);

        void UpdateReservedName(ReservedNames reserved);

        void DeleteReservedName(ReservedNames reserved);
    }
}