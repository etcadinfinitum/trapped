using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehavior : MonoBehaviour
{
    public bool testSet = false;
    private List<GameObject> otherPlayers = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTestSet(bool set)
    {
        testSet = set;
    }
}
