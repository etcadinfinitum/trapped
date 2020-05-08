using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Multiplayer 2D Uses 
 * 
 * 
 * 
 * 
 *
*/
public class GoalBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private int totalInGoal = 0;
    private bool inGoal = false;
    public GameObject teleportLocation;
    public GameObject newCameraLocation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //check if all players are in goal
        if(GameObject.Find("Player").GetComponent<Multiplayer2D>().getTotalPlayerCount() == totalInGoal)
        {
            if (teleportLocation != null)
            {
                GameObject.Find("Player").transform.position = teleportLocation.transform.position;
                Camera.main.transform.position = newCameraLocation.transform.position;
            }
            else
            {
                Debug.Log("No teleport location set for goal!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            totalInGoal++;
            //Debug.Log("Triggered with goal" + totalInGoal);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            totalInGoal--;
            //Debug.Log("Exited with goal" + totalInGoal);
        }
    }

    public int getNumberOfPlayersInGoal()
    {
        return totalInGoal;
    }
}
