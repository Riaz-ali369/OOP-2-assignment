using System;

namespace TwoDieGameAssignment
{
    public class Game
    {
        private Statistics statistics;
        private Testing testing;

        public Game()
        {
            statistics = new Statistics();
            testing = new Testing(statistics);
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
                Console.WriteLine("4. Perform Tests");
                Console.WriteLine("5. Exit");

                string choice = GetUserInput();

                switch (choice)
                {
                    case "1":
                        InstantiateSevensOut();
                        break;
                    case "2":
                        InstantiateThreeOrMore();
                        break;
                    case "3":
                        ViewStatistics();
                        break;
                    case "4":
                        PerformTests();
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

        private string GetUserInput()
        {
            Console.Write("Enter your choice (1-5): ");
            return Console.ReadLine()?.Trim();
        }

        private void InstantiateSevensOut()
        {
            Console.WriteLine("Instantiating Sevens Out game...");
            SevensOut sevensOutGame = new SevensOut(statistics);
            sevensOutGame.Play();
        }

        private void InstantiateThreeOrMore()
        {
            Console.WriteLine("Instantiating Three or More game...");
            ThreeOrMore threeOrMoreGame = new ThreeOrMore(statistics);
            threeOrMoreGame.Play();
        }

        private void ViewStatistics()
        {
            Console.WriteLine("Viewing Statistics...");
            statistics.Display();
        }

        private void PerformTests()
        {
            Console.WriteLine("Performing Tests...");
            testing.RunTests();
        }
    }
}
