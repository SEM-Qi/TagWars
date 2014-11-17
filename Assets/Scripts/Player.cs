using System.Collections;
using UnityEngine;

/* The PLAYER class contains all values regarding a player */

public class Player : MonoBehaviour
{
    private int health = 100;
    private string name = "none";
    // private int id = 0;

    public void Init(string name, int health)
    {
        this.name = name;
        this.health = health;
    }

    // Getters & Setters
    public string GetName() { return name; }

    public void SetName(string name) { this.name = name; }

    public int GetHealth() { return health; }

    public void SetHealth(int health) { this.health = health; }
}
