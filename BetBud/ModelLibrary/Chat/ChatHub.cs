using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Interface_Chat;

namespace ModelLibrary.Chat
{
    public class ChatHub : IChatHub
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int ChatHubId { get; set; }
        public IList<AServer> ChatRoom { get; set; }
        public IClient Client { get; set; }
        public IChatHub ServerCtr { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public void OpretServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void FindServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InviteClientToServer()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
