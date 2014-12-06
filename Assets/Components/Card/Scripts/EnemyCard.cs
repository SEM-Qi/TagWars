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
       cardAnim.SetTrigger("init");
    }

    public void Launch(string input)
    {
        randomizer.Randomize(input);
        cardAnim.SetTrigger("launch");
    }

    public void Release()
    {
        randomizer.StopRandomize();
        cardAnim.SetTrigger("release");
    }

    public void Cancel()
    {
        cardAnim.SetTrigger("cancel");
    }
}
