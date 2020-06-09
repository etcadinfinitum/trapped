const WebSocket = require('ws')

// create new websocket server
const wss = new WebSocket.Server({port: 8000})

// empty object to store all players
var players = {}

// player number based on order of connection to server, increases on client connect, decreases on disconnect
var connectOrder = 1

// on new client connect
wss.on('connection', function connection (client) {
  console.log("client connected")
  // type of 'clients' is Set, so we use .size instead of .length
  console.log('# of connected clients: ' + wss.clients.size)
    
  //assign client's connect order on connect
  client.order = connectOrder
  console.log("Client's join order: " + client.order)
  connectOrder++
  //send join order to client
  var discomessage = {
        mode: 1,
        id: client.order
    }
  client.send(JSON.stringify(discomessage))
  
  // on new message recieved
  client.on('message', function incoming (data) {
    
    if (data.toString().charAt(0) == 'D') { //death message
        var [d, deadPlayerNumber] = data.toString().split('\t')
        console.log("d" + d)
        console.log("numb: " + deadPlayerNumber)
        console.log("death message")
        broadcastUID(deadPlayerNumber,2) //function should be renamed
    }
    else { //movement message
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
          id: udid+client.order,
        }
        // save player udid to the client
        client.udid = udid
    }
  })
  
  client.on('close', function incoming(code, reason) {
    console.log('client connection closed.\n\tcode: ' + code + '\n\treason: ' + reason);
    console.log("Udid was: " + this.udid)
    broadcastUID(this.udid + client.order, 0)
    delete players[client.udid];
    connectOrder--;
  })
})


//called when client disconnects (mode 0). More modes currently not implemented
function broadcastUID(uid, modeType){
    //console.log("broadcastUID, (uid, mode): " + uid + " " +modeType)
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
    // send it
    client.send(JSON.stringify({players: otherPlayersData}))
  })
}

// call broadcastUpdate every 0.1s
setInterval(broadcastUpdate, 100)
