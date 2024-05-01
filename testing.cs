using System;
using System.Diagnostics;

namespace TwoDieGameAssignment
{
    public static class Testing
    {
        public static void Run()
        {
            // Create a Game object
            Game game = new Game();

            // Test Sevens Out game logic
            TestSevensOut(game);

            // Test Three or More game logic
            TestThreeOrMore(game);
        }

        private static void TestSevensOut(Game game)
        {
            SevensOut sevensOut = new SevensOut();

            // Test Sevens Out game logic
            int totalSum = 0;
            while (totalSum != 7)
            {
                int result = sevensOut.RollDie();
                Debug.WriteLine($"Sevens Out: Rolled {result}");

                totalSum += result;
                Debug.WriteLine($"Sevens Out: Current Total Sum = {totalSum}");

                Debug.Assert(totalSum <= 7, "Sevens Out: Total sum should not exceed 7.");
            }

            Debug.WriteLine("Sevens Out: Game stopped because total sum reached 7.");
        }

        private static void TestThreeOrMore(Game game)
        {
            ThreeOrMore threeOrMore = new ThreeOrMore();

            // Test Three or More game logic
            int totalScore = 0;
            while (totalScore < 20)
            {
                List<int> diceValues = threeOrMore.RollDice(5);
                Debug.WriteLine($"Three or More: Rolled dice: {string.Join(", ", diceValues)}");

                totalScore += threeOrMore.CalculatePoints();
                Debug.WriteLine($"Three or More: Current Total Score = {totalScore}");

                Debug.Assert(totalScore >= diceValues.Sum(), "Three or More: Score should be added correctly.");

                if (totalScore >= 20)
                {
                    Debug.WriteLine("Three or More: Total score reached or exceeded 20.");
                }
            }
        }
    }
}
