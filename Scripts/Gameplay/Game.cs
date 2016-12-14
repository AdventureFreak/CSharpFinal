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
        for (int i = 0; i < settingTypes.Capacity; i++){
            bool enemies = false;
            bool boss = false;
            bool loot = false;
            int chance = rand.Next(100);
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
            settingTypes[i] = new Setting(enemies, boss, loot, chance);
        }

        //determine how many locations to play through and add them from the array into the list
        int duration = rand.Next(4,7);
        while (duration > 0)
        {
            //pick a random item from the possible settings list
            int num = rand.Next(settingTypes.Count);
            //add it to the sequence
            sequence.Add(settingTypes[num]);
            //remove the item added from the possible settings list
            settingTypes.RemoveAt(num);
        }
    }

    public void Start(Player player, Inventory inv){
        int 
        
    }

    //make the right events happen for the given setting
    public void RunSequence(){

    }
}