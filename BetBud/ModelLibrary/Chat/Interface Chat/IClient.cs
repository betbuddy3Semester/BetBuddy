using System.Net.Sockets;

namespace ModelLibrary.Chat.Interface_Chat
{
    public interface IClient
    {
        #region Properties

        int ClientPort { get; set; }

        #endregion

        #region Methods

        void ConnectToServer();
        void DisconnectFromServer();
        void SendResponse(string messageStringInput);
        void ReceiveResponse();

        #endregion
    }
}