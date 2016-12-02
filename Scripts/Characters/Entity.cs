//class for player and enemies
using System;
class Entity
{
    //stats each enemy and the player will share
    public string name;
    public int health;
    public int baseHealth;
    public int attack;
    public int defence;
    public int stealth;

    //function to see if the character has health left
    public bool HasHealth() {
        bool response = true;
        if (health <= 0){
            response = false;
        }
        return response;
    }
}