using System.Collections.Generic;
using System.ServiceModel;
using CtrLayer.Models;

namespace WcfUsernameConcurrency {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Concurrency : IConcurrency {
        #region ReservedNamesService

        private readonly ReservedNamesController ctr = new ReservedNamesController();

        public IEnumerable<string> FeedBackReservedNames(string text, int id) {
            return ctr.FeedBackReservedNames(text, id);
        }

        #endregion
    }
}