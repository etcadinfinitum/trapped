using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    PlayerData[] players; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerData[] temp = FindObjectsOfType<PlayerData>();
        players = new PlayerData[temp.Length]; 
        if (players.Length == 0){
            Debug.Log("No players found... wat :0"); 
        } else {
            //Sorting in order of playerID
            /*foreach (PlayerData player in temp){
                Debug.Log(player.name);
                //players[Int32.Parse(player.GetID())] = player; 
            } */
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator stunPlayer(PlayerMovement player) {
        yield return new WaitForSeconds(2); 
        Debug.Log("!@#!@#!@");
        player.enabled = true; 
        Debug.Log("Player is unstunned now.");
    }

    void OnCollisionEnter2D(Collision2D colliderObj){
        string tag = colliderObj.gameObject.tag; 

        if (tag == "Player") {
            //....
            PlayerBehavior player = colliderObj.gameObject.GetComponent<PlayerBehavior>(); 
            if (player != null){
                if (this.gameObject.tag == "Stun Trap"){
                    Debug.Log("Player Stunned!"); 
                    player.GetStunned();
                } else if (this.gameObject.tag == "Tele Trap") {
                    Debug.Log("Player Teleported!"); 
                    player.Teleport();
                }
            }
            
        }
        Destroy(this.gameObject);
    } 
}
