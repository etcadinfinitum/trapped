using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntPlayerBehavior : MonoBehaviour
{
    private GameObject player; //for access to multiplayer2D script
    private GameObject target = null;
    private NavMeshAgent agent = null;
    private bool playerNotFound = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // stops the agent from slowing down around corners
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // agent needs to chase player only after multiplayer2D script has determined what player to target
        if (playerNotFound)
        {
            if (player.GetComponent<Multiplayer2D>().GetPlayer(1) != null)
            {
                target = player;
                playerNotFound = false;
            }
        }
        else
        {
            agent.SetDestination(target.transform.position);
        }

    }
}
