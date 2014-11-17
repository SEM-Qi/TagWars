using UnityEngine;
using System.Collections;

/* The UI Manager Class is a Facade for the UI elements.
   If you create a new Prefab add it to the UIManager. All
   access to the Prefab should happen only over the UIManager */

public class UIManager : MonoBehaviour
{
    // Prefabs containing UI scripts
    public GameObject gameOverPanelObject;
    private GameOverPanel gameOverPanel;

    public GameObject inputFieldObject;
    private InputFieldPanel inputFieldPanel;

    public GameObject enemyFieldObject;
    private InputFieldPanel enemyFieldPanel;

    public GameObject playerNameObject;
    private PlayerName playerName;

    public GameObject opponentNameObject;
    private PlayerName opponentName;

    public GameObject playerHealthBarObject;
    private HealthBar playerHealthBar;

    public GameObject opponentHealthBarObject;
    private HealthBar opponentHealthBar;
    // -------------------------------

    void Start()
    {   // Binds the Scripts
        // game over panel
        gameOverPanel = gameOverPanelObject.GetComponent<GameOverPanel>();

        // input fields
        inputFieldPanel = inputFieldObject.GetComponent<InputFieldPanel>();
        enemyFieldPanel = enemyFieldObject.GetComponent<InputFieldPanel>();

        // player names
        playerName = playerNameObject.GetComponent<PlayerName>();
        opponentName = opponentNameObject.GetComponent<PlayerName>();

        // player health
        playerHealthBar = playerHealthBarObject.GetComponent<HealthBar>();
        opponentHealthBar = opponentHealthBarObject.GetComponent<HealthBar>();
    }

    // Player Names =========================
    public void InitPlayerNames(string name1, string name2)
    {
        playerName.SetName(name1);
        opponentName.SetName(name2);
    }

    // Healthbars ===========================
    public void UpdatePlayerHealthBar(int health) { playerHealthBar.UpdateHealthBar(health); }

    public void UpdateOpponentHealthBar(int health) { opponentHealthBar.UpdateOpponentHealthBar(health); }

    // Game Over ============================
    public void DisplayGameOver() { gameOverPanel.Init(); }

    // InputField ===========================
    public void NewInputField() { inputFieldPanel.NewInputField(); }

    public void RemoveInputField() { inputFieldPanel.RemoveInputField(); }

    public void UpdateInputField(string input) { inputFieldPanel.UpdateInput(input); }

    // color --------------------------------
    public void SetInputColorValid() { inputFieldPanel.SetInputColorValid(); }

    public void SetInputColorFail() { inputFieldPanel.SetInputColorFail(); }

    public void ResetInputColor() { inputFieldPanel.ResetInputColor(); }

    // player attack ------------------------
    public void NewAttackAnim() { inputFieldPanel.NewAttack(); }

    public void ReleaseAttackAnim() { inputFieldPanel.ReleaseAttack(); }

    // enemy attack -------------------------
    public void PlayEnemyAttackAnim(string input) { enemyFieldPanel.NewEnemyAttack(input); }

    public void ReleaseEnemyAttackAnim() { enemyFieldPanel.ReleaseEnemyAttack(); }
    // -----------------------------------------
}

