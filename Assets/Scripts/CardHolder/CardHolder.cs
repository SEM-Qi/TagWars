using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardHolder : MonoBehaviour {

    public GameObject cardHolder;
    private Animator cardHolderAnim;
    
    void Start()
    {
        cardHolderAnim = GetComponent<Animator>();
    }

    public void NewCardHolder()
    {
        cardHolder.SetActive(true);
        cardHolderAnim.SetTrigger("NewCardHolder");
    }

    public void RemoveCardHolder()
    {
        cardHolderAnim.SetTrigger("RemoveCardHolder");
    }

    public void NewCard()
    {

    }
}
