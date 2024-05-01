using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Die_Game_Assignment
{
    public class Die // My die class 
    {
        private Random random;

        public Die()
        {
            this.random = new Random();
        }

        public int Roll()
        {
            return this.random.Next(1, 7); // Rolls a random integer between 1 and 6 for the die
        }
    }
}
