using UnityEngine;
using System.Collections;

public class Randomizer : MonoBehaviour {
	
	private string originalText;
	private string randomizedText;

	private bool attackReady;    // is it ready to listen for input

	// Use this for initialization
	void Start () {
		attackReady = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackReady) {
			randomizedText = "randomized";
		}
	
	}
	public bool GetInputReady() { return attackReady; }
	public void SetInputReady(bool inputState) { this.attackReady = inputState; }
	public void SetOriginalText(string input) { this.originalText = input;}
	public void Revert() { this.randomizedText = this.originalText; }
	public string GetText() { return this.randomizedText; }
}
