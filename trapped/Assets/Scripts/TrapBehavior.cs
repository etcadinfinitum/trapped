using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    PlayerData[] players; 
    bool active; //used for teleportation traps 
    bool isTransforming; 
    float lastTime; //Keeps track of last time since state change 
    float timeCooldown; //How long before switching states 
    float transformTime; 
    // Start is called before the first frame update
    float amountFilled; 
    void Start()
    {
        active = true; //All teleportation traps are active in the beginning 
        isTransforming = false; 
        lastTime = Time.deltaTime; 
        timeCooldown = 3.0f; 
        transformTime = 0.66f; 
        amountFilled = 1.0f; //Represents how transparent the trap will be. 1 = 100%. 0 = 0% scaling. 
        PlayerData[] temp = FindObjectsOfType<PlayerData>();
        players = new PlayerData[temp.Length]; 
        if (players.Length == 0){
            Debug.Log("No players found... wat :0"); 
        } 
    }

    private void changeState(){
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>(); 
        Color color = gameObject.GetComponent<SpriteRenderer>().color; 
        if (active) { //Decrement by 0.2 each step 
            collider.enabled = false ; 
            //Debug.Log("WEHIQEH");
            color.a -= 0.2f; 
        } else { //Increment by 0.2 each step. 
            color.a += 0.2f; 
            //Debug.Log("Weeeeeeeeee");
        }
        gameObject.GetComponent<SpriteRenderer>().color = color; 
        if (color.a >= 1.0f){
            color.a = 1.0f; 
            collider.enabled = true; 
            active = true; 
            isTransforming = false; 
        } else if (color.a <= 0.0f){
            color.a = 0.0f;
            active = false;
            isTransforming = false;  
            timeCooldown = 3.0f;
        }
    }
    private void checkTime() {
        if (this.gameObject.tag == "Tele Trap"){
            if (isTransforming && transformTime == 0) {
                changeState();
                transformTime = 0.66f; //2/3 of a second seems like a good time
            } else if (timeCooldown == 0){
                //Either increment or decrement here. 
                Debug.Log("Beginning state change"); 
                isTransforming = true; 
                timeCooldown = 3.0f; 
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransforming) {
            timeCooldown -= Time.deltaTime; 
            if (timeCooldown < 0) {
                timeCooldown = 0; 
                isTransforming = true; 
            }
            
        } else {
            transformTime -= Time.deltaTime; 
            if (transformTime < 0){
                transformTime = 0;
            }
        }
        checkTime(); 
    }

    void OnCollisionEnter2D(Collision2D colliderObj){
        string tag = colliderObj.gameObject.tag; 

        if (tag == "Player") {
            //....
            PlayerBehavior player = colliderObj.gameObject.GetComponent<PlayerBehavior>(); 
            if (player != null){
                if (this.gameObject.tag == "Stun Trap"){
                    Debug.Log("Player Stunned!");
                    colliderObj.gameObject.GetComponent<PlayerStatus>().subtractHealth(10);
                    player.GetStunned();
                } else if (this.gameObject.tag == "Tele Trap") {
                    Debug.Log("Player Teleported!"); 
                    player.Teleport();
                }
            }
        }
        if (this.gameObject.tag == "Stun Trap"){
            Destroy(this.gameObject); 
        }
    } 
}
