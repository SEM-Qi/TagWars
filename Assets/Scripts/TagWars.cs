using UnityEngine;
using System.Collections;

/* TagWars: MAIN CLASS */

public class TagWars : MonoBehaviour
{
    private Controller con;

    void Start()
    {
        // Initializing UI
        con = GetComponent<Controller>();

        //TODO: load player info
    }

    void Update()
    {   // if start game button is pressed
        if (con.StartNewGame() == true)
        {
            // TODO ADD CONNECTION CODE HERE
            Application.LoadLevel("Battle");
        }
    }
}
