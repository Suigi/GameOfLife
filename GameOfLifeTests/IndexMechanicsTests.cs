using System.Collections.Generic;
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
    }

    public static class IndexMechanics
    {
        public static IEnumerable<(int,int)> Neighbors((int, int) valueTuple)
        {
            throw new System.NotImplementedException();
        }
    }
}