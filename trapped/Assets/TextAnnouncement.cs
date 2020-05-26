using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnnouncement : MonoBehaviour
{

    private float lifetime = 10f;
    private string myText = "";
    private string finishedText = "              ";

    private bool textFinished = false;

    private int counter = 0;

    public float textSpeed = 0.02f;

    public bool isBroadcasting = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = new Vector2(Screen.width/2, -100);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = myText;

        if(textFinished)
            lifetime -= Time.deltaTime;
        if (lifetime < 0)
            StartCoroutine("TextFade");
    }

    IEnumerator TextScroll()
    {
        while(myText.Length != finishedText.Length)
        {
            counter++;
            myText = finishedText.Substring(0, counter);
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        yield return null;
    }

    IEnumerator TextFade()
    {
        while (myText.Length != 0)
        {
            counter--;
            myText = finishedText.Substring(0, counter);
            yield return new WaitForSeconds(textSpeed);
        }
        Destroy(gameObject);
        yield return null;
    }


    public void setText(string text)
    {
        finishedText = text;


    }

    public void setDuration(float duration)
    {
        lifetime = duration;
    }

    public void show()
    {
        gameObject.transform.position = new Vector2(Screen.width / 2, 20);
        transform.position = new Vector2(Screen.width / 2, 20);
        isBroadcasting = true;
        StartCoroutine("TextScroll");
    }

}
