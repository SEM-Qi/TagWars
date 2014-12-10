using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* The CardUI class handles the UI part of the card component */

public class CardUI : MonoBehaviour
{
    public Text label;

    // the animation label is required to display the text during the animation
    public Text animationLabel;
    
    public Image image;

    private Animator cardAnim;

    private Color validColor = new Color(0.61F, 0.80F, 0.40F);
    private Color failColor = new Color(0.90F, 0.29F, 0.10F);

    private Vector3 originalScale;

    void Start()
    {
        cardAnim = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    public void Launch()
    {
        animationLabel.text = label.text;
        cardAnim.SetTrigger("launch");
        cardAnim.ResetTrigger("release");
        cardAnim.ResetTrigger("cancel");
    }

    public void Resize(int damage)
    {
        float dimension = damage / 150f + 1;
        transform.localScale = new Vector3(dimension, dimension, 0);
    }

    public void ResetSize()
    {
        transform.localScale = originalScale;
    }

    public void Release()
    {
        ResetSize();
        cardAnim.SetTrigger("release");
        cardAnim.ResetTrigger("cancel");
        cardAnim.ResetTrigger("launch");
    }

    public void Cancel()
    {
        animationLabel.text = "";
        label.text = "";
        cardAnim.SetTrigger("cancel");
        cardAnim.ResetTrigger("release");
        cardAnim.ResetTrigger("launch");
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
