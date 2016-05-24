namespace ModelLibrary.Chat.Interface_Chat
{
    public interface IClient
    {
        #region Properties

        string ClientName { get; set; }
        int ClientId { get; set; }
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