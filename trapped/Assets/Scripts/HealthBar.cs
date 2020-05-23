using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = new Vector2(0 + 120, Screen.height - 50);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
