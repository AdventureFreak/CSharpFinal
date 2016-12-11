using System;
//a class of string arrays
//is only a container to hold all string arrays for randomization
public static class Words
{
    //names of enemies
    static string[] enemyNames = {"Slime", "Troll", "Goblin", "Skeleton", "Ghost", "Golem", "Boar", "Spider", "Goul", "Bear"};
    //names of strong foes
    static string[] bossNames = {"Wyvern", "Wraith", "Giant", "Mage", "Automaton"};
    //names of the final trial
    static string[] finalBoss = {"Demon", "Dragon", "Colossus", "Lich", "Abomination"};
    //places you'll go
    static string[] locations = {"a cave", "a feild", "a forest", "a ravine", "some ancient ruins", "a graveyard", "a keep", "a mysterious tower", "a deserted town", "a river"};
    //things you'll see
    static string[] objects = {"a pile of bones", "debris", "ashes", "some old rusted weapons", "moss covered writing", "an abandoned camp", "a burnt out torch", "broken pottery"};
    //atmosphere!
    static string[] atmosphere = {"cold", "quiet", "eerie", "damp", "windy", "depressing", "dark"};
    //things to fight with
    static string[] weapons = {"Short Sword", "Broad Sword", "Knife", "Bow", "Mace", "Battle Axe"};
    //things to ease your pain
    static string[] healing = {"Potion", "Food", "Medicine"};
    //randomizer for words class
    static Random rand = new Random();

    //getters for random values
    //enemy names
    public static string GetEnemy(){
        return enemyNames[rand.Next(enemyNames.Length)];
    }

    //boss names
    public static string GetBoss(){
        return bossNames[rand.Next(bossNames.Length)];
    }

    //final boss names
    public static string GetFinal(){
        return finalBoss[rand.Next(finalBoss.Length)];
    }

    //locations
    public static string GetPlace(){
        return locations[rand.Next(locations.Length)];
    }
    
    //objects
    public static string GetThing(){
        return objects[rand.Next(objects.Length)];
    }

    //atmosphere
    public static string GetFeeling(){
        return atmosphere[rand.Next(atmosphere.Length)];
    }

    //weapon
    public static string GetWeapon(){
        return weapons[rand.Next(weapons.Length)];
    }

    //healing item
    public static string GetHealing(){
        return healing[rand.Next(healing.Length)];
    }

    //read from the console and add a new line
    public static string Read(){
        string response = Console.ReadLine();
        Console.WriteLine("-------------------------------------------------------------------");
        return response;
    }
}