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
            var emptyGame = new Game(5,5);

            var result = printer.Print(emptyGame);

            AssertPrintout(result,
                @"
_____
_____
_____
_____
_____
"
            );
            result.Should().EndWith(Environment.NewLine);
        }

        [TestMethod]
        public void alive_cells_are_printed_with_an_x()
        {
            var printer = new GamePrinter();
            var emptyGame = new Game(5,5, (0,0),(1,1),(2,2),(3,3),(4,4));

            var result = printer.Print(emptyGame);

            AssertPrintout(result,
                @"
x____
_x___
__x__
___x_
____x
"
            );
        }

        private void AssertPrintout(string actual, string expected)
        {
            actual.Trim().Should().Be(expected.Trim());
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
                    if (game.IsCellAlive(row, column))
                    {
                        builder.Append('x');
                    }
                    else
                    {
                        builder.Append("_");
                    }
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}