using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModPlayerForBeam : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Enter Beam");
        CircleCollider2D player = collision.GetComponent<CircleCollider2D>();
        player.radius = .2f;
    }
}
