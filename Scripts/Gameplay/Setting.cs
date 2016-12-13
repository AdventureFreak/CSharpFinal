public class Setting
{
    //different aspects each location can have
    public bool enemies;
    public bool boss;
    public bool treasure;
    //this will make something random happen
    public int chance;

    //constructor sets the parameters
    public Setting(bool bad, bool fight, bool amount, int random) {
        enemies = bad;
        boss = fight;
        treasure = amount;
        chance = random;
    }
}