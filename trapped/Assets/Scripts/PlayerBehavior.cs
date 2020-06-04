using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;
using WaterRippleForScreens;

public class PlayerBehavior : MonoBehaviour
{
    PlayerMovement position; 
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetStunned(){
        PlayerMovement player = GetComponent<PlayerMovement>(); 
        player.enabled = false;
        StartCoroutine(stun(player)); 
    }
    IEnumerator stun(PlayerMovement player) {
        GameObject.Find("GameAnnouncements").GetComponent<PopupManager>().playerStun("SNARED", 1.5f);
        yield return new WaitForSeconds(2);
        //Unfreeze the player
        player.enabled = true;
    }

    public void Teleport() {
        GameObject.Find("Main Camera").GetComponent<RippleEffect>().SetNewRipplePosition(new Vector2(Screen.width/2, Screen.height/2));
        GameObject.Find("GameAnnouncements").GetComponent<PopupManager>().playerTeleport("TELEPORTED", 1.5f);
        transform.position = new Vector3(-7.5f, 1f, 0.5f);
    }
    public void OnTriggerEnter(Collider collider){
        Debug.Log("Herm it works now");
    }
/*
    private void OnCollisionEnter2D(Collision2D colliderObj){
        if (colliderObj.gameObject.tag == "Tele Trap"){
            Teleport();
        }
    }*/
    /*
    void OnCollisionEnter2D(Collision2D colliderObj){
        if (colliderObj.gameObject.tag == "Stun Trap"){
            Debug.Log("Player is stunned");
            Destroy(colliderObj.gameObject);
            Debug.Log("Player is going to be stunned for 2 seconds now"); 
            PlayerMovement cc = GetComponent<PlayerMovement>(); 
            //Freeze the player 
            cc.enabled = false; 
            //Make them sleep for 2 seconds 
            StartCoroutine(stun(cc));

            //Deletes from server view but not client. So we need to destroy this local copy.
            Destroy(colliderObj.gameObject);  
        }
    }
*/
}
