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
            var game = new Game();
            game.IsCellAlive(2, 2).Should().BeFalse();
        }
    }

    public class Game
    {
        public bool IsCellAlive(int i, int i1)
        {
            return false;
        }
    }
}