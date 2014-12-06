using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Randomizer : MonoBehaviour {
	
	private string original = "";
	private string dots = "";
	public Text inputFieldLabel; 

    public void Randomize(string input)
    {
        original = input;
        dots = Dotifier(original);
        InvokeRepeating("ShowCharacter", 0, 0.5f);
    }

    public void StopRandomize()
    {
        CancelInvoke();
        inputFieldLabel.text = original;
    }
	
	public void ShowCharacter()
	{
		dots = Dotifier(original); // reset?
		char[] dotsArray = dots.ToCharArray();
		float probability = 0.2f;
		
		for (int i = 0; i < dots.Length; i++)
		{
			if (Random.Range(0f,1f) < probability)
			{
				dotsArray[i] = original[i];
			}
		}
		
		dots = new string(dotsArray);
		Debug.Log(dots);
		inputFieldLabel.text = dots;
	}
	
	public string Dotifier(string word)
	{
		string dots = "";
		for (int i = 0; i < word.Length; i++)
		{
			dots = dots + ".";
		}
		return dots;
	}
}
