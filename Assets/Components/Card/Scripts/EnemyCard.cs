using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCard : MonoBehaviour {

    // the animation label is required to display the text during the animation
    public Text animationLabel;

    public Image image;

    private Animator cardAnim;
    private Randomizer randomizer;

    void Start()
    {
        cardAnim = GetComponent<Animator>();
        randomizer = GetComponent<Randomizer>();
    }

    public void Init()
    {
       animationLabel.text = "";
       cardAnim.SetTrigger("init");
       cardAnim.ResetTrigger("launch");
       cardAnim.ResetTrigger("release");
       cardAnim.ResetTrigger("cancel");
    }

    public void Launch(string input)
    {
        randomizer.Randomize(input);
        cardAnim.SetTrigger("launch");
        cardAnim.ResetTrigger("release");
        cardAnim.ResetTrigger("cancel");
    }

    public void Release()
    {
        randomizer.StopRandomize();
       // cardAnim.SetTrigger("launch");  // just in case Launch didn't got triggered
        cardAnim.SetTrigger("release");
        cardAnim.ResetTrigger("cancel");
    }

    public void Cancel()
    {
        animationLabel.text = "";
        cardAnim.SetTrigger("cancel");
        cardAnim.ResetTrigger("launch");
        cardAnim.ResetTrigger("release");
    }
}
