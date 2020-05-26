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
            if (gameObject.tag == "Normal Dart"){
                Debug.Log("Player hit with a normal dart"); 
            } else if (gameObject.tag == "Poison Dart") {
                Debug.Log("Player got the big sicc");
            }
        }
        Destroy(gameObject); 
    }
}
