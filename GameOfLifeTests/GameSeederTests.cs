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
}