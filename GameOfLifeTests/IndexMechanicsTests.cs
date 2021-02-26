using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class IndexMechanicsTests
    {
        [TestMethod]
        public void an_index_has_eight_neighbors()
        {
            new IndexMechanics(10,10).Neighbors((2, 2)).Should().HaveCount(8);
        }

        [TestMethod]
        public void neighbor_indices_indicate_cells_around_the_initial_cell()
        {
            new IndexMechanics(10,10).Neighbors((2, 2)).Should().BeEquivalentTo(
                (1, 1),
                (1, 2),
                (1, 3),
                (2, 1),
                (2, 3),
                (3, 1),
                (3, 2),
                (3, 3)
            );
        }

        [TestMethod]
        public void negative_row_indices_wrap_around_to_the_bottom()
        {
            new IndexMechanics(10,10).Neighbors((0, 2)).Should().BeEquivalentTo(
                (9, 1),
                (9, 2),
                (9, 3),
                (0, 1),
                (0, 3),
                (1, 1),
                (1, 2),
                (1, 3)
            );
        }

        [TestMethod]
        public void high_row_indices_wrap_around_to_the_top()
        {
            new IndexMechanics(5,5).Neighbors((4, 2)).Should().BeEquivalentTo(
                (3, 1),
                (3, 2),
                (3, 3),
                (4, 1),
                (4, 3),
                (0, 1),
                (0, 2),
                (0, 3)
            );
        }

    }

    public class IndexMechanics
    {
        private readonly int rows;
        private readonly int columns;

        public IndexMechanics(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        private int WrapRow(int row)
        {
            if (row == rows)
            {
                return 0;
            }

            return row < 0
                ? rows - 1
                : row;
        }
        
        public IEnumerable<(int row,int column)> Neighbors((int row, int column) valueTuple)
        {
            yield return (WrapRow(valueTuple.row - 1), valueTuple.column - 1);
            yield return (WrapRow(valueTuple.row - 1), valueTuple.column);
            yield return (WrapRow(valueTuple.row - 1), valueTuple.column + 1);
            yield return (valueTuple.row, valueTuple.column - 1);
            yield return (valueTuple.row, valueTuple.column + 1);
            yield return (WrapRow(valueTuple.row + 1), valueTuple.column - 1);
            yield return (WrapRow(valueTuple.row + 1), valueTuple.column);
            yield return (WrapRow(valueTuple.row + 1), valueTuple.column + 1);
        }
    }
}