using System;

namespace ConsoleApplication
{
    public class Program
    {   
        public static Game game = new Game();
        public static Inventory inv = new Inventory();  
        public static void Main(string[] args)
        {
            //instantiate the player
            Player player = new Player();

            game.Start(player, inv);
        }
    }
}
