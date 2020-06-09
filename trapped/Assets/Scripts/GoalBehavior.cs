using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private int totalInGoal = 0;
    public GameObject teleportLocation;
    private GameObject player;

    private GameObject[] alivePlayers;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        alivePlayers = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        //check if all players are in goal
        if (player.GetComponent<Multiplayer2D>().GetTotalPlayerCount() == totalInGoal)
        {
            if (teleportLocation != null)
            {
                StartCoroutine(TeleportPlayers());
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
            Debug.Log("An additional player has entered the goal");
            totalInGoal++;
            //Debug.Log("Triggered with goal" + totalInGoal);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("An additional player has left the goal");
            totalInGoal--;
            //Debug.Log("Exited with goal" + totalInGoal);
        }
    }

    public int GetNumberOfPlayersInGoal()
    {
        return totalInGoal;
    }

    IEnumerator TeleportPlayers()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(teleportLocation.transform.position.x, teleportLocation.transform.position.y, 0);
        player.GetComponent<PlayerDeath>().levelComplete = true;
        player.GetComponent<Multiplayer2D>().ReviveOtherPlayers();
    }
}
