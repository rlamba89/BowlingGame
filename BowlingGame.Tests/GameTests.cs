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

        [Fact]
        public void Score_WhenFrameIsSpare_ShouldIncludeNextFirstThrowPins()
        {
            //Arrange
            game.Roll(1);
            game.Roll(1); //First Frame

            game.Roll(5); //Second Frame
            game.Roll(5);

            game.Roll(5); //Third Frame
            game.Roll(4);

            //Act
            var totalScore =  game.Score();

            Assert.Equal(26, totalScore);
        }

        [Fact]
        public void Score_WhenFrameIsStrike_ShouldIncludeNextTwoThrowPins()
        {
            //Arrange
            game.Roll(1);
            game.Roll(1); //First Frame

            game.Roll(10); //Second Frame

            game.Roll(5); //Third Frame
            game.Roll(4);

            //Act
            var totalScore = game.Score();

            Assert.Equal(30, totalScore);
        }
    }
}
