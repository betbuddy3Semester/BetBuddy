/**
 * Server object that requires a websocket server and has to use the http protocol
 */
var Server = require("websocket").server, Http = require("http");

/**
 * List containing clients
 */
var Clients = [];

/**
 * A new server socket is created, it uses the http protocol and listens on port 1337.
 */
var Socket = new Server({
    httpServer: Http.createServer().listen(1337)
});

/**
 * The console starts the server.
 */
console.log("Starting the web socket");

/**
 * The socket calls the 'on' method and uses the protocol called request.
 */
Socket.on("request",
    function(request) {
        /**
         * The connection variable accepts all the callbacks that comes from the client.
         */
        var connection = request.accept(null, request.origin);

        /**
         * The name of the client is assigned to be 'error'.
         */
        var name = "error";

        /**
         * Connection on takes in the event message http protocol, and we handle the event with a function.
         */
        connection.on("message",
            function(message) {

                /**
                 * First of all, the message is logged to the server socket so it is possible to see if it has arrived or not.
                 */
                console.log(message.utf8Data);

                /**
                 * Json variable that holds the received string and turns it into an 'object'.
                 */
                var json;

                //conditionals to setting the name
                if (message.utf8Data.split(" ")[0] == "/setUserName" && name == "error") {

                    //name is assigned if conditionals are met
                    name = message.utf8Data.split(" ")[1];

                    //The clients list gets pushed a name and a connection
                    Clients.push({ "name": name, "connection": connection });

                    //The message and data gets converted into a json object.
                    json = JSON.stringify({
                        type: "message",
                        data: { "msg": name + " just joined!!", "user": "server" }
                    });

                    //A foreach loop through the client list which sends the messages.
                    for (var VAR in Clients) {
                        VAR.connection.sendUTF(json);
                    }

                    //If the name has not been set yet, you can't do anything.
                } else if (name == "error") {
                    json = JSON.stringify({
                        type: "message",
                        data: { "msg": "you have to login to chat", "user": "server" }
                    });

                    //The message that you can't send anything.
                    connection.sendUTF(json);

                } else {
                    //A message is converted to json and it is sent.
                    json = JSON.stringify({ type: "message", data: { "msg": message.utf8Data, "user": name } });
                    //Loops through and sends the message
                    for (var VAR in Clients) {
                        VAR.connection.sendUTF(json);
                    }
                }
            });

        connection.on("close",
            function() {
                //Logs the clients and their names to the console.
                console.log("clients:" + Clients.length + " name: " + name);

                //Gets the specific users
                var conPos = getUserIndex(name);

                //If the user is larger than 0, it will slice the connection off the client list
                if (conPos >= 0) {
                    Clients.splice(conPos, 1);

                    //Creates a json object that notifies the server that the user has left.
                    var json = JSON.stringify({
                        type: "message",
                        data: { "msg": name + " just left!", "user": "server" }
                    });
            
                    //Foreach loop that sends out the json object.
                    for (var VAR in Clients) {
                        VAR.connection.sendUTF(json);
                    }
                    console.log("connection closed");
                } else {
                    console.log("connection was not able closed");
                }
            });

        function getUserIndex(name) {
            for (var VAR in Clients) {
                if (VAR.name == name) {
                    return VAR;
                }
            }
            return -1;
        }
    });