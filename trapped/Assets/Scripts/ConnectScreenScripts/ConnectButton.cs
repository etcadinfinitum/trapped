using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectButton : MonoBehaviour
{
    string ip;
    private string name;
    public void ConnectButtonClick(InputField ipfield)
    {
        ip = ipfield.text;
        if (ip != "")
        {
            name = GameObject.Find("SetNameText").GetComponent<Text>().text;
            GameObject.Find("SetNameText").name = "AltNameText";

            GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().SetIP(ip);
            GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().SetName(name);
            SceneManager.LoadScene(1);

        }
        else
        {
            Debug.Log("IP field is empty");
        }
    }
}
