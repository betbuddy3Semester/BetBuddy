using System.Collections.Generic;
using ModelLibrary.Chat;
using ModelLibrary.Chat.Interface_Chat;

namespace CtrLayer {
    public interface IChatHub {
        #region Properties

        int ChatHubId { get; set; }
        AServer ChatServer { get; set; }
        IList<IClient> ClientList { get; set; }

        #endregion

        #region Methods

        void DeleteServer(int serverId);
        List<AServer> FindServers(string serverName);
        AServer FindSpecificAServer(int serverId);
        Client JoinServer(int port, Client client);
        void OpretServer(string serverName, int serverPort, int bufferSize);
        void UpdateServer(int id, string serverName, int serverPort, int bufferSize);

        #endregion
    }
}