using System;
using System.Collections.Generic;

namespace TwoDieGameAssignment
{
    public class Statistics
    {
        private Dictionary<string, GameStats> gameStatistics;

        public Statistics()
        {
            gameStatistics = new Dictionary<string, GameStats>();
        }

        public void RecordGamePlayed(string gameType)
        {
            if (!gameStatistics.ContainsKey(gameType))
            {
                gameStatistics[gameType] = new GameStats();
            }

            gameStatistics[gameType].IncrementPlays();
        }

        public void RecordHighScore(string gameType, int score)
        {
            if (!gameStatistics.ContainsKey(gameType))
            {
                gameStatistics[gameType] = new GameStats();
            }

            gameStatistics[gameType].UpdateHighScore(score);
        }

        public void Display()
        {
            Console.WriteLine("Game Statistics:");
            foreach (var kvp in gameStatistics)
            {
                Console.WriteLine($"- {kvp.Key}:");
                Console.WriteLine($"  Number of Plays: {kvp.Value.Plays}");
                Console.WriteLine($"  Highest Score: {kvp.Value.HighScore}");
                Console.WriteLine(); // Add a blank line for readability
            }
        }
    }

    public class GameStats
    {
        public int Plays { get; private set; }
        public int HighScore { get; private set; }

        public GameStats()
        {
            Plays = 0;
            HighScore = 0;
        }

        public void IncrementPlays()
        {
            Plays++;
        }

        public void UpdateHighScore(int score)
        {
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }
}
