using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoDieGameAssignment
{
    public class ThreeOrMore
    {
        private Random random;
        private List<int> dice;
        private int totalScore;
        private Statistics statistics;

        public ThreeOrMore(Statistics stats)
        {
            random = new Random();
            dice = new List<int>();
            totalScore = 0;
            statistics = stats;

            // Record the game play
            statistics.RecordGamePlay("Three or More");
        }

        public void Play()
        {
            Console.WriteLine("Playing Three or More...");

            try
            {
                while (totalScore < 20)
                {
                    RollDice(5);

                    Console.WriteLine("Your dice: " + string.Join(", ", dice));

                    var groupedDice = dice.GroupBy(x => x);
                    var maxCount = groupedDice.Max(g => g.Count());

                    if (maxCount >= 3) // Check for 3-of-a-kind or better
                    {
                        int points = CalculatePoints(maxCount);
                        totalScore += points;

                        Console.WriteLine($"Points: {points}");
                        Console.WriteLine($"Total score: {totalScore}");

                        // Update high score in statistics
                        statistics.RecordHighScore("Three or More", totalScore);
                    }
                    else
                    {
                        Console.Write("You didn't get 3-of-a-kind or better. Reroll all dice? (y/n): ");
                        string input = Console.ReadLine();

                        if (input?.ToLower() == "y")
                        {
                            dice.Clear();
                            continue;
                        }

                        Console.WriteLine("Game over. Final score: " + totalScore);
                        break;
                    }
                }

                Console.WriteLine("Congratulations! You reached 20 points.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public int GetTotalScore()
        {
            return totalScore;
        }

        private void RollDice(int count)
        {
            dice.Clear();

            for (int i = 0; i < count; i++)
            {
                dice.Add(random.Next(1, 7)); // Roll a die (1-6)
            }
        }

        private int CalculatePoints(int maxCount)
        {
            if (maxCount == 3)
                return 3; // 3-of-a-kind: 3 points
            else if (maxCount == 4)
                return 6; // 4-of-a-kind: 6 points
            else if (maxCount == 5)
                return 12; // 5-of-a-kind: 12 points

            return 0; // No valid points
        }
    }
}
