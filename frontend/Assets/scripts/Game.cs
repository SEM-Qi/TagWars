using System.Collections;
using UnityEngine;

/* INFO */

public class Game : MonoBehaviour
{
    private static string state;
    private Player player1;
    private Player player2;

	public Game(Player player1, Player player2)
	{
        this.player1 = player1;
        this.player2 = player2;
        Debug.Log("NEW GAME: " + player1.GetName() + " VS. " + player2.GetName());
        state = "GAME_START";
	}

    private void Update()
    {
        if (state == "GAME_START")
        {

        }
        else if (state == "GAME")
        {
            // new InputListener();
            // if enter -> player1.Launch(new Attack(IL.GetTags()));
        }
        else if (state == "GAME_OVER")
        {

        }
        else
        {

        }
    }

    private void OnGUI()
    {

    }

    private void GameOver()
    {

    }
}
