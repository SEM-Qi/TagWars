using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour
{
    public Text label;

    // the animation label is required to display the text during the animation
    public Text animationLabel;
    
    public Image image;

    private Animator cardAnim;

    private Color validColor = new Color(0.61F, 0.80F, 0.40F);
    private Color failColor = new Color(0.90F, 0.29F, 0.10F);

    public GameObject scripts;
    private Game game;

    private bool resetReady;

    void Start()
    {
        game = scripts.GetComponent<Game>(); // Gotta fix that!
        cardAnim = GetComponent<Animator>();
    }

    public void Init()
    {
        resetReady = false;
    }

    public void Launch()
    {
        animationLabel.text = label.text;
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

    public void AfterRelease()
    {
        resetReady = true;
        game.AfterRelease();
    }

    public void UpdateText(string input, bool valid)
    {
        label.text = input;

        if (input.Length > 0)
        {
            if (valid)
            {
                label.color = validColor;
                image.color = validColor;
            }
            else
            {
                label.color = failColor;
                image.color = failColor;
            }
        }
        else
        {
            image.color = Color.black;
        }
    }

    public bool IsResetReady()
    {
        return resetReady;
    }
}
