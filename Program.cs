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

            //tester
            Console.WriteLine("Inventory contains:\n" +inv.PrintInventory());
            inv.GetNewItem(3,player);

            Console.WriteLine("Inventory contains:\n" +inv.PrintInventory());
            inv.GetNewItem(4,player);

            Console.WriteLine("Inventory contains:\n" +inv.PrintInventory());
            inv.GetNewItem(5,player);

            Console.WriteLine("Inventory contains:\n" +inv.PrintInventory());
        }
    }
}
