using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour {

    private System.Guid myGUID;

    public string myID;

    public string myPlayerName;

    private int myPlayerNumber;

    private bool blind = false;

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

    public string GetPlayerName()
    {
        return myPlayerName;
    }

    public void SetPlayerName(string newName)
    {
        myPlayerName = newName;
    }

    //set the player name
    public void SetName(string newName)
    {
        myPlayerName = newName;
        Debug.Log("Player Name set to: " + newName);
    }

    //used for text vars
    public string GetName()
    {
        return myPlayerName;
    }

    public void SetVision(bool newValue) {
        // TODO: set default timeout?
        if (newValue != blind) {
            // TODO: invoke a coroutine to fade the "Blinded" GameObject's alpha
            blind = newValue;
        }
    }

    public void ToggleVision() {
        // TODO: invoke a coroutine to fade the "Blinded" GameObject's alpha
        blind = !blind;
    }
}
