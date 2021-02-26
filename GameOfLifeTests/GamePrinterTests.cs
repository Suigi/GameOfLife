using System;
using System.Text;
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

            result.Should().Be($"__{Environment.NewLine}__{Environment.NewLine}");
        }
    }

    public class GamePrinter
    {
        public string Print(Game game)
        {
            var builder = new StringBuilder();

            for (int row = 0; row < game.Rows; row++)
            {
                for (int column = 0; column < game.Columns; column++)
                {
                    builder.Append("_");
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}