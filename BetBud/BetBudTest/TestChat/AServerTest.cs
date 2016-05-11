using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary.Chat;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BetBudTest.TestChat
{
    [TestFixture]
    public class AServerTest
    {
        private AServer _aserv;
        private Client _clientOne;
        private Client _clientTwo;
        private Client _clientThree;

        [TestInitialize]
        public void TestInitialize()
        {
            #region Arrange

            //Server
            _aserv = new AServer
            {
                AServerId = 1,
                ServerName = "Fodbold",
                BufferSize = 2048,
                ServerPort = 100
            };

            //Alex
            _clientOne = new Client
            {
                ClientPort = 100
            };

            //Morten
            _clientTwo = new Client
            {
                ClientPort = 100
            };

            //Lasse
            _clientThree = new Client
            {
                ClientPort = 100
            };

            #endregion
        }

        /// <summary>
        /// A test to see if the server starts correctly
        /// </summary>
        [Test]
        public void StartServerTest()
        {
            TestInitialize();
            #region Act

            _aserv.StartServer();
            Thread.Sleep(5);
            _clientOne.ConnectToServer();
            Thread.Sleep(5);
            _clientTwo.ConnectToServer();
            Thread.Sleep(5);
            _clientThree.ConnectToServer();
            Thread.Sleep(5);

            _clientOne.SendResponse("ClientOne");
            Thread.Sleep(5);
            _clientTwo.SendResponse("ClientTwo");
            Thread.Sleep(5);
            _clientThree.SendResponse("ClientThree");

            #endregion

            #region Assert

            Thread.Sleep(5);
            Assert.IsNotNull(_aserv.ServerSocket);
            Assert.IsNotNull(_aserv.ClientSocket);
            Assert.IsNotEmpty(_aserv.MessageList);

            Thread.Sleep(5);
            _aserv.StopServer();

            #endregion

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