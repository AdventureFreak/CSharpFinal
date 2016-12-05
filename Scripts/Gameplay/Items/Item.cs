public class Item
{
    //name of item
    public string name;
    //string of all item stats
    public string stats;
    //power determines the strength of a weapon or the potency of a healing item
    public int power;
    //durability determines how many times the item can be used
    public int durability;
    //resist determines how effective the item is at blocking damage
    public int resist;

    //IsUsable function is used to see if the item has durability or uses left
    public bool IsUsable() {
        if (durability >= 1){
            return true;
        }else{
            return false;
        }
    }

    //returns the stats of the items
    public string PrintStats(){
        return stats;
    }
}