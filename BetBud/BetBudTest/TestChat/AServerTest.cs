using System.Net.Sockets;
using ModelLibrary.Chat;
using NUnit.Framework;

namespace BetBudTest.TestChat
{
    [TestFixture]
    public class AServerTest
    {
        [Test]
        public void StartServerTest()

        {
            // Arrange
            var aserv = new AServer();
            var client = new Client();

            // Act
            aserv.StartServer();
            client.ClientPort = 100;
            client.ConnectToServer();
            

            // Assert
            Assert.IsNotNull(aserv.ServerSocket);
            Assert.IsNotNull(aserv.ServerEndPoint);
            Assert.IsNotNull(aserv.ClientSocket);
            Assert.IsNotEmpty(aserv.ClientSocket);
        }

        [Test]
        public void StopServerTest()
        {
            //Arrrange 
            var aserv = new AServer();

            // Act
            aserv.StartServer();

            //Arrange
            Assert.IsNotNull(aserv.ServerSocket);

            // Act
            aserv.StopServer();

            //Assert
            Assert.IsNull(aserv.ServerSocket);
            //Assert.IsEmpty(aserv.ClientSocket);
        }
    }
}