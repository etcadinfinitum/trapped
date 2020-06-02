using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerStatus status;
    public Sprite zombieFace;
    public Sprite face;
    public SpriteRenderer spriteRenderer;


    private bool died;
    public bool levelComplete;
    public GameObject[] map1SpawnPoints;
    public GameObject[] map2SpawnPoints;
    public GameObject[] map3SpawnPoints;
    public GameObject[] map4SpawnPoints;

    public void Start() {
        //Reference the status script values
        status = GetComponent<PlayerStatus>();

        //Reference the sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        //get the possible spawns on map1
        map1SpawnPoints = GameObject.FindGameObjectsWithTag("Map1Respawn");
        map2SpawnPoints = GameObject.FindGameObjectsWithTag("Map2Respawn");
        map3SpawnPoints = GameObject.FindGameObjectsWithTag("Map3Respawn");
        map4SpawnPoints = GameObject.FindGameObjectsWithTag("Map4Respawn");

        //should start as false
        died = false;
        levelComplete = false;
    }

    public void Update() {
        //Always want to be checking for isAlive
        if (!status.isAlive) {

            //died bool needed so this only happens once per death.
            if (!died) {

                //allow the player to preform the death behaviors
                died = true;

                //change tag so now the player is not needed in the goal to finish level
                //gameObject.tag = "Zombie";

                //Change the player sprite to zombie.
                spriteRenderer.sprite = zombieFace;

                //respawn at semi-random location on current map
                respawn();
            }

            //when level complete revive player and change sprite back only once.
            if(levelComplete) {
                spriteRenderer.sprite = face;
                status.revive();

                //nesscary to register player for next level
                //gameObject.tag = "Player";
                levelComplete = false;
                died = false;
            }

        } else { //player is alive

            if(levelComplete) { //if the level gets completed want to make sure we still reset this just like before ^
                levelComplete = false;
                died = false;
            }

        }


    }

    //respawning behavior
    public void respawn() {

        //respawn on map 1
        if (transform.position.x < 45.0f && transform.position.y > -29.0f) {
            //use random to generate a number and pick where to spawn player based on where they are on the map.
            int i = Random.Range(0, map1SpawnPoints.Length);
            transform.position = map1SpawnPoints[i].GetComponent<Transform>().position;
        }

        //respawn on map 1
        if (transform.position.x > 51.0f && transform.position.y > -30.0f) {
            int i = Random.Range(0, map2SpawnPoints.Length);
            transform.position = map2SpawnPoints[i].GetComponent<Transform>().position;
        }

        //respawn on map 1
        if (transform.position.x < 46.0f && transform.position.y < -34.0f) {
            int i = Random.Range(0, map3SpawnPoints.Length);
            transform.position = map3SpawnPoints[i].GetComponent<Transform>().position;
        }

        //respawn on map 1
        if (transform.position.x > 51.0f && transform.position.y < -34.0f) {
            int i = Random.Range(0, map4SpawnPoints.Length);
            transform.position = map4SpawnPoints[i].GetComponent<Transform>().position;
        }
    }

}
