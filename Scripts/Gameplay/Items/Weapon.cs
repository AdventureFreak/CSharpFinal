public class Weapon : Item
{
    public Weapon(){
        stats = name + ": " + power + " base damage. " + resist + " base damage block. " + durability + " uses left.";
    }
}