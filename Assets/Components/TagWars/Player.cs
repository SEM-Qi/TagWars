using System.Collections;
using UnityEngine;

/* Player Class:
 * contains all values regarding a player */

public class Player
{
    public int health { get; set; }
    public string name { get; set; }
    public string currentTag { get; set; }
    public string lastTag { get; set; }
    public int lastDamage { get; set; }

    public Player(string name, int health)
    {
        this.name = name;
        this.health = health;
        lastTag = "";
        lastDamage = 0;
    }

    public void UpdateHealth(int damage)
    {
        health = health - damage;
    }
}
