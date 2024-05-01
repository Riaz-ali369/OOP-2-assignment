using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // imports the debug function

namespace Two_Die_Game_Assignment
{
    public class Testing
    {
        private Statistics statistics;

        // this is a constructor that initalises the testing class with the statistics onject 
        public Testing(Statistics stats)
        {
            statistics = stats;
        }

        public void RunTests() // this method runs all the tests 
        {
            // Creates a new Game object
            Game game = new Game();

            // Tests Sevens Out game
            TestSevensOut(game);

            // Tests Three or More game
            TestThreeOrMore(game);

            Console.WriteLine("All tests are completed.");
        }

        private void TestSevensOut(Game game) // method to test sevens out 
        {
            Console.WriteLine("Testing sevens out right now...");
            // below creates a seven out instance with provided statistics 
            SevensOut sevensOutGame = new SevensOut(statistics); 

            // Run sevens out game and checks what the outcome is 
            int scoreOutput = RunSevensOutGame(sevensOutGame);
            Debug.Assert(scoreOutput <= 7, "Sevens out test failed: Total exceeded 7.");

            Console.WriteLine("Sevens out test passed the test");
        }

        private int RunSevensOutGame(SevensOut game)
        {
            return game.RollDie();
        }

        // this tests three or more game 
        private void TestThreeOrMore(Game game)
        {
            Console.WriteLine("Testing Three or More right now...");
            // below creats an instance of the game 
            ThreeOrMore threeOrMoreGame = new ThreeOrMore(statistics);

            // checks the outcome of the game 
            int totalScore = RunThreeOrMoreGame(threeOrMoreGame);
                Debug.Assert(totalScore >= 20, "Three or more test failed: Total score less than 20.");

            Console.WriteLine("Three or More test passed!");
        }

        public int RunThreeOrMoreGame(ThreeOrMore game)
        {
            game.Play(); // simulates the game 
            return game.GetTotalScore(); // returns the total
        }
    }
}
