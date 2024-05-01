using System;

namespace TwoDieGameAssignment
{
    public class Game
    {
        private SevensOut sevensOutGame;
        private ThreeOrMore threeOrMoreGame;
        private Statistics statistics;

        public Game()
        {
            sevensOutGame = new SevensOut();
            threeOrMoreGame = new ThreeOrMore();
            statistics = new Statistics();
        }

        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Game Menu!");
                Console.WriteLine("1. Play Sevens Out");
                Console.WriteLine("2. Play Three or More");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Run Tests");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        statistics.RecordGamePlayed("Sevens Out");
                        sevensOutGame.Play();
                        break;
                    case "2":
                        statistics.RecordGamePlayed("Three or More");
                        threeOrMoreGame.Play();
                        break;
                    case "3":
                        statistics.Display();
                        break;
                    case "4":
                        Testing.Run();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); // Add a blank line for readability
            }
        }
    }
}
