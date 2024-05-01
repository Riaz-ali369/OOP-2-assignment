using System;
using System.Diagnostics;

namespace TwoDieGameAssignment
{
    public class Testing
    {
        private Statistics statistics;

        public Testing(Statistics stats)
        {
            statistics = stats;
        }

        public void RunTests()
        {
            // Create a new Game object
            Game game = new Game();

            // Test Sevens Out game
            TestSevensOut(game);

            // Test Three or More game
            TestThreeOrMore(game);

            Console.WriteLine("All tests completed.");
        }

        private void TestSevensOut(Game game)
        {
            Console.WriteLine("Testing Sevens Out...");

            SevensOut sevensOutGame = new SevensOut(statistics);

            // Run Sevens Out game with total of sum, stop if total = 7
            int totalScore = RunSevensOutGame(sevensOutGame);
            Debug.Assert(totalScore <= 7, "Sevens Out test failed: Total exceeded 7.");

            Console.WriteLine("Sevens Out test passed!");
        }

        private int RunSevensOutGame(SevensOut game)
        {
            game.Play();
            return game.GetTotalScore();
        }

        private void TestThreeOrMore(Game game)
        {
            Console.WriteLine("Testing Three or More...");

            ThreeOrMore threeOrMoreGame = new ThreeOrMore(statistics);

            // Run Three or More game and verify scores set and added correctly
            int totalScore = RunThreeOrMoreGame(threeOrMoreGame);
            Debug.Assert(totalScore >= 20, "Three or More test failed: Total score less than 20.");

            Console.WriteLine("Three or More test passed!");
        }

        private int RunThreeOrMoreGame(ThreeOrMore game)
        {
            game.Play();
            return game.GetTotalScore();
        }
    }
}
