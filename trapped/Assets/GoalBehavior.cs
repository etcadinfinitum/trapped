using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private int totalInGoal = 0;
    private bool inGoal = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            totalInGoal++;
            Debug.Log("Triggered with goal" + totalInGoal);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            totalInGoal--;
            Debug.Log("Exited with goal" + totalInGoal);
        }
    }

    public int getNumberOfPlayersInGoal()
    {
        return totalInGoal;
    }
}
