using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
    
    public Button mainMenu;
    public GameObject panel;
    public Text panelLabel;

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

        mainMenu.onClick.AddListener(() => { Debug.Log("MAIN_MENU"); Exit(); Application.LoadLevel("MainMenu"); });
	}

    private void Exit()
    {
        panel.SetActive(false);
    }
}
