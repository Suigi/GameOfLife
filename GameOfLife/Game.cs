using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private readonly (int row, int colum)[] aliveCells;

        public Game(int rows, int columns, params (int row, int colum)[] aliveCells)
        {
            this.aliveCells = aliveCells;
            Rows = rows;
            Columns = columns;
        }

        public int Rows { get; }

        public int Columns { get; }

        public IEnumerable<(int row, int column)> AliveCells => aliveCells;

        public bool IsCellAlive(int row, int column)
        {
            CheckBounds(row, column);

            return aliveCells.Contains((row, column));
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