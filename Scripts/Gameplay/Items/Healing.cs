public class Healing : Item
{
    public Healing(string nam, int dur){
        name = nam;
        resist = 0;
        durability = dur;
        //set the strength of the healing item based on the name of the item
        switch (name)
        {
            case "Food":
                power = 20;
                break;

            case "Medicine":
                power = 30;
                break;

            default:
                power = 50;
                break;
        }

        stats = name + ": Heals " + power + "% total health. " + durability + " uses left.";
    }

    //changes the name
    public override void SetName(string nam){
        name = nam;

        //stats string must be remade
        stats = name + ": Heals " + power + "% total health. " + durability + " uses left.";
    }

    //adds durability to item
    public override void AddDurability(int num){
        durability += num;

        //stats string must be remade
        stats = name + ": Heals " + power + "% total health. " + durability + " uses left.";
    }
}