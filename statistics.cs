using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Die_Game_Assignment
{
    public class Statistics
    {
        private Dictionary<string, int> gamePlays; // dictionary stores which game and how many times playes 
        private Dictionary<string, int> highScores; // dictionary stores which game and the highest score 

        public Statistics()
        {
            gamePlays = new Dictionary<string, int>(); // Initalises both dictionaries 
            highScores = new Dictionary<string, int>();
        }

        public void RecordGamePlay(string gameType) // Records each time game is played 
        {
            if (!gamePlays.ContainsKey(gameType))
            {
                gamePlays[gameType] = 0; // if its not already in the dictionary starts at 0
            }

            gamePlays[gameType]++; // increments by 1 
        }

        public void RecordHighScore(string gameType, int score) // records the high score for the games 
        {
            if (!highScores.ContainsKey(gameType))
            {
                highScores[gameType] = score; // if its not already in dictionary starts at 0
            }
            else if (score > highScores[gameType])
            {
                highScores[gameType] = score; // updates the high score if the current score is higher 
            }
        }

        public void Display() // this displays the currenlty recorded statistics 
        {
            Console.WriteLine("Statistics:");
            foreach (var kvp in gamePlays)
            {
                Console.WriteLine($"- {kvp.Key}: Number of Plays: {kvp.Value}, High Score: {highScores[kvp.Key]}");
            }
        }
    }
}
