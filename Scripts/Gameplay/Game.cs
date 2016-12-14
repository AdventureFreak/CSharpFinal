using System;
using System.Collections.Generic;
public class Game
{
    //initial game setup
    //makes the game sequence, and prepares everything so it all works

    //random numbers
    static Random rand = new Random();

    //game sequence
    //list holds the setting objects to create the game events from
    List<Setting> sequence = new List<Setting>();

    //object for random words

    //setstage will make the flavor text for each new setting
    public void SetStage(Player me) {
        Console.WriteLine(me.name + " comes to " + Words.GetPlace() + ".\nIt feels " + Words.GetFeeling() + " here.\n" + me.name + " looks around and sees " + Words.GetThing() + "." );
    }

    //FillList will fill the sequence with things that will happen in game
    public void FillList (){
        //create a list of all possible settings
        List<Setting> settingTypes = new List<Setting>(7);

        //loop to build settings
        for (int i = 0; i < settingTypes.Capacity - 1; i++){
            bool enemies = false;
            bool boss = false;
            bool loot = false;
            int chance = rand.Next(10);
            switch (i)
            {
                case 0:
                    enemies = true;
                    boss = true;
                    loot = true;
                    break;
                case 1:
                    boss = true;
                    loot = true;
                    break;
                case 2:
                    enemies = true;
                    loot = true;
                    break;
                case 3:
                    enemies = true;
                    boss = true;
                    break;
                case 4:
                    enemies = true;
                    break;
                case 5:
                    boss = true;
                    break;
                default:
                    loot = true;
                    break;
            }
            settingTypes.Add(new Setting(enemies, boss, loot, chance));
        }

        //determine how many locations to play through and add them from the array into the list
        int duration = rand.Next(4,7);
        while (duration > 0)
        {
            duration--;
            //pick a random item from the possible settings list
            int num = rand.Next(settingTypes.Count);
            //add it to the sequence
            sequence.Add(settingTypes[num]);
            //remove the item added from the possible settings list
            settingTypes.RemoveAt(num);
        }
    }

    public void Start(Player player, Inventory inv){
        FillList();
        while (sequence.Count > 0 && player.HasHealth()){
            RunSequence(player, inv);
        }
        if(player.HasHealth()){
            Console.WriteLine(player.name + " cames to their greatest challenge yet.\n");
            if(Fight(3,player,inv)){
                Console.WriteLine(player.name + " has conquered all the trials they have faced.\n" + player.name + " is a true adeventurer!");
            }
        }else{
                Console.WriteLine("\n\n\n\nYOU LOSE!!!!!!!!\n\n\n\n");
        }
    }

    //make the right events happen for the given setting
    public void RunSequence(Player player, Inventory inv){
        SetStage(player);
        //chance time
        //do something random to the player
        switch(sequence[0].chance){
            case 0:
                Console.WriteLine(player.name + " found something!\n");
                inv.GetNewItem(1,player);
                break;

            case 1:
                Console.WriteLine(player.name + " got hurt by a trap!\n");
                int dmg = rand.Next(5, 20);
                player.health -= dmg;
                Console.WriteLine(player.name + " took " + dmg + " damage from the trap.\n");
                break;

            case 2:
                Console.WriteLine(player.name + "'s health in a healing fountian!\n");
                player.health = player.baseHealth;
                break;

            case 3:
                Console.WriteLine(player.name + " was ambushed!\n");
                Fight(1, player, inv);
                break;

            case 4:
                Console.WriteLine("There is nothing of interest here.\n");
                break;

            case 5:
                Console.WriteLine(player.name + " is contemplating life.\n");
                break;

            case 6:
                Console.WriteLine(player.name + " can't decide what to eat for dinner.\n");
                break;

            case 7:
                Console.WriteLine("The air is stale.\n");
                break;

            case 8:
                Console.WriteLine("Looks like an adventurer was here.\n");
                break;

            case 9:
                Console.WriteLine(player.name + " is ready.\n");
                break;                
        }

        if(sequence[0].enemies == true && player.HasHealth()){
            if(Fight(1,player,inv)){
                Console.WriteLine(player.name + " feels stronger.");
            }
        }
        if(sequence[0].treasure == true && player.HasHealth()){
            inv.GetNewItem(5,player);
        }
        if(sequence[0].boss == true && player.HasHealth()){
            if(Fight(2,player,inv)){
                Console.WriteLine(player.name + " feels stronger.");
            }
        }
        sequence.RemoveAt(0);
    }

    //the battle sequence
    bool Fight(int type, Player player, Inventory inv){
        Enemy enemy;
        //creates an appropriate enemy, boss, or the final boss
        switch (type)
        {
            //standard enemy
            case 1:
                enemy = new Enemy(player.attack * 6, player.baseHealth / 15, 0, Words.GetEnemy());
                break;
            //boss
            case 2:
                enemy = new Enemy(player.attack * 12, player.baseHealth / 10, player.attack/3, Words.GetBoss());
                break;
            //final boss
            default:
                enemy = new Enemy(player.attack * 12, player.baseHealth / 8, player.attack, Words.GetFinal());
                break;
        }

        //start the battle
        Console.WriteLine(enemy.name + " stands in " + player.name + "'s way.");
        while(enemy.HasHealth() && player.HasHealth()){
            //set to false when player cancels their item selection, so they can do their turn over again
            bool enemyTurn = true;
            //the amount of damage the player will block
            int resist = 0;
            //do an action check
            Console.WriteLine("-------------------------------------------------------------------\n" + player.name + " has " + player.health + " health\n" + enemy.name + " has " + enemy.health + " health\n\nWhat will " + player.name + " do?\nAttack\nDefend\nHeal\n\n");
            string choice = Words.Read();

            //run as long as player doesn't make a valid choice
            while (choice.ToLower() != "attack" && choice.ToLower() != "defend" && choice.ToLower() != "heal"){
                Console.WriteLine("\nNow is not the time to be funny! " + player.name + "'s life is at stake.\n\nWhat will " + player.name + " do?\nAttack\nDefend\nHeal\n\n");
                choice = Words.Read();
            }

            switch (choice.ToLower())
            {  
                //player attacks
                case "attack":
                    int dmg = inv.UseItem("attack", player);
                    //item is a weapon
                    if(dmg > 0){
                        enemy.Damage(player.attack + dmg);
                        //player canelled their action
                    }else if(dmg == -1){
                        enemyTurn = false;
                        //player is dumb and tried to fight with food or something
                    }else {
                        Console.WriteLine("That isn't going to work.\n");
                    }
                    break;
                //player defends
                case "defend":
                    int block = inv.UseItem("defend", player);
                    //item is a weapon
                    if(block > 0){
                        resist = block;
                        //player canelled their action
                    }else if(block == -1){
                        enemyTurn = false;
                        //player is dumb and tried to defend with food or something
                    }else {
                        Console.WriteLine("That isn't going to work.\n");
                    }
                    break;
                //player heals
                default:
                    int heal = inv.UseItem("heal", player);
                    //item is a healing item
                    if(heal > 0){//heal the player
                        double gain = player.baseHealth * (System.Convert.ToDouble(heal) / 100);
                        Console.WriteLine(player.name + " healed " + System.Convert.ToInt32(gain) + " health.\n");
                        player.health = Math.Min(System.Convert.ToInt32(gain) + player.health, player.baseHealth);
                        //player canelled their action
                    }else if(heal == -1){
                        enemyTurn = false;
                        //player is dumb and tried to heal with a sword or something
                    }else {
                        Console.WriteLine("That isn't going to work.\n");
                    }
                    break;
            }

            //enemy's turn
            if(enemyTurn && enemy.HasHealth()){
                int dmg = enemy.Fight();
                if(dmg > 0){
                    Console.WriteLine(player.name + " took " + (Math.Max(1, dmg - resist)) + " damage.\n");
                    player.health -= Math.Max(1, dmg - resist);
                }else{
                    Console.WriteLine(player.name + " should prepare for the next attack.\n");
                }
            }
        }
        //player lost
        if(!player.HasHealth()){
            Console.WriteLine(player.name + " was defeated.\n\n");            
            return false;
        }else{
            if(type != 3){
                player.LevelUp();
            }
            Console.WriteLine(enemy.name + " was defeated.\n\n");
            return true;
        }
    }
}