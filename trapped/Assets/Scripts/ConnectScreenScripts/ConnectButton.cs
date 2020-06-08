using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectButton : MonoBehaviour
{
    string ip;
    private string myName;
    private string gameCode;
    private Button newSessionButton;
    private Button currentSessionButton;
    private InputField joinCodeField;
    private InputField ipfield;
    private GlobalBehavior globalBehavior;

    void Start() {
        newSessionButton = GameObject.Find("NewSessionButton").GetComponent<Button>();
        currentSessionButton = GameObject.Find("CurrentSessionButton").GetComponent<Button>();
        joinCodeField = GameObject.Find("JoinCode").GetComponent<InputField>();
        ipfield = GameObject.Find("IPField").GetComponent<InputField>();
        globalBehavior = GameObject.Find("GlobalController").GetComponent<GlobalBehavior>();

        newSessionButton.onClick.AddListener(StartNewSession);
        currentSessionButton.onClick.AddListener(JoinExistingSession);
    }

    public void StartNewSession() {
        Debug.Log("Creating custom join code for new session.");
        gameCode = generateGameCode();
        Debug.Log("Set custom join code as " + gameCode);
        ConnectButtonClick();
    }

    public void JoinExistingSession() {
        Debug.Log("Attempting to parse existing session code.");
        if (joinCodeField.text != "") {
            Debug.Log("Setting user-supplied join code: " + joinCodeField.text);
            gameCode = joinCodeField.text.ToUpper();
            ConnectButtonClick();
        } else {
            Debug.LogError("No join code was available in the join code field! Bad!");
            // do not create default or do anything else.
        }
    }

    /**
     * Generic button click action; only game code setting matters 
     * for different buttons.
     */
    public void ConnectButtonClick() {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        ip = ipfield.text;
        if (ip != "")
        {
            globalBehavior.SetIP(ip);
        }

        globalBehavior.SetGameCode(gameCode);

        myName = GameObject.Find("SetNameText").GetComponent<Text>().text;
        GameObject.Find("SetNameText").name = "AltNameText";
        globalBehavior.SetName(myName);
        SceneManager.LoadScene(1);
    }

    string generateGameCode() {
        string s = "";
        for (int i = 0; i < 4; i++) {
            float flt = UnityEngine.Random.value;
            int shift = Convert.ToInt32(Mathf.Floor(25 * flt));
            char letter = Convert.ToChar(shift + 65);
            s = s + letter.ToString();  
        }
        return s;
    }
}
