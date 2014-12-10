using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
    
    public Button mainMenu;
    public GameObject panel;
    public Text panelLabel;

    private  bool exitGame;

    void Start()
    {
        exitGame = false;
    }

	public void Init (string condition) {
        panel.SetActive(true);

        if (condition == "victory")
        {
            panelLabel.text = "#Victory!";
        }
        else if(condition == "defeat")
        {
            panelLabel.text = "#Defeat!";
        }

        mainMenu.onClick.AddListener(() => { exitGame = true; });
	}

    public bool ExitGame() { return exitGame; }
}
