using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewuiManager : MonoBehaviour {

    // CountDown =======================================================
    public GameObject countDownObject;
    private CountDown countDown;

    // Cards ===========================================================
    public GameObject cardHolderObject;
    private CardHolder cardHolder;

    // HealthBars ======================================================
    public GameObject playerHealthBarObject;
    private HealthBar playerHealthBar;
    public GameObject opponentHealthBarObject;
    private HealthBar opponentHealthBar;

    // Game Over =======================================================
    public GameObject gameOverPanelObject;
    private GameOverPanel gameOverPanel;

    // CoolDown ========================================================
    public GameObject coolDownObject;
    private CoolDownManager coolDownManager;

    // EnemyCard =======================================================
    public GameObject enemyCardObject;
    private EnemyCard enemyCard;
    // =================================================================

	void Start () {

        countDown = countDownObject.GetComponent<CountDown>();

        cardHolder = cardHolderObject.GetComponent<CardHolder>();

        playerHealthBar = playerHealthBarObject.GetComponent<HealthBar>();
        opponentHealthBar = opponentHealthBarObject.GetComponent<HealthBar>();

        coolDownManager = coolDownObject.GetComponent<CoolDownManager>();

        gameOverPanel = gameOverPanelObject.GetComponent<GameOverPanel>();

        enemyCard = enemyCardObject.GetComponent<EnemyCard>();
	}

    // CountDown =======================================================
    public bool TimerOver() { return countDown.TimerOver(); }
    //==================================================================

    // Cards ===========================================================
    public bool IsReleaseReady() { return cardHolder.IsReleaseReady(); }
    public void NewCardHolder() { cardHolder.NewCardHolder(); }
    public void LaunchAttack() { cardHolder.RemoveCardHolder(); }
    public void ReleaseAttack() { cardHolder.ReleaseCards(); }
    //==================================================================

    // HealthBars ======================================================
    public void UpdatePlayerHealthBar(int health) { playerHealthBar.UpdateHealthBar(health); }
    public void UpdateOpponentHealthBar(int health) { opponentHealthBar.UpdateHealthBar(health); }
    //==================================================================

    // Game Over =======================================================
    public void DisplayGameOver(string victory) { gameOverPanel.Init(victory); }
    //==================================================================

    // CoolDown ========================================================
    public void AddCoolDownBar(string tag, int strength) { coolDownManager.AddCoolDownBar(tag, strength); }
    //==================================================================

    // Player Names ====================================================
    public Text playerNameLabel;
    public Text playerNameWhiteLabel;
    public Text opponentNameLabel;
    public Text opponentNameWhiteLabel;

    public void InitPlayerNames(string playerName, string opponentName) 
    {
        playerNameLabel.text = playerName;
        playerNameWhiteLabel.text = playerName;
        opponentNameLabel.text = opponentName;
        opponentNameWhiteLabel.text = opponentName;
    }
    // =================================================================

    // Cancel Attack ===================================================
    public void CancelAttackAnim()
    {
        cardHolder.CancelAttack();
        enemyCard.Cancel();
    }
    // =================================================================

    // Enemy Attack ====================================================
    public void PlayEnemyAttackAnim(string input) { enemyCard.Launch(input); }
    public void ReleaseEnemyAttackAnim() { enemyCard.Release(); }
    public void InitOpponentCard() { enemyCard.Init(); }
    // =================================================================
}
