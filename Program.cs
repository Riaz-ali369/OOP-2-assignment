using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Die_Game_Assignment; // imports the namespace to access the classes we made

class Program // main program 
{
    static void Main(string[] args)
    {
        Game game = new Game(); // This creates a new Game object
        game.ShowMenu(); // Displays the game menu

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); // lets user press a key to exit the terminal 
    }
}
