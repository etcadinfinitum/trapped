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
        ip = globalController.GetComponent<GlobalBehavior>().getIP();
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
        w = new WebSocket(new Uri("ws://"+ip+":"+port));

        yield return StartCoroutine(w.Connect());
        Debug.Log("CONNECTED TO WEBSOCKETS");

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

                // deserialize recieved data
                bool notMovement = true;
                try
                {
                    PlayersPositions data = JsonUtility.FromJson<PlayersPositions>(message);
                    updateOnReceiveMovement(data);
                    notMovement = false;
                }
                catch (ArgumentException e)
                {
                    Debug.Log("Message received was not movement data"+e);
                }
                if (notMovement)
                {
                    try
                    {
                        
                        Debug.Log("GOT MESSAGE OF" + message);
                        Message m = JsonUtility.FromJson<Message>(message);
                        Debug.Log("message was" + m.mode + m.id);
                        foreach(var x in otherPlayers)
                        {
                            string xID = x.GetComponent<PlayerData>().GetID();
                            if (xID == m.id)
                            {
                                Debug.Log("found and removed player");
                                otherPlayers.Remove(x);
                            }
                        }
                        
                    }
                    catch(ArgumentException e)
                    {
                        Debug.Log("WTF" + e);
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

    void updateOnReceiveMovement(PlayersPositions data)
    {
        // if number of players is not enough, create new ones
        if (data.players.Count > otherPlayers.Count)
        {
            for (int i = 0; i < data.players.Count - otherPlayers.Count; i++)
            {
                GameObject newGuy = Instantiate(otherPlayerObject, data.players[otherPlayers.Count + i].position, Quaternion.identity);
                newGuy.GetComponent<PlayerData>().SetID("set ID");
                otherPlayers.Add(newGuy);
                totalNumberOfPlayers++;
            }
        }
        // if number of players is greater than server sent, delete the right one
        else if (data.players.Count < otherPlayers.Count)
        {
            // TODO: implement
        }

        // update players positions
        for (int i = 0; i < otherPlayers.Count; i++)
        {
            // using animation
            //otherPlayers[i].transform.position = Vector3.Lerp(otherPlayers[i].transform.position, data.players[i].position, Time.deltaTime * 10F);
            // or without animation
            otherPlayers[i].transform.position = data.players[i].position;
        }
    }

    void OnApplicationQuit() {
        w.Close();
    }

    public int getTotalPlayerCount()
    {
        return totalNumberOfPlayers;
    }
}
