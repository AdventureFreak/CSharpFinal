public class Weapon : Item
{
    public Weapon(string nam, int pow, int res){
        name = nam;
        power = pow;
        resist = res;;
        stats = name + ": " + power + " base damage. Blocks " + resist + " damage.";
    }
    public override void SetName(string nam){
        name = nam;
        stats = name + ": " + power + " base damage. " + resist + " base damage block.";
    }
}