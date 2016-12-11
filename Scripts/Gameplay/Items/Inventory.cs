using System;
using System.Collections.Generic;
public class Inventory
{
    int size = 0;
    public List<Item> inventory = new List<Item>();

    //adds this to the name of an item if it is already in your inventory
    int nameAdd = 1;

    Random rand = new Random();

    //function to add items into inventory
    //parameters: item to add
    public void AddItem(Item thing){
        //if the item being added is not a healing item
        if (thing.GetType()!=typeof(Healing)){
            //add item if inventory has space
            if (inventory.Count < size) {
                thing.name = Rename(thing);
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
            Console.WriteLine("\nThe inventory is full. Should an item be discarded to make room?\nYes or No\n");
            choice = Console.ReadLine();
        }
        //do things based on choice
        //if yes, ask what item the player would like to replace and do so
        if(choice.ToLower() == "yes"){
            Console.WriteLine("\nWhich item will be discarded?\n\nThe inventory consists of:\n" + ReadList(inventory) + "Cancel\n");

            //new choice search to see if the entered option is a valid item
            string newChoice = Console.ReadLine();
            while (!ItemValid(newChoice.ToLower(), inventory) && newChoice.ToLower() != "cancel"){
                    Console.WriteLine("\nWhich item will be discarded?\n\nThe inventory consists of:\n" + ReadList(inventory) + "Cancel\n");
                    newChoice = Console.ReadLine();
            }
            //if cancel is not selected
            if(newChoice.ToLower() != "cancel"){
                //holds the index to replace
                int index = GetIndex(thing.name);

                //make sure the name isn't taken
                thing.name = Rename(thing);
                //tell the player what they have done, so they can think about it
                Console.WriteLine("\n" + inventory[index].name + " has been replaced with a " + thing.name);
                //swap them
                ItemSwap(thing, index);
            }else{
                Console.WriteLine(thing.name + " was left behind.");
            }
        }else{
        //if no, we are done
        Console.WriteLine(thing.name + " was left behind.");
        }
    }

    //builds a visual representation of the inventory
    string ReadList(List<Item> stuff){
        string writeOut = "";
        foreach(Item thing in stuff){
            writeOut += thing.PrintStats() + "\n";
        }
        return writeOut;
    }

    //check to see if a item name is within the item list
    bool ItemValid(string test, List<Item> stuff){
        //list of strings
        //will hold all item names
        List<string> names = new List<string>();

        //add names of inventory over
        foreach(Item thing in stuff){
            names.Add(thing.name.ToLower());
        }

        //test is choice entered matches an item name
        if(names.Contains(test)){
            return true;
        }else{
            return false;
        }
    }

    //adds the item into the inventory while making sure the names don't stack
    string Rename(Item thing){
        //run a check on item names
        string newName = thing.name;
        bool nameFree = true;
        foreach(Item things in inventory){
            if(thing.name == things.name){
                nameFree = false;
            }   
        }
        //change name of item if it's not free
        if(!nameFree){
            thing.name = thing.name + nameAdd++.ToString();
        }
        return newName;
    }

    //find the index of an item with a matching name
    int GetIndex(string name){
        int index = -1;

        //get index number of item with matching name
        for (int i = 0; i < inventory.Count; i++){
            if(inventory[i].name == name){
                index = i;
            }
        }
        return index;
    }

    //the actual replacement of an item
    void ItemSwap(Item thing, int index){
        inventory.RemoveAt(index);
        inventory.Insert(index, thing);
    }

    //call this to add an item into your inventory\
    //the number of items to choose from can be determined, and items are randomly created
    public Item GetNewItem(int number, Player me){
        List<Item> newItems = new List<Item>();

        //make a new list of all choices
        for(int i = number; i > 0; i--){
            //randomly decide if the item is a healing item or a weapon
            int choice = rand.Next(100);
            if(choice > 80){
                newItems.Add(new Healing(Words.GetHealing(), rand.Next(3,6)));
            }else{
                newItems.Add(new Weapon(Words.GetWeapon(), rand.Next(1,me.attack/2), rand.Next(1,(me.defence/4)+1)));
            }
        }

        //let the player pick an item to add
        //make sure its a valid choice
        string choiceString = "nada";
        while(!ItemValid(choiceString.ToLower(), inventory) && choiceString.ToLower() != "nothing"){
            Console.WriteLine(me.name + " has found loot!\nWhich item should " + me.name + " take?\n" + ReadList(newItems) + "Nothing\n");
            choiceString = Console.ReadLine();
        }

        
        
    }
}