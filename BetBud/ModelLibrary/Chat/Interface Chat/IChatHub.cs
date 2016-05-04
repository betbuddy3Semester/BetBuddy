using System.Collections.Generic;

namespace ModelLibrary.Chat.Interface_Chat
{
    public interface IChatHub
    {
        #region Properties

        int ChatHubId { get; set; }
        IList<IAServer> ChatRoom { get; set; }
        IList<IClient> ClientList { get; set; }

        #endregion

        #region Methods

        void OpretServer();
        void CloseServer();
        void DeleteServer();
        void JoinServer();
        void SearchForServer(string NameOfServer);

        #endregion
    }
}