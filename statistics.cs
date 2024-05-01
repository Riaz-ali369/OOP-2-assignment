using System;
using System.Collections.Generic;

namespace TwoDieGameAssignment
{
    public class Statistics
    {
        private Dictionary<string, int> gamePlays;
        private Dictionary<string, int> highScores;

        public Statistics()
        {
            gamePlays = new Dictionary<string, int>();
            highScores = new Dictionary<string, int>();
        }

        public void RecordGamePlay(string gameType)
        {
            if (!gamePlays.ContainsKey(gameType))
            {
                gamePlays[gameType] = 0;
            }

            gamePlays[gameType]++;
        }

        public void RecordHighScore(string gameType, int score)
        {
            if (!highScores.ContainsKey(gameType))
            {
                highScores[gameType] = score;
            }
            else if (score > highScores[gameType])
            {
                highScores[gameType] = score;
            }
        }

        public void Display()
        {
            Console.WriteLine("Statistics:");
            foreach (var kvp in gamePlays)
            {
                Console.WriteLine($"- {kvp.Key}: Number of Plays: {kvp.Value}, High Score: {highScores[kvp.Key]}");
            }
        }
    }
}
