using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* The InputFieldPanel controls the input field in the Prefab it is located
 * Reseting the triggers is not necessary but a good safety mesure */

public class InputFieldPanel : MonoBehaviour
{
    public GameObject inputField;
    public Text inputFieldLabel;

    // the animation label is required to display the text during the animation
    public Text animationLabel;
	private Randomizer randomizer;
    private Animator inputFieldAnim;

    // preset colors for input
    private Color validColor = new Color(0.09F, 0.62F, 0.51F);
    private Color failColor = new Color(0.75F, 0.22F, 0.17F);
    private Color standartColor = Color.black;

    void Start()
    {
        inputFieldAnim = GetComponent<Animator>();
        //inputFieldLabel.text = "#";
		inputFieldAnim = GetComponent<Animator>();
		randomizer = GetComponent<Randomizer>();
    }

    // player inputfield -----------------------------------------------
    public void NewInputField()
    {
        inputField.SetActive(true);
        inputFieldAnim.SetTrigger("Ready");
        inputFieldAnim.ResetTrigger("Charge");
    }

    public void RemoveInputField() { inputField.SetActive(false); }

    public void UpdateInput(string input) 
    {
        if (input == "")
        {
            inputFieldLabel.text = "#";
            ResetInputColor();
        }
        else
        {
            inputFieldLabel.text = input;
        }
    }

    // cancel attack ----------------------------------------------------
    public void CancelAttack()
    {
        //inputFieldAnim.ResetTrigger("Release");
        //inputFieldAnim.ResetTrigger("EnemyRelease");
        inputFieldAnim.SetTrigger("Cancel");
    }

    // player attack ----------------------------------------------------
    public void NewAttack()
    {
        animationLabel.text = inputFieldLabel.text;
        inputFieldAnim.ResetTrigger("Release");
        inputFieldAnim.ResetTrigger("Cancel");
        inputFieldAnim.SetTrigger("Charge");
    }

    public void ReleaseAttack() { inputFieldAnim.SetTrigger("Release"); }

    // enemy attack ----------------------------------------------------
    public void NewEnemyAttack(string input)
	{   // displays the inputfield and charges it
		//animationLabel.text = input;
		randomizer.Randomize (input);
		//randomizer.SetInputReady (true);
		inputFieldAnim.ResetTrigger("EnemyRelease");
		inputFieldAnim.ResetTrigger("Cancel");
		inputFieldAnim.SetTrigger("EnemyCharge");

    }

    public void ReleaseEnemyAttack()
    {
        inputFieldAnim.ResetTrigger("EnemyCharge");
        inputFieldAnim.SetTrigger("EnemyRelease");
    }

    // set color of player input -----------------------------------------
    public void SetInputColorFail() { inputFieldLabel.color = failColor; }

    public void SetInputColorValid() { inputFieldLabel.color = validColor; }

    public void ResetInputColor() { inputFieldLabel.color = standartColor; }
}
