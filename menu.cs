using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Die_Game_Assignment
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

        public void ShowMenu() // user interface which will be in terminal 
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("______Welcome to the Game Menu!______"); // this and the following is the menu and different options
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
                        Console.WriteLine("Thank you for playing my game!");
                        break;
                    default:
                        Console.WriteLine("Incorrect. Please try again."); // error handling here
                        break;
                }

                Console.WriteLine(); // Add a blank line so its easier to read
            }
        }

        private string GetUserInput()
        {
            Console.Write("Enter your choice (1-5): ");
            return Console.ReadLine()?.Trim();
        }

        private void InstantiateSevensOut() // creates an instance of sevens out game if the player chooses this option from the menu 
        {
            Console.WriteLine("Starting up the sevens out game...");
            Console.WriteLine(); // easier to see and same for the other instances
            SevensOut sevensOutGame = new SevensOut(statistics);
            sevensOutGame.Play();
        }

        private void InstantiateThreeOrMore() // creates an instance of the three or more game when player picks this option in the menu 
        {
            Console.WriteLine("Starting up the three or more game...");
            Console.WriteLine();
            ThreeOrMore threeOrMoreGame = new ThreeOrMore(statistics);
            threeOrMoreGame.Play();
        }

        private void ViewStatistics() // when this option is picked it displays the game played, how many times its been played and the highest score in that game
        {
            Console.WriteLine("Viewing Statistics...");
            Console.WriteLine();
            statistics.Display();
        }

        private void PerformTests() // tests both games with debug.assert 
        {
            Console.WriteLine("Performing Tests...");
            Console.WriteLine();
            testing.RunTests();
        }
    }
}
