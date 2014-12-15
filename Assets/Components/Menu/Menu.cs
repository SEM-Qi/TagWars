using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{

    public Button concedeButton;
    public GameObject menuPanel;

    private bool toggled = false;
    private bool concede = false;

    void Start()
    {
        concede = false;
        concedeButton.onClick.AddListener(() =>
        {
            Debug.Log("CONCEDE");
            concede = true;
        });
    }

    void Update()
    {
        if (!Game.gameOver)
        {
            if (Input.GetKeyUp("escape") && !toggled)
            {
                toggled = true;
                menuPanel.SetActive(true);
            }
            else if (Input.GetKeyUp("escape") && toggled)
            {
                toggled = false;
                menuPanel.SetActive(false);
            }
        }
    }

    // Getters 
    public bool Concede()
    {
        return concede;
    }
}
