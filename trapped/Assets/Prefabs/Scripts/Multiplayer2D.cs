using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

// define classed needed to deserialize recieved data
[Serializable]
public class Position
{
    public Vector3 position;
    public int timestamp;
    public string id;
}
[Serializable]
public class PlayersPositions
{
    public List<Position> players;

}
[Serializable]
public class Message
{
    public int mode;
    public string id;
}

public class Multiplayer2D : MonoBehaviour
{

    // define public game object used to visualize other players
    public GameObject otherPlayerObject;

    private Vector3 prevPosition;
    private List<GameObject> otherPlayers = new List<GameObject>();

    public List<string> playerNames = new List<string>();

    private GameObject globalController;

    private int totalNumberOfPlayers;

    private string ip;
    private int port = 8000;

    private WebSocket w = null;

    IEnumerator Start()
    {


        // get player
        GameObject player = GameObject.Find("Player");
        totalNumberOfPlayers++;


        // get global controller, use IP in global controller
        globalController = GameObject.Find("GlobalController");
        ip = globalController.GetComponent<GlobalBehavior>().GetIP();
        player.GetComponent<PlayerData>().SetPlayerName(globalController.GetComponent<GlobalBehavior>().GetName());
        if (ip == null) //if ip was set on connection scene, use that. else use default
        {
            #if (UNITY_EDITOR)
            ip = "127.0.0.1";
            #else
            ip = "138.68.84.89"; //permament server ip
            #endif
            Debug.Log("IP not set on connection scene, using" + ip);
        }

        // connect to server
        w = new WebSocket(new Uri("wss://"+ip+":"+port));

        yield return StartCoroutine(w.Connect());
        Debug.Log("CONNECTED TO WEBSOCKETS; IP is " + ip);

        // generate random ID to have idea for each client (feels unsecure)
        System.Guid myGUID = System.Guid.NewGuid();

        player.GetComponent<PlayerData>().SetGuid(myGUID);

        // wait for messages
        while (true)
        {
            // read message
            string message = w.RecvString();
            
            // check if message is not empty
            if (message != null)
            {
                //Debug.Log("RECEIVED FROM WEBSOCKETS: " + message);

                // DESERIALIZE RECEIVED DATA
                // currently data can come in two forms, player movement or player uid + mode
                bool notMovement = true;
                try //check if received message is movement
                {
                    //Debug.Log(message);
                    PlayersPositions data = JsonUtility.FromJson<PlayersPositions>(message);
                    UpdateOnReceiveMovement(data);
                    notMovement = false;
                }
                catch (ArgumentException)
                {
                    //Debug.Log("Message received was not movement data");//+e);
                }
                if (notMovement)
                {
                    try //if it's not movement, it's a disconnect message
                    {
                        Message m = JsonUtility.FromJson<Message>(message);
                        //Debug.Log("message was" + m.mode + m.id);
                        ProcessMessage(m);
                        
                    }
                    catch(ArgumentException e)
                    {
                        Debug.Log("Recieved data in unknown format from server: " + e);
                    }
                }
            }

            // if connection error, break the loop
            if (w.error != null)
            {
                Debug.LogError("Connection Error: " + w.error);
                break;
            }

            // check if player moved
            if (prevPosition != player.transform.position)
            {
                // send update if position had changed
                w.SendString(myGUID + "\t" + player.transform.position.x + "\t" + player.transform.position.y + "\t" + player.transform.position.z);
                prevPosition = player.transform.position;
            }

            yield return 0;
            //yield return null for not allocating memory?
        }
        // if error, close connection
        Debug.Log("Error occured, closing connection");
        w.Close();

    }

    void UpdateOnReceiveMovement(PlayersPositions data)
    {
        // if number of players is not enough, create new ones
        if (data.players.Count > otherPlayers.Count)
        {
            for (int i = 0; i < data.players.Count - otherPlayers.Count; i++)
            {
                GameObject newPlayer = Instantiate(otherPlayerObject, data.players[otherPlayers.Count + i].position, Quaternion.identity);
                // incoming id is udid with join order concatenated at end
                string incomingId = data.players[otherPlayers.Count + i].id;
                string playerJoinOrder = incomingId.Substring(incomingId.Length - 1);
                //Debug.Log("join order: " + playerJoinOrder);
                newPlayer.GetComponent<PlayerData>().SetID(incomingId);
                newPlayer.GetComponent<PlayerData>().SetID(incomingId);
                otherPlayers.Add(newPlayer);
                totalNumberOfPlayers++;
            }
        }

        // update other player positions (does not assume sorted data from server, but a little inefficient)
        foreach (var player in otherPlayers)
        {
            foreach(var playerData in data.players)
            {
                if (player.GetComponent<PlayerData>().GetID().Equals(playerData.id))
                {
                    // using animation
                    //player.transform.position = Vector3.Lerp(player.transform.position, playerData.position, Time.deltaTime * 10F);
                    player.transform.position = playerData.position;
                    break;
                }
            }
            
        }

    }

    void ProcessMessage(Message m)
    {
        switch (m.mode)
        {
            // disconnect client mode
            case 0:
                GameObject found = null;
                //iterate through the players list, and fine the player
                foreach (var x in otherPlayers)
                {
                    string xID = x.GetComponent<PlayerData>().GetID();
                    //Debug.Log("compare" + xID + " " + m.id);
                    if (xID.Equals(m.id))
                    {
                        //Debug.Log("found and removed player");
                        found = x;

                    }
                }
                // need to destroy the player if found outside foreach loop, otherwise get exception
                // (can't delete an element from a collection while iterating through it)
                if (found != null)
                {
                    Destroy(found);
                    otherPlayers.Remove(found);
                    totalNumberOfPlayers--;
                    //Debug.Log("removed");
                }
                break;

                //OPTIONAL implement other modes as needed
        }
    }

    void OnApplicationQuit() {
        w.Close();
    }

    public int GetTotalPlayerCount()
    {
        return totalNumberOfPlayers;
    }

    public List<GameObject> GetOtherPlayers()
    {
        return otherPlayers;
    }

    // get player by join order (starting from 1), returns null if not found
    public GameObject GetPlayer(int number)
    {
        foreach(var player in otherPlayers)
        {
            if(player.GetComponent<PlayerData>().GetPlayerNumber() == number)
            {
                return player;
            }
        }
        return null;
    }
}
