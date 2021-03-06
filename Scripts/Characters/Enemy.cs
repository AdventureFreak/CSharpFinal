using System;

class Enemy : Entity
{
    bool charge = false;
    Random rand = new Random();
    public Enemy(int hp, int atk, int def, string nam) {
        health = hp;
        attack = atk;
        defence = def;
        name = nam;
    }

    public int Fight(){
        //randomly determine what the enemy will do
        int chance = rand.Next(10);

        //enemy can charge or attack
        if(chance == 9 && !charge){
            //the enemy will charge and do more damage next turn
            charge = true;
            Console.WriteLine(name + " is charging its power.\n\n");
            return 0;
        }else{
            if(charge){
                Console.WriteLine(name + " attacks at full power!\n\n");
                charge = false;
                return attack * 2;
            }else{
                Console.WriteLine(name + " attacks!\n\n");
                return attack;
            }
        }
    }

    //damage the enemy and check if they are dead
    public bool Damage(int hurt){
        bool dead = false;
        //lower health
        health -= Math.Max(hurt - defence, 1);
        Console.WriteLine(name + " took " + Math.Max(hurt - defence, 1) + " damage.\n");
        //check if dead
        if(health < 1){
            dead = true;
        }
        return dead;
    }
}