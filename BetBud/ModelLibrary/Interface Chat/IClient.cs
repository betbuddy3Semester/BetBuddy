using System.Net.Sockets;

namespace ModelLibrary.Interface_Chat
{
    public interface IClient
    {
        #region Properties

        Socket ClientSocket { get; set; }
        int ClientPort { get; set; }

        #endregion

        #region Methods

        void ConnectToServer();
        void DisconnectedFromServer();
        void SendString();
        void SendObjectSerialized();

        #endregion
    }
}