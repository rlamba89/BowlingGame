using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class GameTests
    {
        [Fact]
        public void Constructor_ShouldInitialize_TenFrames()
        {
            var game = new Game();

            Assert.Equal(10, game.Frames.Length);
        }
    }
}
