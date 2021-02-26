using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void a_game_retains_its_size_in_rows_and_columns()
        {
            var game = new Game(2, 3);
            game.Rows.Should().Be(2);
            game.Columns.Should().Be(3);
        }

        [DataTestMethod]
        [DataRow(2, 1, "(2,1)", DisplayName = "row index equal to number of rows it not allowed")]
        [DataRow(1, 2, "(1,2)", DisplayName = "column index equal to number of columns it not allowed")]
        [DataRow(-1, 1, "(-1,1)", DisplayName = "negative row index is not allowed")]
        [DataRow(1, -1, "(1,-1)", DisplayName = "negative column index is not allowed")]
        public void cells_outside_of_the_bounds_of_the_game_cannot_be_accessed(int row, int column,
            string formattedIndex)
        {
            var game = new Game(2, 2);

            Action act = () => game.IsCellAlive(row, column);

            act.Should().Throw<IndexOutOfRangeException>().WithMessage($"Game index {formattedIndex} is out of bounds");
        }

        [TestMethod]
        public void a_new_game_has_dead_cells()
        {
            var newGame = new Game(10, 10);
            newGame.IsCellAlive(2, 2).Should().BeFalse();
        }

        [TestMethod]
        public void a_game_remembers_initially_active_cells()
        {
            var seededGame = new Game(10, 10, (2, 2));

            seededGame.IsCellAlive(2, 2).Should().BeTrue();
        }

        [TestMethod]
        public void single_alive_cell_is_dead_next_round()
        {
            var initialGame = new Game(10, 10, (2, 2));
            var updatedGame = initialGame.Next();
            updatedGame.IsCellAlive(2, 2).Should().BeFalse();
        }

        [TestMethod]
        public void alive_cell_with_two_neighbors_survives()
        {
            var initialGame = new Game(10, 10, (2, 2), (1, 2), (3, 2));
            var updatedGame = initialGame.Next();
            updatedGame.IsCellAlive(2, 2).Should().BeTrue();
        }
        
        [TestMethod]
        public void alive_cell_with_three_neighbors_survives()
        {
            var initialGame = new Game(10, 10, (2, 2), (1, 2), (3, 2), (2, 1));
            var updatedGame = initialGame.Next();
            updatedGame.IsCellAlive(2, 2).Should().BeTrue();
        }

        [TestMethod]
        public void dead_cell_with_three_alive_neighbors_becomes_alive()
        {
            var initialGame = new Game(10, 10, (1, 2), (3, 2), (2, 1));
            var updatedGame = initialGame.Next();
            updatedGame.IsCellAlive(2, 2).Should().BeTrue();
        }
    }

    public class Game
    {
        private readonly (int row, int colum)[] seed;

        public Game(int rows, int columns, params (int row, int colum)[] seed)
        {
            this.seed = seed;
            Rows = rows;
            Columns = columns;
        }

        public int Rows { get; }

        public int Columns { get; }

        public bool IsCellAlive(int row, int column)
        {
            CheckBounds(row, column);

            return seed.Contains((row, column));
        }

        private void CheckBounds(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new IndexOutOfRangeException($"Game index ({row},{column}) is out of bounds");
            }
        }

        public Game Next()
        {
            List<(int, int)> updatedState = new List<(int, int)>();
            foreach (var index in AllIndices())
            {
                var numberOfAliveNeighbors = NumberOfAliveNeighbors(index);
                if (numberOfAliveNeighbors == 3
                    || (numberOfAliveNeighbors == 2 && IsCellAlive(index.row, index.column)))
                {
                    updatedState.Add(index);
                }
            }

            return new Game(Rows, Columns, updatedState.ToArray());
        }

        private IEnumerable<(int row, int column)> AllIndices()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    yield return (row, column);
                }
            }
        }

        private int NumberOfAliveNeighbors((int row, int colum) index)
        {
            var numberOfAliveNeighbors = new IndexMechanics(Rows, Columns).Neighbors(index)
                .Count(n => IsCellAlive(n.row, n.column));
            return numberOfAliveNeighbors;
        }
    }
}