using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour {

    private System.Guid myGUID;

    public string myID;

    private int myPlayerNumber;

    public void SetGuid(System.Guid guid) {
        myGUID = guid;
    }

    public System.Guid GetGuid() {
        return myGUID;
    }

    public void SetID(string id)
    {
        myID = id;
        //Debug.Log("Playerdata set id to" + id);
    }

    public string GetID()
    {
        return myID;
    }

    public int GetPlayerNumber()
    {
        return myPlayerNumber;
    }

    public void SetPlayerNumber(string playerNumber)
    {
        myPlayerNumber = int.Parse(playerNumber);
    }
}
