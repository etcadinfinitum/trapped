using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    //Player variables
    public float maxHealth = 100;
    public float health = 100;
    public bool isAlive = true;

    //Health bar UI elements
    public Slider mySlider;

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

        //List of all conditions we want to support (2 for example)
        private List<string> supportedConditions = new List<string> { "slowed", "poisoned" };


        public Condition(string newName, float newDuration)
        {
            if (supportedConditions.Contains("newName"))
            {
                conditionName = newName;
                duration = newDuration;
            }
            else
            {
                Debug.LogError("Error: Unsupported condition was attempted");
                Destroy(this.gameObject);
            }
        }

        //reduce time on condition and destroy if over
        void Update()
        {
            duration -= Time.deltaTime;

            if(duration <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        //increase the time of a condition
        public void increaseTime(int newTime)
        {
            duration += newTime;
        }

        //decrease the time of a condition
        public void reduceTime(int newTime)
        {
            duration -= newTime;
        }

        //destroy a condition
        public void cure()
        {
            Destroy(this.gameObject);
        }
    }

    public List<Condition> conditions = new List<Condition>();

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
                subtractHealth(Time.deltaTime / 5); //may need to increase/decrease
            }
            if(con.conditionName == "slowed")
            {
                //implementation TBD
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
}
