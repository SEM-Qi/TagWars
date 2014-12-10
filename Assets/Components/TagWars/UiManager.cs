using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiManager : MonoBehaviour {

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

    // TagCloud ========================================================
    public GameObject tagCloudObject;
    private TagCloud tagCloud;
    // =================================================================

	void Start () {

        countDown = countDownObject.GetComponent<CountDown>();

        cardHolder = cardHolderObject.GetComponent<CardHolder>();

        playerHealthBar = playerHealthBarObject.GetComponent<HealthBar>();
        opponentHealthBar = opponentHealthBarObject.GetComponent<HealthBar>();

        coolDownManager = coolDownObject.GetComponent<CoolDownManager>();

        gameOverPanel = gameOverPanelObject.GetComponent<GameOverPanel>();

        enemyCard = enemyCardObject.GetComponent<EnemyCard>();

        tagCloud = tagCloudObject.GetComponent<TagCloud>();
	}

    // CountDown =======================================================
    public bool CountDown() { return !countDown.TimerOver(); }
    //==================================================================

    // Cards ===========================================================
    public bool IsReleaseReady() { return cardHolder.IsReleaseReady(); }
    public void ReleaseAttack() { cardHolder.ReleaseCards(); }
    public bool IsInputReady() { return cardHolder.IsInputReady(); }
    //==================================================================

    // HealthBars ======================================================
    public void UpdatePlayerHealthBar(int health) { playerHealthBar.UpdateHealthBar(health); }
    public void UpdateOpponentHealthBar(int health) { opponentHealthBar.UpdateHealthBar(health); }
    //==================================================================

    // Game Over =======================================================
    public void DisplayGameOver(string victory) { gameOverPanel.Init(victory); }
    public bool ExitGame() { return gameOverPanel.ExitGame(); }
    //==================================================================

    // CoolDown ========================================================
    public void AddCoolDownBar(string tag, int strength) { coolDownManager.AddCoolDownBar(tag, strength); }
    //==================================================================

    // Player Names ====================================================
    public Text playerNameLabel;
    public Text opponentNameLabel;

    public void InitPlayerNames(string playerName, string opponentName) 
    {
        playerNameLabel.text = playerName;
        opponentNameLabel.text = opponentName;
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

    // Tag Cloud =======================================================
    public void NewTagCloud() { tagCloud.Init(); }
    public void RemoveTagCloud() { tagCloud.Cancel(); }
    // =================================================================
}
