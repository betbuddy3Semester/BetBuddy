using System.Collections.Generic;

namespace ModelLibrary.Chat.Interface_Chat
{
    public interface IChatHub
    {
        #region Properties

        int ChatHubId { get; set; }
        IList<AServer> ChatRoom { get; set; }
        IClient Client { get; set; }
        IChatHub ServerCtr { get; set; }

        #endregion

        #region Methods

        void OpretServer();
        void CloseServer();
        void DeleteServer();
        void FindServer();
        void InviteClientToServer();

        #endregion
    }
}