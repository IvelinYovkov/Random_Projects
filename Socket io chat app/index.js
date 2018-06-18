var express = require('express');
var app = express();
var server = require('http').createServer(app);
var io = require('socket.io').listen(server);
users = [];
connections = [];

server.listen(process.env.PORT || 3707);
console.log('Server is on');


app.get('/',function(req, res){
    res.sendFile(__dirname + '/index.html')
});

io.sockets.on('connection', function(socket){
    connections.push(socket);
    console.log('Connected : %s connected' + " " + socket.handshake.address ,connections.length);

    //Disconnect
    socket.on('disconnect', function(data){
        users.splice(users.indexOf(socket.username), 1);
        connections.splice(connections.indexOf(socket),1);
        updateUsernames();
        console.log('Disconnection' + " " +  socket.username + " " + socket.handshake.address );
    });

    socket.on('send message', function(data){
        io.sockets.emit('new message', {msg:data});
    });

    socket.on('new user', function(data, callback){
        callback(true);
        socket.username = data;
        users.push(socket.username); 
        updateUsernames();
    })

    function updateUsernames(){
        io.sockets.emit('get users', users);
    }
})