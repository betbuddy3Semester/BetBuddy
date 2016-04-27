using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interface_Chat
{
    public interface IClient
    {
        // Prop's
        Socket ClientSocket { get; set; }
        int Client { get; set; }

        // Methods
        void ConnectToServer();
        void DisconnectedFromServer();
        void SendString();
        void SendObjectSerialized();
         
    }
}
