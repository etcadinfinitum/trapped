﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehavior : MonoBehaviour
{
    private static string ip;

    private string playerName;
    
    

    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        /*
        if (ip != null)
        {
            Debug.Log("ip: " + ip);
        }
        else
        {
            Debug.Log("ip not set");
        }*/
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //set the static ip, used by ConnectButton script on connection scene
    public void SetIP(string inputIP)
    {
        ip = inputIP;
        Debug.Log("set ip to: " + ip);
    }

    //used by multiplayer2d script to set the connection ip
    public string GetIP()
    {
        return ip;
    }

    //set the player name
    public void SetName(string newName)
    {
        playerName = newName;
        Debug.Log("Player Name set to: " + newName);
    }

    //used for text vars
    public string GetName()
    {
        return playerName;
    }
}
