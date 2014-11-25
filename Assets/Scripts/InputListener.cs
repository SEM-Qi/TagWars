using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* The InputListener class checks for player input */

public class InputListener : MonoBehaviour
{
    private UIManager uiManager;
    private QueryManager queryManager;

    // private List<string> tags = new List<string>();
    private List<char> input = new List<char>();

    private List<string> usedTags = new List<string>();

    private char[] forbidenChars = { ' ', '#', '!', '?', '$', '%', '^', '&', '*', '+', '.' };
    private string inputText;           // curent input
    private bool inputReady = false;    // is it ready to listen for input
    private bool isValid = false;       // is the current input valid

    void Start()
    {
        uiManager = GetComponent<UIManager>();
        queryManager = GetComponent<QueryManager>();
    }

    // Input Loop -----------------------------
    void Update()
    {
        if (inputReady)
        {
            if (input.Count == 0) input.Add('#');

            foreach (char c in Input.inputString)
            {   // if the char is valid
                if (Array.IndexOf(forbidenChars, c) < 0)
                {                     
                    if (c == "\b"[0] && input.Count > 1)
                    {   // backspace  
                        input.RemoveAt(input.Count - 1);
                    }
                    else if (input.Count < 20 && c != "\b"[0] && c != "\n"[0] && c != "\r"[0])
                    {   // if the players input is shorter then 20 and he doesn't inputs 'enter' or 'space'
                        input.Add(c);
                    }

                    // builds the string & updates the inputfield
                    inputText = MakeString(input);
                    IsValid(inputText);
                    uiManager.UpdateInputField(inputText);
                }
            }
        }
    }

    // Helper Methods ----------------------------
    // checks validity & update the input field Text & color
    public void IsValid(string input)
    {
        if (input.Length > 1)
        {
            if (queryManager.GetValidTags().Contains(input.Substring(1))
                && !usedTags.Contains(input))
            {   // valid 
                uiManager.SetInputColorValid();
                usedTags.Add(input);
                isValid = true;
            }
            else
            {   // not valid
                uiManager.SetInputColorFail();
                isValid = false;
            }
        }
        else
        {   // just '#'
            uiManager.ResetInputColor();
            isValid = false;
        }
    }

    public void ResetInput()
    {
        input.Clear();
        inputText = "";
        uiManager.ResetInputColor();
        uiManager.UpdateInputField("#");
    }

    //  -----------------------------
    private static string MakeString(List<char> a)
    {
        string[] stringArray = new string[a.Count];

        for (int i = 0; i < a.Count; i++)
        {
            stringArray[i] = a[i].ToString();
        }
        return string.Join("", stringArray);
    }

    private static string MakeString(int[] a)
    {
        string[] stringArray = new string[a.Length];

        for (int i = 0; i < a.Length; i++)
        {
            stringArray[i] = a[i].ToString();
        }
        return string.Join(",", stringArray);
    }

    // Getters & Setters ----------------------------
    public string GetInput() { return inputText; }

    public bool GetInputReady() { return inputReady; }

    public void SetInputReady(bool inputState) { this.inputReady = inputState; }

    public bool IsValid() { return isValid; }
}
