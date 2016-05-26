using System;
using System.Net.Sockets;
using System.Text;

namespace ModelLibrary.Chat.Interface_Chat {
    public interface IAServer {
        #region Properties

        int AServerId { get; set; }
        int ServerPort { get; set; }
        int BufferSize { get; set; }
        string ServerName { get; set; }
        Socket ServerSocket { get; set; }
        StringBuilder Sb { get; set; }
        byte[] Buffer { get; set; }

        #endregion

        #region Methods

        void StartServer();
        void StopServer();
        void AcceptCallback(IAsyncResult ar);
        void ReceiveCallBack(IAsyncResult asyncCallback);

        #endregion
    }
}