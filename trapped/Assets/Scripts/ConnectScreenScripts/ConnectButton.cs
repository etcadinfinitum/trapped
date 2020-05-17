using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectButton : MonoBehaviour
{
    string ip;
    public void ConnectButtonClick(InputField ipfield)
    {
        ip = ipfield.text;
        if (ip != "")
        {
            GameObject.Find("GlobalController").GetComponent<GlobalBehavior>().SetIP(ip);

        }
        SceneManager.LoadScene(1);
    }
}
