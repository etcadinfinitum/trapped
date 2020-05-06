using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGoalTrigger : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Triggered with goal" + count);
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Exited with goal" + count);
            count--;
        }
    }
}
