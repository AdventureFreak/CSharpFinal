using System;

namespace ConsoleApplication
{
    public class Program
    {   
        public static Game game = new Game();
        public static Inventory inv = new Inventory();  
        public static void Main(string[] args)
        {
            Player player = new Player();
            Console.WriteLine("\n" + player.name + "\n");
            game.SetStage(player);
            Console.WriteLine("\n" + player.name + "\n");
            inv.AddItem(new Item());
        }
    }
}
