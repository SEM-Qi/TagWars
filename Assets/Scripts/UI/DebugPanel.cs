using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* INFO */

public class DebugPanel : MonoBehaviour
{
    // UI Elements
    public Button startButton;
    public Button exitButton;
    public Button newServerButton;
    public Button joinServerButton;
    public Button enemyAttackButton;
    public Button gameOverButton;
    public Button launchAttack; 
    public GameObject debugPanel;

    private bool debugMode = false;
    //private NetworkManager nm;
    
    public void Init()
    {
        debugMode = true;
        //nm = GetComponent<NetworkManager>();

        // add ActionListeners
        startButton.onClick.AddListener(() => { Debug.Log("START"); Application.LoadLevel("MainMenu"); });
        exitButton.onClick.AddListener(() => Debug.Log("EXIT"));
        //newServerButton.onClick.AddListener(() => { Debug.Log("CREATE_SERVER"); nm.LaunchServer(); });
        //joinServerButton.onClick.AddListener(() => { Debug.Log("JOIN_SERVER"); });
        enemyAttackButton.onClick.AddListener(() => Debug.Log("ENEMY_ATTACK"));
        //gameOverButton.onClick.AddListener(() => { Debug.Log("GAME_OVER"); Game.state = "GAME_OVER"; });
        launchAttack.onClick.AddListener(() => Debug.Log("ATTACK_LAUNCHED"));
    }

    void Update()
    {
        if (debugMode == true)
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (debugPanel.activeSelf && Input.GetKeyDown("escape"))
        {
            debugPanel.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown("escape"))
            {
                debugPanel.SetActive(true);
            }
        }
    }
}


//private NetworkManager nm;

//void Start()
//{
//    nm = GetComponent<NetworkManager>();
//}

//void OnGUI()
//{
//    if (!Network.isClient && !Network.isServer)
//    {
//        if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
//            nm.LaunchServer();

//        if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
//            nm.RefreshHostList();

//        if (nm.hostList != null)
//        {
//            for (int i = 0; i < nm.hostList.Length; i++)
//            {
//                if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), nm.hostList[i].gameName))
//                    nm.JoinServer(nm.hostList[i]);
//            }
//        }
//    }
//}