using System;

namespace TwoDieGameAssignment
{
    public class SevensOut
    {
        private Random random;
        private int totalScore;
        private Statistics statistics;

        public SevensOut(Statistics stats)
        {
            random = new Random();
            totalScore = 0;
            statistics = stats;

            // Record the game play
            statistics.RecordGamePlay("Sevens Out");
        }

        public void Play()
        {
            Console.WriteLine("Playing Sevens Out...");

            try
            {
                while (true)
                {
                    int dice1 = RollDie();
                    int dice2 = RollDie();
                    int total = dice1 + dice2;

                    Console.WriteLine($"You rolled: {dice1} and {dice2} (Total: {total})");

                    if (total == 7)
                    {
                        Console.WriteLine("Oops! You rolled a 7. Game over.");
                        break;
                    }
                    else
                    {
                        if (dice1 == dice2)
                        {
                            totalScore += total * 2; // Double the total for doubles
                            Console.WriteLine($"Doubles! Adding {total * 2} to your score.");
                        }
                        else
                        {
                            totalScore += total; // Add normal total to score
                            Console.WriteLine($"Adding {total} to your score.");
                        }

                        Console.WriteLine($"Your total score: {totalScore}");
                    }
                }

                Console.WriteLine($"Final score: {totalScore}");

                // Update high score in statistics
                statistics.RecordHighScore("Sevens Out", totalScore);
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

        private int RollDie()
        {
            return random.Next(1, 7); // Roll a die (1-6)
        }
    }
}
