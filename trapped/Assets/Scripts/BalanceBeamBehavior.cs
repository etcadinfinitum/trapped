using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBeamBehavior : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Fall");
        GameObject player = GameObject.Find("Player");
        player.GetComponent<CircleCollider2D>().radius = .9f;
        player.GetComponent<PlayerStatus>().kill();
    }

}
