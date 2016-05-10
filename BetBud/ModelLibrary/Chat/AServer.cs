using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using ModelLibrary.Chat.Interface_Chat;

namespace ModelLibrary.Chat
{
    [DataContract]
    public class AServer : IAServer
    {
        #region Properties

        [DataMember, Key]
        public int AServerId { get; set; }

        [DataMember]
        public int BufferSize { get; set; }

        [DataMember]
        public int ServerPort { get; set; }

        [DataMember, NotMapped]
        public string ReceiveCallBackString { get; set; }

        [DataMember]
        public string ServerName { get; set; }

        [DataMember, NotMapped]
        public IEnumerable<string> MessageList { get; set; }

        [DataMember, NotMapped]
        public Socket ServerSocket { get; set; }

        [DataMember, NotMapped]
        public List<Socket> ClientSocket { get; set; }

        [DataMember, NotMapped]
        public IPEndPoint ServerEndPoint { get; set; }

        [DataMember, NotMapped]
        public StringBuilder Sb { get; set; }

        [DataMember, NotMapped]
        public byte[] Buffer { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Denne metode bygger en socket og indkluderer dens nødvendigheder hvor den også binder til en ipadresse og bestemmer
        ///     hvor mange connection sockets den skal lytte efter.
        /// </summary>
        public void StartServer()
        {
            //Skriv en besked til output i consolen for at se om serveren er ved at blive oprettet
            Debug.WriteLine("Setting up the server");

            //Opretter en instans af socket som har adressefamilien af internetwork og sockettypen af stream og protocoltypen af tcp som sikrer sig at alle pakkerne når frem.
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Opretter listen af client sockets
            ClientSocket = new List<Socket>();

            //Serverens socket binder sig til et IpEndPoint (Hvor dataen skal hen) & opretter en instans af et ipendpoint som er en klasse der specificerer hvad ipaddressen og porten skal være
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, ServerPort));

            //Serverens socket sættes til at have en bestemt mængde af forbindelser på en gang
            ServerSocket.Listen(100);

            //Serverens socket begynder af acceptere asynkrone tilbagekald
            ServerSocket.BeginAccept(AcceptCallback, null);
        }

        /// <summary>
        ///     Denne metode er ansvarlig for at lukke chatten, den iterer over hver client socket og stopper forbindelsen og
        ///     lukker hver socket ned
        /// </summary>
        public void StopServer()
        {
            if (ClientSocket.Count > 0)
            {

                //Her oprettes et foreach loop som iterer hen over socketens client liste
                foreach (var variable in ClientSocket)
                {
                    //Her bruges hver element i listen, det første kald stopper vi forbindelsen ud og indgående i socketen, men den eksisterer stadigvæk.
                    variable.Shutdown(SocketShutdown.Both);
                    //I dette kald lukkes client socketen helt således at den ikke eksisterer længere
                    variable.Close();
                }
            }
            //Her lukkes serverens forbindelser ned både ingående og udgående.
            //ServerSocket.Shutdown(SocketShutdown.Both);
            //I dette kald lukkes serverens socket således at den ikke længere eksisterer.
            ServerSocket.Close();
            //I dette kald sættes server socket propertien til null.
            ServerSocket = null;
        }

        /// <summary>
        ///     Denne metode håndterer kommunikation mellem clienten og serverens på asynkron vis.
        /// </summary>
        public void AcceptCallback(IAsyncResult asyncResult)
        {
            //Her laves en lokal variable af typen socket, den deklareres her fordi at socketens scope skal persistere udenfor try catch kaldet lige under.
            Socket tempSocket;

            //Her forsøges der at placerer en client socket på lokal variablen.
            try
            {
                //Server socketen benytter sig at funktionen som opretter en socket instans som placeres på lokal variablen uden for try catchens scope.
                tempSocket = ServerSocket.EndAccept(asyncResult);
            }
                //Hvis objektet ikke længere eksisterer kastes objectdisposedexceptionen. I tilfælde af det ikke lykkedes at oprette en forbindelse på den lokale socket.
            catch (ObjectDisposedException x)
                //Denne exception bliver kastet når at der bliver forsøgt at blive gjort noget på et objekt som allerede er skillet af med.
            {
                Debug.WriteLine(x);
                return;
            }

            //I dette kald bliver den nyoprettet client socket tilføjet til serverens clientsocket liste.
            ClientSocket.Add(tempSocket);

            //Her begynder den nyoprettet socket at modtage information fra clientens socket.
            tempSocket.BeginReceive(Buffer, 0, BufferSize, SocketFlags.None
                /* TODO - Gå hjem og find ud af hvad singlecast og multicast er*/, ReceiveCallBack, tempSocket);
            Debug.WriteLine("Client forbundet, venter på input");

            //Serverens socket kalder beginaccept rekusivt for hele tiden at se om der er nye data og forbindelser mellem client socketen og serverens socket.
            ServerSocket.BeginAccept(AcceptCallback, null);
        }

        /// <summary>
        ///     Denne metode håndterer at acceptere alle de forskellige callbacks der kommer fra clienterne.
        /// </summary>
        public void ReceiveCallBack(IAsyncResult asyncCallback)
        {
            // Her oprettes en lokal socket til brug i metoden. Det er asynkrone sockets der bliver oprettet pr. client som connecter til den overordnede serverchat socket.
            var current = (Socket) asyncCallback.AsyncState;
            int received;

            // I denne snippet forsøges det at tildele received et integer output fra current socketens endreceive metode.
            try
            {
                received = current.EndReceive(asyncCallback);
            }
                // Der kastes en socketexception hvis der er noget galt med resultatet, hvis received ikke modtager den forventede integer.
            catch (SocketException x)
            {
                Debug.WriteLine("Client has been forced to disconnect.");
                Debug.WriteLine(x.Message);
                // Current socketen bliver lukket og fjernet fra clientSocket listen.
                current.Close();
                ClientSocket.Remove(current);
                return;
            }

            // Der oprettes en callbackbuffer med længden af receive integeren
            var receiveCallbackBuffer = new byte[received];
            // Nu kopieres serverens buffer ind i den nyoprettede buffer.
            Array.Copy(Buffer, receiveCallbackBuffer, received);
            // Her bliver bufferens array af bits konverteret til String format
            ReceiveCallBackString = Encoding.ASCII.GetString(receiveCallbackBuffer);
            //Her tilføjes den konverterede string til den overordnede liste af beskeder
            MessageList.ToList().Add(ReceiveCallBackString);

            #region Responses

            // for at lukke clientens aktualle socket forbindelse til chatserveren, skal clienten blot skrive "exit" i chatten, her defineres dette.
            // I if statementen tjekker vi om den besked clienten har sendt til serveren er "exit", der tages højde for upper/lowercase, så chatten lukkes ligemeget hvordan man skriver "exit".

            if (ReceiveCallBackString.ToLower() == "exit")
            {
                // Hvis den ovenstående if returnere true, vælger vi den aktuelle client socket og starter med at lukke forbindelsen
                current.Shutdown(SocketShutdown.Both);
                // Derefter sletter vi client socketen
                current.Close();

                // Til sidst laves en besked om, at socketen er blevet lukket - beskeden konverteres til et byteArray for at sende sende hurtigt imellem systemets forskellige lag og kodesprog.½
                var byteMessageArrayToClient = Encoding.ASCII.GetBytes("Your connection has been closed");
                current.Send(byteMessageArrayToClient);
            }

            #endregion

            // Den lokale socket begynder at lytte efter beskeder igen.
            current.BeginReceive(Buffer, 0, BufferSize, SocketFlags.None, ReceiveCallBack, current);
        }

        #endregion
    }
}