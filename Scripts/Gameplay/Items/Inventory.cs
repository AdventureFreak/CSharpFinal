using System;
using System.Collections.Generic;
public class Inventory
{
    int size = 0;
    public List<Item> inventory = new List<Item>();

    //function to add items into inventory
    //parameters: item to add
    public void AddItem(Item thing){
        //add item if inventory has space
        if (inventory.Count < size) {
            inventory.Add(thing);
        }else{
            //no space...
            //state that there is no room and ask if player wants to get rid of anything
            string choice = "dogma";

            //run as long as player doesn't make a valid choice
            while (choice.ToLower() != "yes" && choice.ToLower() != "no"){
            Console.WriteLine("\nYou cannot hold any more items. Do you want to discard one of your items?\nYes or No");
            choice = Console.ReadLine();
            }
            //do things based on choice
            Console.WriteLine(choice);
            //if yes, ask what item the player would like to replace and do so
            //if no, we are done
        }
    }
}