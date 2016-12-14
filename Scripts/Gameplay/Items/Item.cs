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

    //returns the stats of the items
    public string PrintStats(){
        return stats;
    }

    //virtual functions so the child can use them
    public virtual void SetName(string nam){
        //doesn't do anything
    }

    public virtual void AddDurability(int blah){
        //also doesn't do anythin
    }

    public virtual bool Use(){
        return true;
    }
}