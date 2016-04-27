using System;
using System.Net.Sockets;
using ModelLibrary.Interface_Chat;

namespace ModelLibrary.Chat
{
    public class Client : IClient
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Socket ClientSocket { get; set; }
        public int ClientPort { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public void ConnectToServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisconnectedFromServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendObjectSerialized()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}