using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D colliderObj){
        string tag = colliderObj.gameObject.tag; 

        if (tag == "Player") {
            PlayerBehavior player = colliderObj.gameObject.GetComponent<PlayerBehavior>();
            PlayerStatus status = colliderObj.gameObject.GetComponent<PlayerStatus>();
            if (gameObject.tag == "Normal Dart"){
                Debug.Log("Poison not");
                status.subtractHealth(20f);
            } else if (gameObject.tag == "Poison Dart") {
                Debug.Log("Poison");
                status.subtractHealth(5f);
                status.addCondition("poisoned", 10f);
                GameObject.Find("GameAnnouncements").GetComponent<PopupManager>().playerPoison("POISONED", 3f);
            }
        }
        Destroy(gameObject); 
    }
}
