using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interface_Chat
{
    public interface IServer
    {
        // Prop's
        int ServerId                { get; set; }
        string ServerName           { get; set; }
        Socket ServerSocket         { get; set; }
        List<Socket> ClientSocket   { get; set; }
        int ServerPort              { get; set; }
        IPEndPoint ServerEndPoint   { get; set; }
        int BufferSize              { get; set; }
        byte[] Buffer               { get; }
        StringBuilder Sb            { get; set; }

        // Methods
        void StartServer();
        void StopServer();
        void AcceptCallback();
        void ReceiveCallBack();
        void StoreCallBack();
    }
}
