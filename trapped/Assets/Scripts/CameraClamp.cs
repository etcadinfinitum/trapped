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
        if (target.transform.position.x < 45.0f
            && target.transform.position.y > -29.0f) {

            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, -28.43f, 33.42f),
                Mathf.Clamp(target.position.y, -22.47f, 17.49f),
                target.position.z - cameraZAxisOffset);

        }

        //Follow for map 2
        if (target.transform.position.x > 51.0f
            && target.transform.position.y > -30.0f) {

            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, 62.61f, 119.41f),
                Mathf.Clamp(target.position.y, -23.46f, 18.47f),
                target.position.z - cameraZAxisOffset);

        }

        //Follow for map 3
        if (target.transform.position.x < 46.0f 
            && target.transform.position.y < -34.0f) {

            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, -29.44f, 34.45f),
                Mathf.Clamp(target.position.y, -87.49f, -40.51f),
                target.position.z - cameraZAxisOffset);

        }

        //Follow for map 4
        if (target.transform.position.x > 51.0f 
            && target.transform.position.y < -34.0f) {

            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, 62.56f, 125.46f),
                Mathf.Clamp(target.position.y, -86.49f, -40.51f),
                target.position.z - cameraZAxisOffset);

        }

    }
}
