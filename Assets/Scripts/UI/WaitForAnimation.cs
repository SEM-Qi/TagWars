using UnityEngine;
using System.Collections;

public class WaitForAnimation : MonoBehaviour {

    public GameObject scripts;
    private Game game;

    void Start()
    {
        game = scripts.GetComponent<Game>();
    }

    public void OnAnimationEnd()
    {
        game.OnAnimationEnd();
    }
}
