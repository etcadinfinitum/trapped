using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour {

    private System.Guid myGUID;

    private string myID;

    public void SetGuid(System.Guid guid) {
        myGUID = guid;
    }

    public System.Guid GetGuid() {
        return myGUID;
    }

    public void SetID(string id)
    {
        myID = id;
    }

    public string GetID()
    {
        return myID;
    }
}
