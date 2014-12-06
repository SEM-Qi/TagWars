using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCard : MonoBehaviour {

    // the animation label is required to display the text during the animation
    public Text animationLabel;

    public Image image;

    private Animator cardAnim;

    void Start()
    {
        cardAnim = GetComponent<Animator>();
    }

    public void Init()
    {
       cardAnim.SetTrigger("init");
    }

    public void Launch(string input)
    {
        animationLabel.text = input;
        cardAnim.SetTrigger("launch");
    }

    public void Release()
    {
        cardAnim.SetTrigger("release");
    }

    public void Cancel()
    {
        cardAnim.SetTrigger("cancel");
    }
}
