using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamFollow : MonoBehaviour
{
    public Transform target;
    public int cameraZAxisOffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraZAxisOffset = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - cameraZAxisOffset);

    }
}
