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

        [Fact]
        public void Roll_ForAGivenThrow_ShouldAddPinsInAppropriateFrameIndex()
        {
            game.Roll(1);
            game.Roll(1);

            Assert.Equal(2, game.Frames[0].FrameScore);
        }

        [Fact]
        public void Roll_WhenFrameIsCompleted_ShouldIncrementFrameIndex()
        {
            game.Roll(1);
            game.Roll(1); //First Frame

            game.Roll(5); //Second Frame
            game.Roll(5);

            Assert.Equal(2, game.Frames[0].FrameScore);
            Assert.Equal(10, game.Frames[1].FrameScore);
            Assert.True(game.Frames[1].IsSpare);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 5, 5, 5, 4 }, 26)]
        [InlineData(new int[] { 1, 1, 10, 5, 4 }, 30)]
        [InlineData(new int[] { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 }, 133)]
        [InlineData(new int[] { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 10, 6 }, 133)]
        public void Score_WhenFrameIsSpare_ShouldIncludeNextFirstThrowPins(int[] throws, int expectedScore)
        {
            //Arrange
            foreach (var pin in throws)
            {
                game.Roll(pin);
            }

            //Act
            var actualScore = game.Score();

            //Assert
            Assert.Equal(expectedScore, actualScore);
        }
    }
}
