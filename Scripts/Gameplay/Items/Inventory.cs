using System;
using System.Collections.Generic;
public class Inventory
{
    int size = 0;
    public List<Item> inventory = new List<Item>();

    //function to add items into inventory
    //parameters: item to add
    public void AddItem(Item thing){
        //if the item being added is not a healing item
        if (thing.GetType()!=typeof(Healing)){
            //add item if inventory has space
            if (inventory.Count < size) {
                inventory.Add(thing);
            }else{
                //no space...
                ReplaceItem(thing);
            }
        }else{
            //if the item is a healing item
            //run a for loop to check the name of all items in inventory
            //-1 is the result that no index in the list is the same as the item being added
            int id = -1;
            for (int i = 0; i < inventory.Count; i++){
                if(inventory[i].name == thing.name){
                    id = i;
                }
            }

            //see if there was already a healing item of the same type in your inventory
            if (id > 0)
            {
                inventory[id].durability += thing.durability;
            }else{
                ReplaceItem(thing);
            }
        }
    }
    void ReplaceItem(Item thing) {
        //state that there is no room and ask if player wants to get rid of anything
        string choice = "dogma";

        //run as long as player doesn't make a valid choice
        while (choice.ToLower() != "yes" && choice.ToLower() != "no"){
            Console.WriteLine("\nYou cannot hold any more items. Do you want to discard one of your items?\nYes or No\n");
            choice = Console.ReadLine();
        }
        //do things based on choice
        //if yes, ask what item the player would like to replace and do so
        if(choice.ToLower() == "yes"){
              Console.WriteLine("\nWhich item will you replace?" + ReadInv() + "Cancel\n");

              //new choice search to see if the entered option is a valid item
              string newChoice = Console.ReadLine();
              while (!ItemValid(newChoice.ToLower()) && newChoice.ToLower() != "cancel"){
                  Console.WriteLine("\nInvalid choice\nWhich item will you replace?");
                  newChoice = Console.ReadLine();
              }

              //if cancel is not selected
              //get index number of item with matching name
        }
        //if no, we are done
    }

    //builds a visual representation of the inventory
    string ReadInv(){
        string writeOut = "Your inventory consists of: \n";
        foreach(Item thing in inventory){
            writeOut += thing.PrintStats() + "\n";
        }
        return writeOut;
    }

    //check to see if a item name is within the item list
    bool ItemValid(string test){
        //list of strings
        //will hold all item names
        List<string> names = new List<string>();

        //add names of inventory over
        foreach(Item thing in inventory){
            names.Add(thing.name.ToLower());
        }

        //test is choice entered matches an item name
        if(names.Contains(test)){
            return true;
        }else{
            return false;
        }
    }
}