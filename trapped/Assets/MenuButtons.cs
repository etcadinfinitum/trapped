﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject help;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showHelp()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");

        help.SetActive(true);
    }

    public void hideHelp()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        help.SetActive(false);
    }

    public void goPlay()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        SceneManager.LoadScene("ConnectScreen");
    }
}
