const WebSocket = require('ws')

// create new websocket server
const wss = new WebSocket.Server({port: 8000})

// empty object to store all players
var players = {}

// on new client connect
wss.on('connection', function connection (client) {
  console.log("client connected")
//  client.broadcastyest = false
  // type of 'clients' is Set, so we use .size instead of .length
  console.log('# of connected clients: ' + wss.clients.size);
  // on new message recieved
  client.on('message', function incoming (data) {
    // get data from string
    var [udid, x, y, z] = data.toString().split('\t')
    // store data to players object
    players[udid] = {
      position: {
        x: parseFloat(x),
        y: parseFloat(y),
        z: parseFloat(z)
      },
      timestamp: Date.now(),
      id: udid,
    }
    // save player udid to the client
    client.udid = udid
    
//    if(!client.broadcastyest){
//        broadcastUID(client.udid, 1)
//        client.broadcastyest = true;
//    }
    
  })
  client.on('close', function incoming(code, reason) {
    console.log('client connection closed.\n\tcode: ' + code + '\n\treason: ' + reason);
    console.log("idwas: " + this.udid)
    console.log("stringified: " + JSON.stringify(this.udid))
    broadcastUID(this.udid, 0)
    delete players[client.udid];
  })
})

//called when client connects and disconnects (mode 0 = disconnect, mode 1 = connect)
function broadcastUID(uid, modeType){
    console.log("broadcastUID, (uid, mode): " + uid + " " +modeType)
    var message = {
        mode: modeType,
        id: uid
    }
      // broadcast messages to all clients
  wss.clients.forEach(function each (client) {
    // filter disconnected clients
    if (client.readyState !== WebSocket.OPEN) {
        return;
    }
    // filter out current player by client.udid
    var otherPlayers = Object.keys(players).filter(udid => udid !== client.udid)
    // create array from the rest
    client.send(JSON.stringify(message))
  })
}

//{"players":[{"position":{"x":-9.82,"y":-0.49,"z":0},"timestamp":1589345653651}]}
function broadcastUpdate () {
  // broadcast messages to all clients
  wss.clients.forEach(function each (client) {
    // filter disconnected clients
    if (client.readyState !== WebSocket.OPEN) {
        return;
    }
    // filter out current player by client.udid
    var otherPlayers = Object.keys(players).filter(udid => udid !== client.udid)
    // create array from the rest
    var otherPlayersData = otherPlayers.map(udid => players[udid])
    console.log(otherPlayersData);
    // send it
    client.send(JSON.stringify({players: otherPlayersData}))
  })
}

// call broadcastUpdate every 0.1s
setInterval(broadcastUpdate, 2000)
