using TwoDieGameAssignment;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(); // Create a new Game object
        game.ShowMenu(); // Display the game menu

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
