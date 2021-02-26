using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private readonly (int row, int colum)[] aliveCells;
        private readonly IndexMechanics indexMechanics;

        public Game(int rows, int columns, params (int row, int colum)[] aliveCells)
        {
            this.aliveCells = aliveCells;
            Rows = rows;
            Columns = columns;
            indexMechanics = new IndexMechanics(Rows, Columns);
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
             foreach (var index in indexMechanics.AllIndices())
             {
                 if (IsCellAliveInNextIteration(index))
                 {
                     updatedState.Add(index);
                 }
             }
            
             return new Game(Rows, Columns, updatedState.ToArray());
        }

        private bool IsCellAliveInNextIteration((int row, int column) index)
        {
            var numberOfAliveNeighbors = NumberOfAliveNeighbors(index);
            var isCellAlive = numberOfAliveNeighbors == 3
                || (numberOfAliveNeighbors == 2 && IsCellAlive(index.row, index.column));
            return isCellAlive;
        }

        private int NumberOfAliveNeighbors((int row, int colum) index)
        {
            var numberOfAliveNeighbors = indexMechanics.Neighbors(index)
                .Count(n => IsCellAlive(n.row, n.column));
            return numberOfAliveNeighbors;
        }
    }
}