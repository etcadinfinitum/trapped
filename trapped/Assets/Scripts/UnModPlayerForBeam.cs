using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnModPlayerForBeam : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Exit Beam");
        CircleCollider2D player = collision.GetComponent<CircleCollider2D>();
        player.radius = .9f;
    }

}
