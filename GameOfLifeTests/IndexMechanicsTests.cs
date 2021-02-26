using FluentAssertions;
using GameOfLife;
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

        [TestMethod]
        public void negative_column_indices_wrap_to_the_right()
        {
            new IndexMechanics(10,10).Neighbors((2, 0)).Should().BeEquivalentTo(
                (1, 9),
                (1, 0),
                (1, 1),
                (2, 9),
                (2, 1),
                (3, 9),
                (3, 0),
                (3, 1)
            );            
        }

        [TestMethod]
        public void high_column_indices_wrap_to_the_left()
        {
            new IndexMechanics(10,5).Neighbors((2, 4)).Should().BeEquivalentTo(
                (1, 3),
                (1, 4),
                (1, 0),
                (2, 3),
                (2, 0),
                (3, 3),
                (3, 4),
                (3, 0)
            );            
        }

        [TestMethod]
        public void all_indices_can_be_enumerated()
        {
            new IndexMechanics(3, 3).AllIndices().Should().BeEquivalentTo(
                (0, 0), (0, 1), (0, 2),
                (1, 0), (1, 1), (1, 2),
                (2, 0), (2, 1), (2, 2)
            );
        }

    }
}