using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour {

    //Big help from: https://www.youtube.com/watch?v=ula1o_ZsMU0

    //Player that should be followed
    public Transform target;

    //How far the camera should be offset on Z axis from player
    public int cameraZAxisOffset;

    void Start() {
        cameraZAxisOffset = 3;
    }

    void Update() {

        //Follow for map 1
        if (target.transform.position.x > -39.51f) {
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, -28.43f, 33.42f),
                Mathf.Clamp(target.position.y, -22.47f, 17.49f),
                target.position.z - cameraZAxisOffset);
        }

        //Follow for map 2
        if (target.transform.position.x > 51.47 && target.transform.position.x < 130.52) {
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, 62.61f, 119.41f),
                Mathf.Clamp(target.position.y, -23.46f, 18.47f),
                target.position.z - cameraZAxisOffset);
        }

    }
}
