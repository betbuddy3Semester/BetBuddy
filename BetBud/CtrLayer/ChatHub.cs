using System;
using System.Collections.Generic;
using System.Data.Entity;
using DALBetBud.Context;
using ModelLibrary.Chat;
using ModelLibrary.Chat.Interface_Chat;

namespace CtrLayer
{
    public class ChatHub : IChatHub
    {
        #region Properties

        public AServer ChatServer { get; set; }
        public int ChatHubId { get; set; }
        public IList<IClient> ClientList { get; set; }

        #endregion

        #region Methods

        #region CRUD Funcs

        /// <summary>
        ///     Denne metode står for at oprette serveren
        /// </summary>
        /// <param name="serverName">Serverens navn</param>
        /// <param name="serverPort">Serverens port</param>
        /// <param name="bufferSize">Serverens buffer størrelse</param>
        public void OpretServer(string serverName, int serverPort, int bufferSize)
        {
            //Her kaldes databasens context
            using (BetBudContext db = new BetBudContext())
            {
                //Objektet objekt initialiseres og forskellige variabler assignes til Aserverens properties
                ChatServer = new AServer
                {
                    ServerName = serverName,
                    ServerPort = serverPort,
                    BufferSize = bufferSize
                };
                //I dette kald åbnes contexten og chatserver objektet indsættes og dens state sættes til at være indsat, dette medfører at entity indsætter objektet til at være tilføjet i den cachede version af databasen
                db.Entry(ChatServer).State = EntityState.Added;
                //Her gemmes den cachede version af databasen ned til den rigtige version.
                db.SaveChanges();
            }
        }

        /// <summary>
        ///     Denne metode står for at slette serveren
        /// </summary>
        /// <param name="serverId">Serverens id</param>
        public void DeleteServer(int serverId)
        {
            //Contexten kaldes i et using statement således den disposes senere
            using (BetBudContext db = new BetBudContext())
            {
                //Der oprettes en server instans og iden sættes fra parameter listen
                AServer aServ = new AServer
                {
                    AServerId = serverId
                };

                //Der laves en statement hvor objektet bliver sat til at blive slettet
                db.Entry(aServ).State = EntityState.Deleted;
                //Ændringerne gemmes i databasen
                db.SaveChanges();
            }
        }

        /// <summary>
        ///     Denne metode står for at opdatere serverens information
        /// </summary>
        /// <param name="serverId">Serverens id nummer</param>
        /// <param name="serverName">Serverens navn</param>
        /// <param name="serverPort">Serverens port</param>
        /// <param name="bufferSize">Serverens buffer størrelse</param>
        public void UpdateServer(int serverId, string serverName, int serverPort, int bufferSize)
        {
            //Contexten åbnes i et using statement således at forbindelsen automatisk bliver deposed sernere
            using (BetBudContext db = new BetBudContext())
            {
                //Der kaldes en metode som finder en specifik server som skal opdateres, den assignes til lokal variablen server
                AServer server = FindSpecificAServer(serverId);

                //De forskellige opdateringer som der ønskes bliver assignet på objektet.
                server.ServerName = serverName;
                server.ServerPort = serverPort;
                server.BufferSize = bufferSize;

                //Contexten opretter en entry med objektet server hvor den ændrer serverens stadie til at være opdateret.
                db.Entry(server).State = EntityState.Modified;
                //Contexten gemmer statementen.
                db.SaveChanges();
            }
        }

        /// <summary>
        ///     Denne metode returnerer en liste af servere ud af databasen
        /// </summary>
        /// <param name="serverName"></param>
        /// <returns>En liste af servere</returns>
        public List<AServer> FindServers(string serverName)
        {
            /*using (var db = new BetBudContext())
            {
                // Denne metode returnere en liste over alle servere hvis navn matcher inputtet
                return db.ChatServers.ToList().FindAll(x => x.ServerName.Contains(serverName));
            }*/
            return null;
        }

        /// <summary>
        ///     Denne metode returnerer en specifik server ud af databasen
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public AServer FindSpecificAServer(int serverId)
        {
            //using (var db = new BetBudContext())
            //{
            //    // Denne metode returnere en specifik server, ud fra et givent server id
            //    return db.ChatServers.Single(x => x.AServerId == serverId);
            //}
            return null;
        }

        public Client JoinServer(int port)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        ///     Denne metode står for at oprette en client og connecte sig til en socket
        /// </summary>
        /// <param name="port">Den port som clienten skal forbinde sig til</param>
        /// <param name="client">Den client som ønsker at joiner chatten</param>
        //  
        public Client JoinServer(int port, Client client)
        {
            // Angiver hvilken port clienten skal connecte til hos chat serveren 
            client.ClientPort = port;


            client.ConnectToServer();
            return client;
        }

        #endregion
    }
}