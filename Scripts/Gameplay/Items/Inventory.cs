using System;
using System.Collections.Generic;
public class Inventory
{
    int size = 3;
    public List<Item> inventory = new List<Item>();

    //initiates the inventory
    public Inventory(){
        inventory.Add(new Weapon(Words.GetWeapon(), 1, 10));
        inventory.Add(new Healing("Food", 6));
    }

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
                thing.SetName(Rename(thing, inventory));
                inventory.Add(thing);
                Console.WriteLine("\n" + thing.name + " was added to the inventory.\n");
            }else{
                //no space...
                ReplaceItem(thing);
            }
        }else if(ItemValid(thing.name.ToLower(), inventory)){
            //if the item is a healing item
            //run a for loop to check the name of all items in inventory
            for (int i = 0; i < inventory.Count; i++){
                if(inventory[i].name == thing.name){
                    inventory[i].AddDurability(thing.durability);
                    Console.WriteLine("\n" + thing.name + " now has " + inventory[i].durability + " uses left.\n");
                }
            }
        }else{
            if (inventory.Count < size) {
                //add if there is space
                inventory.Add(thing);
                Console.WriteLine("\n" + thing.name + " was added to the inventory.\n");
            }else{
                //no space...
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
            choice = Words.Read();
        }
        //do things based on choice
        //if yes, ask what item the player would like to replace and do so
        if(choice.ToLower() == "yes"){
            Console.WriteLine("Which item will be discarded?\n\nThe inventory consists of:\n" + ReadList(inventory) + "Cancel.\n");

            //new choice search to see if the entered option is a valid item
            string newChoice = Words.Read();
            while (!ItemValid(newChoice.ToLower(), inventory) && newChoice.ToLower() != "cancel"){
                    Console.WriteLine("Which item will be discarded?\n\nThe inventory consists of:\n" + ReadList(inventory) + "Cancel.\n");
                    newChoice = Words.Read();
            }
            //if cancel is not selected
            if(newChoice.ToLower() != "cancel"){
                //holds the index to replace
                int index = GetIndex(thing.name.ToLower(), inventory);

                //make sure the name isn't taken
                thing.SetName(Rename(thing, inventory));
                //tell the player what they have done, so they can think about it
                Console.WriteLine(inventory[index].name + " has been replaced with a " + thing.name + ".\n");
                //swap them
                ItemSwap(thing, index);
            }else{
                Console.WriteLine(thing.name + " was left behind.\n");
            }
        }else{
        //if no, we are done
        Console.WriteLine(thing.name + " was left behind.\n");
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
    static bool ItemValid(string test, List<Item> stuff){

        //list of strings
        //will hold all item names
        List<string> names = new List<string>();

        //add names of inventory over
        foreach(Item thing in stuff){
            names.Add(thing.name.ToLower());
        }

        //test is choice entered matches an item name
        return names.Contains(test);
    }

    //adds the item into the inventory while making sure the names don't stack
    string Rename(Item thing, List<Item> stuff){

        //run a check on item names
        string newName = thing.name;
        bool nameFree = true;
        foreach(Item things in stuff){
            if(thing.name == things.name){
                nameFree = false;
            }   
        }

        //change name of item if it's not free
        if(!nameFree){
            newName += nameAdd++;
        }
        return newName;
    }

    //find the index of an item with a matching name
    int GetIndex(string name, List<Item> stuff){
        int index = -1;

        //get index number of item with matching name
        for (int i = 0; i < stuff.Count; i++){
            if(stuff[i].name.ToLower() == name){
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
    public void GetNewItem(int number, Player me){
        List<Item> newItems = new List<Item>();
        bool healing = true;
        //make a new list of all choices
        for(int i = number; i > 0; i--){
            //randomly decide if the item is a healing item or a weapon
            int choice = rand.Next(100);         
            if(choice > 80 && healing){
                newItems.Add(new Healing(Words.GetHealing(), rand.Next(3,6)));
                healing = false;
            }else{
                int lowerBound = me.baseHealth / 10;
                int upperBound = me.baseHealth / 6;
                Weapon weap = new Weapon(Words.GetWeapon(), rand.Next(1,me.attack/2), rand.Next(lowerBound, upperBound));
                weap.SetName(Rename(weap, newItems));
                newItems.Add(weap);
            }
        }

        //let the player pick an item to add
        //make sure its a valid choice
        string choiceString = "nada";
        while(!ItemValid(choiceString.ToLower(), newItems) && choiceString.ToLower() != "nothing"){
            Console.WriteLine(me.name + " has found loot!\nWhich item should " + me.name + " take?\n\n" + ReadList(newItems) + "Nothing\n");
            choiceString = Words.Read();
        }

        if(choiceString != "nothing"){
            //if it was a valid choice
            //get the item from the temporary list
            int indexItem = GetIndex(choiceString.ToLower(), newItems);
            Item thing = newItems[indexItem];
            //add the item to the inventory
            AddItem(thing);
        }else{
            //player decided not to take anything
            Console.WriteLine(me.name + " decided not to take anything.\n");
        }      
    }

    //function to write out the inventory outside of the inventory class
    public string PrintInventory(){
        return "\n" + ReadList(inventory);
    }

    //function to use and item, returns -2 if the item is invalid for the requested action. -1 is used for cancel.
    public int UseItem(string act){
        int ret = -2;
        int index;

        //uses a variation of some code from the replace item function
        Console.WriteLine("Which item will be used?\n\n" + ReadList(inventory) + "Cancel.\n");

        //make sure the player has chosen an item the actually exsists
        string choice = Words.Read();
        while (!ItemValid(choice.ToLower(), inventory) && choice.ToLower() != "cancel"){
                Console.WriteLine("Which item will be used?\n\n" + ReadList(inventory) + "Cancel.\n");
                choice = Words.Read();
        }
        //if cancel is not selected
        if(choice.ToLower() != "cancel"){
            //holds the index o the item
            index = GetIndex(choice.ToLower(), inventory);

            switch(act){
                //a weapon can attack
                case "attack":
                        if(inventory[index].GetType() == typeof(Weapon)){
                            ret = inventory[index].power;
                        }
                    break;
                //a weapon can defend        
                case "defend":
                        if(inventory[index].GetType() == typeof(Weapon)){
                            ret = inventory[index].resist;
                        }
                    break;
                //healing items restore health
                default:
                        if(inventory[index].GetType() == typeof(Healing)){
                            ret = inventory[index].power;
                            //use the item and delete it if it has no uses left
                            if(!inventory[index].Use()){
                                inventory.RemoveAt(index);
                            }
                        }
                    break;
            }
        }else{
            ret = -1;
        }
        return ret;
    }
}