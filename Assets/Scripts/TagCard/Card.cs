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

    private Color validColor = new Color(0.09F, 0.62F, 0.51F);
    private Color failColor = new Color(0.75F, 0.22F, 0.17F);

    void Start()
    {
        cardAnim = GetComponent<Animator>();
    }

    public void Init()
    {

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
}
