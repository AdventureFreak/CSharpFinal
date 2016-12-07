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
            int enemies = 0;
            bool boss = false;
            int loot = 0;
            int chance = rand.Next(100);
            switch (i)
            {
                case 0:
                    enemies = rand.Next(1,3);
                    boss = true;
                    loot = rand.Next(1,4);
                    break;
                case 1:
                    boss = true;
                    loot = rand.Next(1,4);
                    break;
                case 2:
                    enemies = rand.Next(1,3);
                    loot = rand.Next(1,4);
                    break;
                case 3:
                    enemies = rand.Next(1,3);
                    boss = true;
                    break;
                case 4:
                    enemies = rand.Next(1,3);
                    break;
                case 5:
                    boss = true;
                    break;
                default:
                    loot = rand.Next(1,4);
                    break;
            }
            settingTypes[i] = new Setting(enemies, boss, loot, chance);
        }

        //determine how many locations to play through and add them from the array into the list
        int duration = rand.Next(4,7);
        while (duration > 0)
        {
            //pick a radnom item from the possible settings list
            int num = rand.Next(settingTypes.Count);
            //add it to the sequence
            sequence.Add(settingTypes[num]);
            //remove the item added from the possible settings list
            settingTypes.RemoveAt(num);
        }
    }

    public void Start(){
        
    }
}