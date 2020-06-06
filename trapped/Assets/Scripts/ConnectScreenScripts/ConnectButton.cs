using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectButton : MonoBehaviour
{
    string ip;
    private string myName;
    public void ConnectButtonClick(InputField ipfield)
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        ip = ipfield.text;
        if (ip != "")
        {
            GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().SetIP(ip);
        }
        myName = GameObject.Find("SetNameText").GetComponent<Text>().text;
        GameObject.Find("SetNameText").name = "AltNameText";
        GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().SetName(myName);
        SceneManager.LoadScene(1);
    }
}
