using System.Collections;
using UnityEngine;

/* The PLAYER class contains all values regarding a player */

public class Player
{
    private int health = 100;
    private string name = "";

    private string attack = "";

    public Player(string name, int health)
    {
        this.name = name;
        this.health = health;
    }

    public void UpdateHealth(int damage)
    {
        health = health - damage;
    }

    // Getters & Setters
    public string GetName() { return name; }

    public void SetName(string name) { this.name = name; }

    public int GetHealth() { return health; }

    public void SetHealth(int health) { this.health = health; }

    public string GetAttack() { return attack; }

    public void SetAttack(string attack) { this.attack = attack; }
}
