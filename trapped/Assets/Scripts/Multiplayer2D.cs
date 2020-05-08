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
public class Players
{
    public List<Position> players;
}

public class Multiplayer2D : MonoBehaviour
{

    // define public game object used to visualize other players
    public GameObject otherPlayerObject;

    private Vector3 prevPosition;
    private List<GameObject> otherPlayers = new List<GameObject>();

    private GameObject globalController;

    private GameObject goal;

    bool nextScene = false;

    private int totalNumberOfPlayers;

    IEnumerator Start()
    {
        // get global controller
        globalController = GameObject.Find("GlobalController");
        
        goal = GameObject.Find("Goal");

        // get player
        GameObject player = GameObject.Find("Player");
        totalNumberOfPlayers++;
        // connect to server TODO: Get this working not using local host (127.0.0.1)
        WebSocket w = new WebSocket(new Uri("ws://127.0.0.1:8000"));
        yield return StartCoroutine(w.Connect());
        Debug.Log("CONNECTED TO WEBSOCKETS");

        // generate random ID to have idea for each client (feels unsecure)
        System.Guid myGUID = System.Guid.NewGuid();

        // wait for messages
        while (true)
        {
            // read message
            string message = w.RecvString();
            // check if message is not empty
            if (message != null)
            {
                // Debug.Log("RECEIVED FROM WEBSOCKETS: " + reply);

                // deserialize recieved data
                Players data = JsonUtility.FromJson<Players>(message);
                // if number of players is not enough, create new ones
                if (data.players.Count > otherPlayers.Count)
                {
                    for (int i = 0; i < data.players.Count - otherPlayers.Count; i++)
                    {
                        otherPlayers.Add(Instantiate(otherPlayerObject, data.players[otherPlayers.Count + i].position, Quaternion.identity));
                        totalNumberOfPlayers++;
                    }
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

    /*
    public List<GameObject> getPlayersList()
    {
        return otherPlayers;
    }
    */

    public int getTotalPlayerCount()
    {
        return totalNumberOfPlayers;
    }
}
