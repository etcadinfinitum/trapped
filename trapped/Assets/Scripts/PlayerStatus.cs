using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatus : MonoBehaviour
{

    //Player variables
    public float maxHealth = 100;
    public float health = 100;
    public bool isAlive = true;

    public GameObject healthbar;

    //Health bar UI elements
    public Slider mySlider;

    VisionBehavior playerVision;
    PopupManager announcer = null;

    /*
     * Condition: A positive or negative affliction given to player that has a continuous effect until its duration is 0 or it is cured
     * Stored in List "conditions" and effects are calculated also in the PlayerStatus script
     * 
     * Methods:
     * public Condition( string newName, float newDuration) | Constructor
     * Update() | Reduce condition duration continuously
     * increaseTime(int newTime) | increase the time of the duration
     * decreaseTime(int newTime) | decrease the time of the duration
     * cure() | Destroy a condition
     * 
     */
    public class Condition : Component
    {
        public string conditionName = "Default";
        public float duration = 1;

        //List of all conditions we want to support (2 for example) to avoid problems
        private List<string> supportedConditions = new List<string> { "slowed", "poisoned" };


        public Condition(string newName, float newDuration)
        {
            if (supportedConditions.Contains(newName))
            {
                Debug.Log("Condition " + newName + " given to player for " + newDuration + " seconds.");
                conditionName = newName;
                duration = newDuration;
            }
            else
            {
                Debug.LogError("Error: Unsupported condition was attempted");
                Destroy(this.gameObject);
            }
        }


        //increase the time of a condition
        public void increaseTime(float newTime)
        {
            duration += newTime;
        }

        //decrease the time of a condition
        public void reduceTime(float newTime)
        {
            duration -= newTime;
        }

        //destroy a condition
        public void cure()
        {
            //Debug.Log("Condition cured");
            Destroy(this.gameObject);
        }
    }

    public List<Condition> conditions = new List<Condition>();

    void Start()
    {
        GameObject myHealthbar = Instantiate(healthbar);

        myHealthbar.transform.parent = GameObject.Find("PlayerCanvas").transform;

        mySlider = myHealthbar.GetComponent<Slider>();


        playerVision = GameObject.Find("Player").GetComponent<VisionBehavior>();
        announcer = GameObject.Find("GameAnnouncements").GetComponent<PopupManager>();

        string newName = ("Player" + gameObject.GetComponent<PlayerData>().GetPlayerNumber());

       if(gameObject.GetComponent<PlayerData>().GetName() == null || gameObject.GetComponent<PlayerData>().GetName() == "")
        {
            //Debug.Log("Player Name Error: " + GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().GetName());
            gameObject.GetComponent<PlayerData>().SetName(GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().GetName());
        }
        //Debug.Log(myHealthbar.transform.GetChild(3).name);
        TextMeshProUGUI test = myHealthbar.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        newName = gameObject.GetComponent<PlayerData>().GetName();
        //Debug.Log("SET NEW NAME TO " + gameObject.GetComponent<PlayerData>().GetName());
        test.SetText(newName);

        switch (gameObject.GetComponent<PlayerData>().GetPlayerNumber())
        {
            case 0:
                myHealthbar.transform.position = new Vector2(120, 555);
                break;
            default:
                Debug.Log("Oops");
                break;

        }
                
        
       
    }

    void Update()
    {
        checkConditions();
        checkStatus();

        mySlider.value = health;
    }

    //see supportedConditions list for more info on valid conditions in Condition class
    public void addCondition(string name, float duration)
    {
        Condition con = new Condition(name, duration);
        conditions.Add(con);
    }

    private void checkConditions()
    {
        foreach(Condition con in conditions)
        {
            if(con.conditionName == "poisoned")
            {
                Debug.Log("Poison working");
                subtractHealth(Time.deltaTime * 2); //may need to increase/decrease
            }
            if(con.conditionName == "slowed")
            {
                //implementation TBD
            }

            if(con.duration <= 0)
            {
                conditions.Remove(con);
                con.cure();
            }
            else
            {
                con.reduceTime(Time.deltaTime);
                Debug.Log(con.duration);
            }
        }
    }

    private void checkStatus()
    {

        //if dead, set health to 0 and remove all conditions
        if(health <= 0)
        {
            health = 0;
            foreach (Condition con in conditions)
            {
                con.cure();
            }
            isAlive = false;
        }

        if (health > maxHealth)
            health = maxHealth;
    }


    public void addHealth(float amount)
    {
        health += amount;
    }

    public void subtractHealth(float amount)
    {
        playerVision.SetCurrentRadius(-amount, maxHealth);
        playerVision.BlindTemporarily(amount * 2);
        announcer.createClientPopup("OUCH!", 1.5f);
        health -= amount;
    }

    public void setHealth(float amount)
    {
        health = amount;
    }

    public void kill()
    {
        setHealth(0f);
    }

    public void revive()
    {
        setHealth(100);
        isAlive = true;
    }
}
