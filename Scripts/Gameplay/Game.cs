using System;
using System.Collections.Generic;
public class Game
{
    //initial gam setup
    //makes the game sequence, and prepares everything so it all works

    //random numbers
    static Random rand = new Random();
    //game sequence
    //list holds the setting objects to create the game events from
    List<Setting> sequence = new List<Setting>();

    void FillList (){
        //create an array of settings
        //each element in the array is a unique setting
        //array holds all possible combinations I want each setting to have
        Setting[] SettingTypes = new Setting[7];
        int duration = rand.Next(3,6);
        while (duration > 0)
        {
            int num
            sequence.Add();
        }
    }
}