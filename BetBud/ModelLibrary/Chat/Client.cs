using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using ModelLibrary.Chat.Interface_Chat;

namespace ModelLibrary.Chat
{
    [DataContract]
    public class Client : IClient
    {
        #region Properties

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        [DataMember] private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

        [DataMember]
        public int ClientPort { get; set; }

        [DataMember]
        public string ReceivedMessage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     metode til at oprette forbindelse
        /// </summary>
        public void ConnectToServer()
        {
            // initialisering af int til at tælle mængden af forbindelsesforsøg
            int connectionAttempts = 0;

            // Loop der foreskriver, at hvis clientens socket ikke er connected, så køres den underliggende try
            while (!ClientSocket.Connected && connectionAttempts < 3)
            {
                try
                {
                    // For hvert forsøg på at skabe forbindelse, stiger vores int med 1.
                    connectionAttempts++;

                    Debug.WriteLine("Connection Attempts : " + connectionAttempts);
                    // Her kaldes selve forsøget på at oprette forbindelse
                    ClientSocket.Connect(IPAddress.Loopback, ClientPort);
                }
                catch (SocketException e)
                {
                    Debug.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        ///     Metode til at lukke clientens socket
        /// </summary>
        public void DisconnectFromServer()
        {
            // Først sendes en besked med "exit", hvilket lukker for forbindelsen serverside med AServer klassens ReceiveCallback, da den er sat til at lukke for socketen, skulle den modtage beskeden "exit"
            SendResponse("exit");
            // Efter socketen på serverside er lukket, lukker vi for kommunikation fra socketen clientside 
            ClientSocket.Shutdown(SocketShutdown.Both);
            // Til sidst fjerner vi socketen clientside helt.
            ClientSocket.Close();
        }

        /// <summary>
        ///     Metode til at modtage kommunikation fra serverSide på klientens socket
        /// </summary>
        public void ReceiveResponse()
        {
            // Først initialiseres et byte array til at holde beskeden i konverteret form
            byte[] clientBuffer = new byte[2048];
            // int received initialiseres og sættes til at være ligmed størrelsen på det ovenstående byte array
            int received = ClientSocket.Receive(clientBuffer, SocketFlags.None);
            // Hvis int received er lig med nul, stopper metoden her, da der så ikke er nogen data i arrayet
            if (received == 0) return;
            // Initialisering af et nyt byte array, til brug i den nedenstående Array.Copy metode, som kopiere data fra et byte[] til et andet.
            byte[] data = new byte[received];
            Array.Copy(clientBuffer, data, received);
            // Til sidst konverteres dataen i det kopierede byte[] tilbage til String format
            ReceivedMessage = Encoding.ASCII.GetString(data);
        }

        /// <summary>
        ///     Metode til at sende input fra client socket til Server socket.
        /// </summary>
        public void SendResponse(string messageStringInput)
        {
            // Først initialisere vi en variabel(buffer) og smider metodens input string(messageStringInput) ind i den, i konverteret form .
            byte[] buffer = Encoding.ASCII.GetBytes(messageStringInput);
            // Til sidst sender vi den konverterede String til ServerSocket'en for at blive konverteret tilbage til String format.
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        #endregion
    }
}