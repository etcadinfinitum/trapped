using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooter : MonoBehaviour
{
    [Header("Object Creation")]
    public GameObject dart; 
    
    [Header("Other options")]
    public float coolDown = 1f; 
    public float cooldownTimer; 
    public Vector2 shootDirection; 
    private float timeOfLastSpawn; 
    public bool relativeToRotation = true; 
    public float dartSpeed = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        shootDirection = new Vector2(1f, 1f); 
        cooldownTimer = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0){
            cooldownTimer -= Time.deltaTime; 
        }
        if (cooldownTimer < 0){
            cooldownTimer = 0; 
        }
    }

    public static float Angle(Vector2 inputVector)
	{
		if(inputVector.x<0) return (Mathf.Atan2(inputVector.x, inputVector.y)*Mathf.Rad2Deg*-1)-360;
		else return -Mathf.Atan2(inputVector.x,inputVector.y)*Mathf.Rad2Deg;
	}
    
    public void fire() {
        if (cooldownTimer == 0){
            Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, 
            transform.eulerAngles.z) * shootDirection) : shootDirection; 

            GameObject newObject = Instantiate<GameObject>(dart); 
            newObject.transform.position = this.transform.position; 
            //newObject.transform.eulerAngles = new Vector3(0f, 0f, Angle(actualBulletDirection)); 
            //newObject.transform.eulerAngles = transform.eulerAngles; 
            newObject.transform.rotation = this.transform.rotation; 
            //Push the created objects 
            Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>(); 
            if (rigidbody2D != null){
                rigidbody2D.AddForce(actualBulletDirection * dartSpeed, ForceMode2D.Impulse); 
            }
            cooldownTimer = coolDown; 
            timeOfLastSpawn = Time.time; 
        }
    }

    //NOTE: -45 = straight right 
    //45 = straight up
    //135 = straight left 
    //-135 = straight down
}
