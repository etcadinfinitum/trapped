using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private Multiplayer2D sceneChangeScript;

    // Start is called before the first frame update
    void Start()
    {
        sceneChangeScript = GameObject.Find("NetworkingController").GetComponent<Multiplayer2D>();
    }

    public void StartGameButtonClick() {
        // TODO: send message to everyone else
        sceneChangeScript.InitiateSwitchToMazeScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
