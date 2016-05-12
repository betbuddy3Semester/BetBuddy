var server = require('websocket').server, http = require('http');
var clients = [];
var socket = new server({
    httpServer: http.createServer().listen(1337)
});

socket.on('request', function (request) {
    var connection = request.accept(null, request.origin);
    var name = "error";

    connection.on('message', function (message) {
        console.log(message.utf8Data);
        if (message.utf8Data.split(" ")[0] == "/setUserName") {
            name = message.utf8Data.split(" ")[1];
            clients.push({ "name": name, "connection": connection });
        } else if (name == "error") {
            var json = JSON.stringify({ type: 'message', data: { "msg": "you have to login to chat", "user": "server" } });
            connection.sendUTF(json);
        } else {
            var json = JSON.stringify({ type: 'message', data: { "msg": message.utf8Data, "user": name } });
            for (var i = 0; i < clients.length; i++) {
                clients[i].connection.sendUTF(json);
            }
        }
        /*//connection.sendUTF('hello');
        setTimeout(function() {
            var json = JSON.stringify({ type:'message', data: {"msg":'this is a websocket example', "user":  "server"}});
            connection.sendUTF(json);
        }, 1000);*/
    });

    connection.on('close', function (connection) {
        console.log("clients:" + clients.length + " name: " + name);
        var conPos = getUserIndex(name);
        if (conPos >= 0) {
            clients.splice(name, 1);
            var json = JSON.stringify({ type: 'message', data: { "msg": name + " just left!", "user": "server" } });
            for (var i = 0; i < clients.length; i++) {
                clients[i].connection.sendUTF(json);
            }
            console.log('connection closed');
        } else {
            console.log('connection was not able closed');
        }
    });

    function getUserIndex(name) {
        for (var i = 0; i < clients.length; i++) {
            if (clients[i].name == name) {
                return i;
            };
        };
        return -1;
    }
});