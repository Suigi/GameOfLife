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
            var seeder = new GameSeeder();
            seeder.Create().Should().BeOfType<Game>();
        }
    }

    public class GameSeeder
    {
        public Game Create()
        {
            throw new System.NotImplementedException();
        }
    }
}