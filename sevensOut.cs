using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Die_Game_Assignment
{
    public class SevensOut
    {
        private Random random; // generates a random number for dice 
        private int totalScore;  // Players total score 
        private Statistics statistics; // Statistics object for recoding the game stats

        // constructor for the sevens out class
        public SevensOut(Statistics stats)
        {
            random = new Random(); // initialises these 2 
            totalScore = 0;
            statistics = stats; // store reference to statistics obj

            // Records the game play in statistics
            statistics.RecordGamePlay("Sevens Out");
        }

        public void Play()
        {
            Console.WriteLine("Playing Sevens Out...");

            try
            {
                while (true) // keeps playing until the game ends 
                {
                    int dice1 = RollDie(); // rolls both the die 
                    int dice2 = RollDie();
                    int total = dice1 + dice2; // gets the total of both 

                    Console.WriteLine($"You rolled: {dice1} and {dice2} (Total: {total})");

                    if (total == 7) // ends the game if you get a total of 7
                    {
                        Console.WriteLine("Oops! You rolled a 7. Game over.");
                        break;
                    }
                    else
                    {
                        if (dice1 == dice2) // if you get 2 repeat values then your points double 
                        {
                            totalScore += total * 2; 
                            Console.WriteLine($"Doubles! Adding {total * 2} to your score.");
                        }
                        else
                        {
                            totalScore += total; // add the dice values to total score normally 
                            Console.WriteLine($"Adding {total} to your score.");
                        }

                        Console.WriteLine($"Your total score: {totalScore}");
                    }
                }

                Console.WriteLine($"Final score: {totalScore}");

                // Updates the high score in statistics
                statistics.RecordHighScore("Sevens Out", totalScore);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        public int GetTotalScore() // this method retrieves total score 
        {
            return totalScore;
        }

        public int RollDie() // method for rolling the dice
        {
            return random.Next(1, 7); 
        }
    }
}
