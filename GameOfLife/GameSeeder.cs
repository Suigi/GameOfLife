using System.Collections.Generic;
using System.Linq;

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
            var aliveCells = new IndexMechanics(rows, columns).AllIndices()
                .Where(_ => IsNextAlive())
                .ToArray();
            return new Game(rows, columns, aliveCells);
        }

        private bool IsNextAlive()
        {
            randomEnumerator.MoveNext();
            return randomEnumerator.Current > probability;
        }
    }
}