using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {
    public GameObject gameOverPanel;
    public Button mainMenu;
    public Text gameOverLabel;

	public void Init () {
        gameOverPanel.SetActive(true);
        gameOverLabel.text = "#Victory";
        mainMenu.onClick.AddListener(() => { Debug.Log("MAIN_MENU"); Exit(); Application.LoadLevel("MainMenu"); });
	}

    public void Exit()
    {
        gameOverPanel.SetActive(false);
    }
}
