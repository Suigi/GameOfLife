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
            IndexMechanics.Neighbors((2, 2)).Should().HaveCount(8);
        }

        [TestMethod]
        public void neighbor_indices_indicate_cells_around_the_initial_cell()
        {
            IndexMechanics.Neighbors((2, 2)).Should().BeEquivalentTo(
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
        public void neighbor_indices_rows_wrap_around()
        {
            // we're assuming 10 rows at the moment, we'll fix this shortly
            IndexMechanics.Neighbors((0, 2)).Should().BeEquivalentTo(
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

    }

    public static class IndexMechanics
    {
        private static int WrapRow(int row)
        {
            return row < 0
                ? 9
                : row;
        }
        
        public static IEnumerable<(int row,int column)> Neighbors((int row, int column) valueTuple)
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