using System;

namespace TwoDieGameAssignment
{
    public class Die
    {
        private Random random;

        public Die()
        {
            this.random = new Random();
        }

        public int Roll()
        {
            return this.random.Next(1, 7); // Rolls a random number between 1 and 6
        }
    }
}
