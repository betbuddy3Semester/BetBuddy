using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.WebSockets;
using ModelLibrary.Chat;

namespace AServerSocket
{
    public class Program
    {
        static void Main(string[] args)
        {
            AServer serv = new AServer()
            {
                ServerPort = 105
            };

            Client cli = new Client()
            {
                ClientPort = 105
            };

            Console.Title = "Server";
            serv.StartServer();

            Thread.Sleep(50);
            cli.ConnectToServer();

            Thread.Sleep(50);
            cli.SendResponse("Potato");

            Console.ReadLine();
            serv.StopServer();

            
        }
    }
}
