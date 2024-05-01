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

                    int points = CalculatePoints();
                    totalScore += points;

                    Console.WriteLine($"Points: {points}");
                    Console.WriteLine($"Total score: {totalScore}");

                    // Update high score in statistics
                    statistics.RecordHighScore("Three or More", totalScore);

                    if (totalScore >= 20)
                    {
                        Console.WriteLine("Congratulations! You reached 20 points.");
                        break;
                    }

                    Console.Write("Roll again? (y/n): ");
                    string input = Console.ReadLine();

                    if (input?.ToLower() != "y")
                    {
                        break;
                    }

                    dice.Clear();
                }

                Console.WriteLine($"Final score: {totalScore}");
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
                dice.Add(random.Next(1, 7));
            }
        }

        private int CalculatePoints()
        {
            var groupedDice = dice.GroupBy(x => x);
            int points = 0;

            foreach (var group in groupedDice)
            {
                if (group.Count() >= 3)
                {
                    if (group.Count() == 3)
                        points += 3;
                    else if (group.Count() == 4)
                        points += 6;
                    else if (group.Count() == 5)
                        points += 12;

                    dice.RemoveAll(x => x == group.Key);
                }
            }

            return points;
        }
    }
}
