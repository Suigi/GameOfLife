using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void a_new_game_has_dead_cells()
        {
            var newGame = new Game(10, 10);
            newGame.IsCellAlive(2, 2).Should().BeFalse();
        }

        [TestMethod]
        public void a_game_retains_its_size_in_rows_and_columns()
        {
            var game = new Game(2, 3);
            game.Rows.Should().Be(2);
            game.Columns.Should().Be(3);
        }

    }

    public class Game
    {
        public Game(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public int Rows { get; }

        public int Columns { get; }

        public bool IsCellAlive(int i, int i1)
        {
            return false;
        }
    }
}