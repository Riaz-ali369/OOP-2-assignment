using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoDieGameAssignment
{
    public class ThreeOrMore
    {
        private Random random;
        private List<int> dice;

        public ThreeOrMore()
        {
            random = new Random();
            dice = new List<int>();
        }

        public void Play()
        {
            Console.WriteLine("Playing Three or More...");
            int totalScore = 0;

            while (totalScore < 20)
            {
                // Roll 5 dice
                RollDice(5);

                Console.WriteLine("Your dice: " + string.Join(", ", dice));

                // Calculate combination points
                int points = CalculatePoints();

                Console.WriteLine($"Points: {points}");

                // Add points to total score
                totalScore += points;

                Console.WriteLine($"Total score: {totalScore}");

                // Check if total score is 20 or more
                if (totalScore >= 20)
                {
                    Console.WriteLine("Congratulations! You reached 20 points.");
                    break;
                }

                // Ask if player wants to roll again
                Console.Write("Roll again? (y/n): ");
                string input = Console.ReadLine();

                if (input.ToLower() != "y")
                {
                    break;
                }

                dice.Clear(); // Clear dice for the next roll
            }

            Console.WriteLine($"Final score: {totalScore}");
        }

        public List<int> RollDice(int count)
        {
            dice.Clear();

            for (int i = 0; i < count; i++)
            {
                dice.Add(random.Next(1, 7)); // Roll a die (1-6) and add to list
            }

            return dice;
        }

        public int CalculatePoints()
        {
            var groupedDice = dice.GroupBy(x => x);
            int points = 0;

            foreach (var group in groupedDice)
            {
                if (group.Count() >= 3) // 3-of-a-kind or better
                {
                    if (group.Count() == 3)
                    {
                        points += 3; // 3-of-a-kind: 3 points
                    }
                    else if (group.Count() == 4)
                    {
                        points += 6; // 4-of-a-kind: 6 points
                    }
                    else if (group.Count() == 5)
                    {
                        points += 12; // 5-of-a-kind: 12 points
                    }

                    // Remove the used dice from the list
                    dice.RemoveAll(x => x == group.Key);
                }
            }

            return points;
        }
    }
}
