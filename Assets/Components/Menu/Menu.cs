using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* Menu Class:
 * the player can toggle this menu during the game */

public class Menu : MonoBehaviour
{
    public Button concedeButton;
    public GameObject menuPanel;

    private bool toggled;
    public bool concede { get; private set; }

    void Start()
    {
        concede = false;
        toggled = false;

        concedeButton.onClick.AddListener(() =>
        {
            Debug.Log("CONCEDE");
            concede = true;
        });
    }

    void Update()
    {
        if (Game.gameOver)
        {
            if (toggled)
            {
                toggled = false;
                menuPanel.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyUp("escape"))
            {
                if (!toggled)
                {
                    toggled = true;
                    menuPanel.SetActive(true);
                }
                else
                {
                    toggled = false;
                    menuPanel.SetActive(false);
                }
            }
        }
    }
}
