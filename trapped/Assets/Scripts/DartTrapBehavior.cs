using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DartTrapBehavior : MonoBehaviour
{
    
    public DartShooter dartShooter; 
    void Start()
    {  
        dartShooter = gameObject.GetComponent<DartShooter>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Debug.Log("1");
            if (dartShooter != null){
                Debug.Log("2");
                dartShooter.fire(); 
            }
        }
       // Destroy(gameObject); 
    } 
}
