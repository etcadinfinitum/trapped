using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPrefab;

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
            if(announcements.Peek() == null)
            {
                announcements.Dequeue();
            }
            else if (announcements.Peek().GetComponent<TextAnnouncement>().isBroadcasting == false)
            {
                announcements.Peek().GetComponent<TextAnnouncement>().show();
            }
        }

    }

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
}
