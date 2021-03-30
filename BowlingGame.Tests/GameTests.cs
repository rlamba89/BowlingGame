using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class GameTests
    {
        Game game;
        public GameTests()
        {
            game = new Game();
        }

        [Fact]
        public void Constructor_ShouldInitialize_TenFrames()
        {
            Assert.Equal(10, game.Frames.Length);
        }
    }
}
