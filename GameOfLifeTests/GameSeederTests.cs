using System;
using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameSeederTests
    {
        [TestMethod]
        public void seeder_creates_a_new_game()
        {
            var seeder = new GameSeeder(RepeatingNumbers(0, 1), 0.5);
            seeder.Create(5, 5).Should().BeOfType<Game>();
        }

        [TestMethod]
        public void random_function_is_used_for_initially_alive_cells()
        {
            var seeder = new GameSeeder(RepeatingNumbers(0, 1), 0.5);
            seeder.Create(2, 2).AliveCells.Should().BeEquivalentTo((0, 1), (1, 1));
        }

        private static IEnumerable<double> RepeatingNumbers(params double[] numbers)
        {
            while (true)
            {
                foreach (var number in numbers)
                {
                    yield return number;
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }

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