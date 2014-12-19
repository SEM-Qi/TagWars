using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* CardHolder Class:
 * the cardholders spawns new cards and manages them */

public class CardHolder : MonoBehaviour {

    public GameObject cardObject;
    private Card card;
    private CardUI cardUI;

    public GameObject cardHolder;
    private Animator cardHolderAnim;

    private bool inputReady = false;
    private bool releaseReady = false;
    private bool releaseOver = true;
    
    void Start()
    {
        cardHolderAnim = GetComponent<Animator>();
        card = cardObject.GetComponent<Card>();
        cardUI = cardObject.GetComponent<CardUI>();
    }

    void Update()
    {   // if all card animations are over
        if (card.ReleaseOver())
        {
            releaseOver = true;
        }
        else
        {
            releaseOver = false;
        }
    }

    public void Init()
    {
        inputReady = true; // should happen after animation end
        releaseReady = false;
        cardHolder.SetActive(true);
        cardHolderAnim.ResetTrigger("removeCardHolder");
        cardHolderAnim.SetTrigger("newCardHolder");
        card.Init();
    }

    // updates the card and tells it if it is valid or not
    public void UpdateCard(string text)
    {
        releaseReady = QueryManager.IsValid(text) && !CoolDown.ContainsTag(text);
        cardUI.UpdateText(text, releaseReady);
    }

    public void LaunchCard(string name, int[] distribution)
    {
        inputReady = false;
        cardUI.Launch();
        card.Launch(name, distribution);
        cardHolderAnim.ResetTrigger("newCardHolder");
        cardHolderAnim.SetTrigger("removeCardHolder");
    }

    public void HandleAttack()
    {
        card.Attack();
    }

    public bool IsCanceled() { return card.IsCanceled(); }

    public int TotalDamage()
    {
        return card.GetDamage();
    }

    // Getters & Setters ======================================
    public bool IsInputReady() { return inputReady; }
    public bool IsReleaseReady() { return releaseReady; }
    public bool IsReleaseOver() { return releaseOver; }
    public string GetAttack() { return card.GetAttack(); }
    public string GetEnemyAttack() { return card.GetEnemyAttack(); }
    // ========================================================
}
