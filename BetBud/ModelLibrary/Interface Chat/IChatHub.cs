using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Bruger;

namespace ModelLibrary.Interface_Chat
{
    public interface IChatHub
    {
        // Prop's
        int ChatHubId { get; set; }
        List<Server> ChatRoom { get; set; }
        Client client { get; set; }
        ServerController ServerCtr { get; set; }

        // Methods
        void OpretServer();
        void CloseServer();
        void DeleteServer();
        void FindServer();
        void InviteClientToServer();
    


    }
}
