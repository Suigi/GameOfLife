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
            var seeder = new GameSeeder(
                RepeatingNumbers(0.01, 0.11, 0.21, 0.31, 0.41, 0.51, 0.61, 0.71, 0.81, 0.91),
                0.1
            );

            seeder.Create(3, 10).AliveCells.Should().BeEquivalentTo((0, 9), (1, 9), (2, 9));
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
}