using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DistanceHealth : MonoBehaviour {

    float nextCheck = 0.5f;
    Multiplayer2D mpScript = null;
    List<GameObject> otherPlayers = null;
    GameObject player = null;
    PlayerStatus healthData = null;
    PopupManager announcer = null;
    bool tooFar = false;
    public float acceptableDistance = 8;

    void Start() {
        player = GameObject.Find("Player");
        mpScript = player.GetComponent<Multiplayer2D>();
        healthData = player.GetComponent<PlayerStatus>();
        announcer = GameObject.Find("GameAnnouncement").GetComponent<PopupManager>();
        // get list of other players
        otherPlayers = mpScript.GetOtherPlayers();
    }

    void Update() {
        if (Time.time < nextCheck) {
            return;
        }
        otherPlayers = mpScript.GetOtherPlayers();
        // get midpoint vector
        Vector3 pos = player.transform.position;
        Debug.Log("Count of other players: " + otherPlayers.Count);
        foreach (GameObject p in otherPlayers) {
            pos += p.transform.position;
        }
        // get magnitude of distance
        Vector3 midpoint = pos / (otherPlayers.Count + 1);
        float dist = (midpoint - pos).magnitude;
        Debug.Log("Distance from player midpoint: " + dist);
        // check if player is outside acceptable distance from midpoint
        if (dist > acceptableDistance) {
            if (!tooFar) {
                tooFar = true;
                Debug.Log("Player is too far away from others!");
                // queue message
                announcer.createPopup("Return to your team or you will wither!", 1.5f);
            }
            // decrement health
            healthData.health -= Mathf.Ceil(dist / 10f);
        } else {
            if (tooFar) {
                tooFar = false;
                Debug.Log("Player is back within range!");
                // queue message
                announcer.createPopup("You've returned and the danger has passed!", 0.5f);
            }
        }
        nextCheck = Time.time + 0.5f;
    }
}
