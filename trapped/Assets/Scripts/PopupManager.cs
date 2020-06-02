using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPrefab;

    public GameObject snaredPrefab;
    public GameObject teleportPrefab;
    public GameObject poisonedPrefab;

    public Queue<GameObject> announcements = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            createPopup(GameObject.Find("Player").GetComponent<PlayerData>().GetPlayerName() + " requests assistance!", 1.5f);
        }

        if(announcements.Count > 0)
        {
            if (announcements.Peek() == null)
            {
                announcements.Dequeue();
            }
            else if (announcements.Peek().GetComponent<TextAnnouncement>().isBroadcasting == false)
            {
                //detect which effect
                if (announcements.Peek().gameObject.tag == "Tele Trap" || announcements.Peek().gameObject.tag == "Stun Trap" || announcements.Peek().gameObject.tag == "Poison Dart")
                {
                    //Debug.Log("Success");
                    announcements.Peek().GetComponent<TextAnnouncement>().showClient();
                }
                else
                {
                    announcements.Peek().GetComponent<TextAnnouncement>().show();
                }

            }
        }

    }

    //dont look beyond here, your eyes will burn. you have been warned

    public void createPopup(string text, float duration)
    {
        //idk why we need this, but it fixed a bug so it is the correct solution for sure
        GameObject newPopup = Instantiate(popupPrefab, gameObject.transform);
        announcements.Enqueue(newPopup);
        newPopup.GetComponent<TextAnnouncement>().setText(" ");
        newPopup.GetComponent<TextAnnouncement>().setDuration(0.03f);

        GameObject newPopup2 = Instantiate(popupPrefab,gameObject.transform);
        announcements.Enqueue(newPopup2);
        newPopup2.GetComponent<TextAnnouncement>().setText(text);
        newPopup2.GetComponent<TextAnnouncement>().setDuration(duration);


    }

    public void createClientPopup(string text, float duration)
    {
        //idk why we need this, but it fixed a bug so it is the correct solution for sure
        GameObject newPopup = Instantiate(popupPrefab, gameObject.transform);
        announcements.Enqueue(newPopup);
        newPopup.GetComponent<TextAnnouncement>().setText(" ");
        newPopup.GetComponent<TextAnnouncement>().setDuration(0.03f);

        GameObject newPopup2 = Instantiate(popupPrefab, gameObject.transform);
        announcements.Enqueue(newPopup2);
        newPopup2.GetComponent<TextAnnouncement>().setText(text);
        newPopup2.GetComponent<TextAnnouncement>().setDuration(duration);
    }

    public void playerTeleport(string text, float duration)
    {
        //idk why we need this, but it fixed a bug so it is the correct solution for sure
        GameObject newPopup = Instantiate(teleportPrefab, gameObject.transform);
        announcements.Enqueue(newPopup);
        newPopup.GetComponent<TextAnnouncement>().setText(" ");
        newPopup.GetComponent<TextAnnouncement>().setDuration(0.03f);

        GameObject newPopup2 = Instantiate(teleportPrefab, gameObject.transform);
        announcements.Enqueue(newPopup2);
        newPopup2.GetComponent<TextAnnouncement>().setText(text);
        newPopup2.GetComponent<TextAnnouncement>().setDuration(duration);
    }

    public void playerStun(string text, float duration)
    {
        //idk why we need this, but it fixed a bug so it is the correct solution for sure
        GameObject newPopup = Instantiate(snaredPrefab, gameObject.transform);
        announcements.Enqueue(newPopup);
        newPopup.GetComponent<TextAnnouncement>().setText(" ");
        newPopup.GetComponent<TextAnnouncement>().setDuration(0.03f);

        GameObject newPopup2 = Instantiate(snaredPrefab, gameObject.transform);
        announcements.Enqueue(newPopup2);
        newPopup2.GetComponent<TextAnnouncement>().setText(text);
        newPopup2.GetComponent<TextAnnouncement>().setDuration(duration);
    }

    public void playerPoison(string text, float duration)
    {
        //idk why we need this, but it fixed a bug so it is the correct solution for sure
        GameObject newPopup = Instantiate(poisonedPrefab, gameObject.transform);
        announcements.Enqueue(newPopup);
        newPopup.GetComponent<TextAnnouncement>().setText(" ");
        newPopup.GetComponent<TextAnnouncement>().setDuration(0.03f);

        GameObject newPopup2 = Instantiate(poisonedPrefab, gameObject.transform);
        announcements.Enqueue(newPopup2);
        newPopup2.GetComponent<TextAnnouncement>().setText(text);
        newPopup2.GetComponent<TextAnnouncement>().setDuration(duration);
    }

}
