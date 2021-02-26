using System;
using System.Collections.Generic;

namespace GameOfLife.HorribleOutsideWorld
{
    public class RandomNumbers
    {
        public static IEnumerable<double> FromSeed(int seed)
        {
            var random = new Random(seed);
            while (true)
            {
                yield return random.NextDouble();
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}