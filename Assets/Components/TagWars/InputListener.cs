using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* The InputListener class checks for player input */

public class InputListener : MonoBehaviour
{
    // private QueryManager queryManager;
    public GameObject cardHolderObject;
    private CardHolder cardHolder;

    // private List<string> tags = new List<string>();
    private List<char> input = new List<char>();

    private char[] forbidenChars = { ' ', '#', '!', '?', '$', '%', '^', '&', '*', '+', '.' };
    private static string inputText = "";      // curent input

    private static bool listen = false; 

    void Start()
    {
        cardHolder = cardHolderObject.GetComponent<CardHolder>();
    }

    // Input Loop -----------------------------
    void Update()
    {
        if (cardHolder.IsReleaseOver())
        {
            input.Clear();
            inputText = "";
            
        }
        if (listen)
        {
            foreach (char c in Input.inputString)
            {   // if the char is valid
                if (Array.IndexOf(forbidenChars, c) < 0)
                {                     
                    if (c == "\b"[0] && input.Count > 0)
                    {   // backspace  
                        input.RemoveAt(input.Count - 1);
                    }
                    else if (input.Count < 20 && c != "\b"[0] && c != "\n"[0] && c != "\r"[0])
                    {   // if the players input is shorter then 20 and he doesn't inputs 'enter' or 'space'
                        input.Add(c);
                    }
                }
            }

            // builds the string & updates the inputfield
            inputText = MakeString(input).ToLower();
            cardHolder.UpdateCard(inputText);
        }
    }

    public void ResetInput()
    {
        input.Clear();
        inputText = "";
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

    // Getters & Setters ----------------------------
    public static string GetInput() { return inputText; }
    public static void Listen(bool b) { listen = b; }
}
