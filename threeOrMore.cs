using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Die_Game_Assignment
{
    public class ThreeOrMore
    {
        private Random random; // Generates random number for dice 
        private List<int> dice;  // List holds the dice values 
        private int totalScore;  // Total score in the game 
        private Statistics statistics;  // To track the game data 

        public ThreeOrMore(Statistics stats)
        {
            random = new Random();  // Initialises the random number 
            dice = new List<int>(); // Initalises the dice list 
            totalScore = 0;     // Initalises total score
            statistics = stats; // Assigns the statistics object 

            // Records the game play in statistics
            statistics.RecordGamePlay("Three or More");
        }

        public void Play()  // what happens when three or more is played
        {
            Console.WriteLine("Playing Three or More...");

            try
            {
                while (totalScore < 20) // loops until the score reaches 20 or higher 
                {
                    RollDice(5);

                    Console.WriteLine("Your dice: " + string.Join(", ", dice)); // Displays the dice 
                    // This grouped Dice finds the mode of a value 
                    var groupedDice = dice.GroupBy(x => x);
                    var maxCount = groupedDice.Max(g => g.Count());

                    if (maxCount >= 3) // Check for 3 of a kind or better
                    {
                        int points = CalculatePoints(maxCount); // calculates the points gained 
                        totalScore += points; // updates total score 

                        Console.WriteLine($"Points: {points}");
                        Console.WriteLine($"Total score: {totalScore}");

                        // Update high score in statistics
                        statistics.RecordHighScore("Three or More", totalScore);
                    }
                    else
                    {
                        Console.Write("You didn't get 3 of a kind or better. Reroll all dice? (y/n): ");
                        string input = Console.ReadLine(); // lets the player roll the dice again 

                        if (input?.ToLower() == "y")
                        {
                            dice.Clear(); // empties the list of dice values before rolling again
                            continue;  // next iteration is done 
                        }

                        Console.WriteLine("Game over. Final score: " + totalScore);
                        break;
                    }
                }
                // check if the score is at least 20 first
                if (totalScore >= 20)
                {
                    Console.WriteLine("Congratulations! You reached 20 points.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public int GetTotalScore()
        {
            return totalScore; // returns the current total score
        }

        private void RollDice(int count)
        {
            dice.Clear();  // Clears before rolling again 

            for (int i = 0; i < count; i++)
            {
                dice.Add(random.Next(1, 7)); // rolls the dice
            }
        }

        private int CalculatePoints(int maxCount) // Determines what gives what points
        {
            if (maxCount == 3)
                return 3; // 3 of a kind: 3 points
            else if (maxCount == 4)
                return 6; // 4 of a kind: 6 points
            else if (maxCount == 5)
                return 12; // 5 of a kind: 12 points

            return 0; // No valid points
        }
    }
}
