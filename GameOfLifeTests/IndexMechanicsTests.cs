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

    }

    public static class IndexMechanics
    {
        public static IEnumerable<(int row,int column)> Neighbors((int row, int column) valueTuple)
        {
            yield return (valueTuple.row - 1, valueTuple.column - 1);
            yield return (valueTuple.row - 1, valueTuple.column);
            yield return (valueTuple.row - 1, valueTuple.column + 1);
            yield return (valueTuple.row, valueTuple.column - 1);
            yield return (valueTuple.row, valueTuple.column + 1);
            yield return (valueTuple.row + 1, valueTuple.column - 1);
            yield return (valueTuple.row + 1, valueTuple.column);
            yield return (valueTuple.row + 1, valueTuple.column + 1);
        }
    }
}