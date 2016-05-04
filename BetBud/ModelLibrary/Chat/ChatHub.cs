using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Chat.Interface_Chat;

namespace ModelLibrary.Chat
{
    public class ChatHub : IChatHub
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int ChatHubId { get; set; }
        public IList<IAServer> ChatRoom { get; set; }
        public IList<IClient> ClientList { get; set; }

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
        public void JoinServer()
        {
            throw new NotImplementedException();
        }

        public void SearchForServer(string NameOfServer)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
