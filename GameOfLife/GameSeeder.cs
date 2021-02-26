using System.Collections.Generic;

namespace GameOfLife
{
    public class GameSeeder
    {
        private readonly IEnumerator<double> randomEnumerator;
        private readonly double probability;
        
        public GameSeeder(IEnumerable<double> numbers, double probability)
        {
            this.probability = probability;
            randomEnumerator = numbers.GetEnumerator();
        }

        public Game Create(int rows, int columns)
        {
            var seed = new List<(int, int)>();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (IsNextAlive())
                    {
                        seed.Add((row,column));
                    }
                }
            }
            return new Game(rows, columns, seed.ToArray());
        }

        private bool IsNextAlive()
        {
            randomEnumerator.MoveNext();
            return randomEnumerator.Current > probability;
        }
    }
}