using FluentAssertions;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GamePrinterTests
    {
        [TestMethod]
        public void print_empty_grid_for_empty_game()
        {
            var printer = new GamePrinter();
            var emptyGame = new Game(2,2);

            var result = printer.Print(emptyGame);

            result.Should().Be("__\n__\n__");
        }
    }

    public class GamePrinter
    {
        public string Print(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}