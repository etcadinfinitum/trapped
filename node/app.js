const WebSocket = require('ws');

// create new websocket server
const wss = new WebSocket.Server({port: 8000});

/*
  games = {
    gameCode: true or false. True indicates game is in progress.
    }
    ...
  }
*/

games = {};

// empty object to store all players
// players must also contain gameCode 
var players = {};

// player number based on order of connection to server.
// increases on client connect, decreases on disconnect
var connectOrder = 1;

// on new client connect
wss.on('connection', function connection (client) {
  console.log("client connected");
  // type of 'clients' is Set, so we use .size instead of .length
  console.log('# of connected clients: ' + wss.clients.size);
    
  //assign client's connect order on connect
  client.order = connectOrder;
  console.log("Client's join order: " + client.order);
  connectOrder++;
  
  // on new message recieved
  client.on('message', function incoming (data) {
    if (data.toString() === "begin") {
        console.log("Client pressed start game button; notifying all clients for game session " + client.gameCode);
        games[client.gameCode] = true;
        beginForAllClients(client.gameCode);
        return;
    }
    // get data from string
    var [gameCode, udid, x, y, z] = data.toString().split('\t');
    
    // process initial data transmission
    if (!players.hasOwnProperty(udid)) {
        console.log("Processing first connection for game " + gameCode + " and client UDID " + udid);
        // 
        if (!games.hasOwnProperty(gameCode)) {
          games[gameCode] = false;
          //send join order to client
          var discomessage = {
            mode: 1,
            id: client.order
          };
          client.send(JSON.stringify(discomessage));
        } else if (games[gameCode]) {
          // indicates game is in progress; do not interrupt
          client.close();
        }
    }
    // store data to players object
    players[udid] = {
      session: gameCode,
      position: {
        x: parseFloat(x),
        y: parseFloat(y),
        z: parseFloat(z)
      },
      timestamp: Date.now(),      
      id: udid+client.order,
    };
    // save player udid to the client
    client.udid = udid;
    client.gameCode = gameCode;
  });
  
  client.on('close', function incoming(code, reason) {
    console.log('client connection closed.\n\tcode: ' + code + '\n\treason: ' + reason);
    console.log("Udid was: " + this.udid);
    broadcastUID(this.udid + client.order, 0);
    delete players[client.udid];
    connectOrder--;
  });
});


//called when client disconnects (mode 0). More modes currently not implemented
function broadcastUID(uid, modeType){
    //console.log("broadcastUID, (uid, mode): " + uid + " " +modeType)
    var message = {
        mode: modeType,
        id: uid
    };
    // broadcast messages to all clients
    wss.clients.forEach(function each (client) {
      // filter disconnected clients
      if (client.readyState !== WebSocket.OPEN) {
          return;
      }
      // filter out current player by client.udid
      var otherPlayers = Object.keys(players).filter(session => session === client.gameCode).filter(udid => udid !== client.udid);
      // create array from the rest
      client.send(JSON.stringify(message));
  });
}

function beginForAllClients(gameCode) {
    console.log("Starting game with game code " + gameCode);
    wss.clients.forEach(function each (client) {
      console.log("Processing client with UDID " + client.udid + " and game code " + client.gameCode);
      // filter disconnected clients
      if (client.readyState !== WebSocket.OPEN) {
          return;
      }
      if (client.gameCode !== gameCode) {
          return;
      }
      // filter player data
      // var sessionPlayers = Object.keys(players).filter(session => session === client.gameCode);
      console.log("Sending begin message to client!");
      var msg = {
          mode: 2,
          id: "begin",
      };
      client.send(JSON.stringify(msg));
    });
}

function broadcastUpdate () {
  // broadcast messages to all clients
  wss.clients.forEach(function each (client) {
    // filter disconnected clients
    if (client.readyState !== WebSocket.OPEN) {
        return;
    }
    // filter clients who have not begun game
    if (!games[client.gameCode]) {
        return;
    }
    // filter clients who are not part of client's game session
    var gamePlayers = Object.keys(players).filter(udid => players[udid].session === client.gameCode);
    // console.log("Game players: " + JSON.stringify(gamePlayers, null, 4));
    typeof(gamePlayers);
    // filter out current player by client.udid
    var otherPlayers = gamePlayers.filter(udid => udid !== client.udid);
    // console.log("Other players in game: " + JSON.stringify(otherPlayers, null, 4));
    // create array from the rest
    var otherPlayersData = otherPlayers.map(udid => players[udid]);
    // send it
    client.send(JSON.stringify({players: otherPlayersData}));
  });
}

// call broadcastUpdate every 0.1s
setInterval(broadcastUpdate, 100);
