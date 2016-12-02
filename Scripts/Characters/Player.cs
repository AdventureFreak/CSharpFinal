using System;
public class Player : Entity
{
    //constructor, asks the player for their name
    public Player() {
        GetName();
        baseHealth = 100;
        attack = 5;
        defence = 5;

    }

    //GetName method will loop until the player enters an acceptable name
    private void GetName() {
        //prompt for name
        Console.WriteLine("Welcome, adventurer.  Before you begin your quest, I must ask your name.\nWhat shall I call you?\n");
        name = Console.ReadLine();
        //make sure a name was entered               
        while(name == ""){
            Console.WriteLine("Everyone has a name.  You cannot remain anonymous in this story.\nWhat shall I call you?\n");
            name = Console.ReadLine();
        }
    }

    //LevelUp increases stats
}