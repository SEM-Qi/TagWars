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
    private Attack attack;

    private bool resetReady;

    private Vector3 originalScale;

    void Start()
    {
        game = scripts.GetComponent<Game>(); // Gotta fix that!
        attack = scripts.GetComponent<Attack>();

        cardAnim = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    public void Init()
    {
        resetReady = false;
    }

    public void Launch()
    {
        animationLabel.text = label.text;
        cardAnim.SetTrigger("launch");
        InvokeRepeating("Resize", 1, 1);
    }

    private void Resize()
    {
        float dimension = (attack.GetDamage() / 150f) + 1;
        Debug.Log(dimension);
        transform.localScale = new Vector3(dimension, dimension, 0);
    }

    public void Release()
    {
        CancelInvoke();
        ResetSize();
        cardAnim.SetTrigger("release");
    }

    public void ResetSize()
    {
        transform.localScale = originalScale;
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
