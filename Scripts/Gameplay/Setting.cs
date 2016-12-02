public class Setting
{
    //different aspects each location can have
    public int enemies;
    public bool boss;
    public int treasure;
    public int chance;

    //constructor sets the parameters
    public Setting(int bad, bool fight, int amount, int random) {
        enemies = bad;
        boss = fight;
        treasure = amount;
        chance = random;
    }
}