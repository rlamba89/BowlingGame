using Xunit;

namespace BowlingGame.Tests
{
    public class FrameTests
    {
        Frame frame;
        public FrameTests()
        {
            frame = new Frame();
        }

        [Theory]
        [InlineData(5, false, false, 1)]
        [InlineData(10, true, true, 1)]
        public void Add_WhenFirstThrow_ShouldSetCorrectProperties(int pins, bool isStrike, bool isFrameCompelted, int throwCount)
        {
            frame.Add(pins);

            Assert.Equal(pins, frame.FirstThrowPins);
            Assert.Equal(isStrike, frame.IsStrike);
            Assert.Equal(isFrameCompelted, frame.IsFrameCompleted);
            Assert.Equal(throwCount, frame.ThrowCount);
        }

        [Fact]
        public void Add_SecondThrow_ShouldSetSecondThrowPins()
        {
            //Arrange
            frame.Add(5); //First Throw

            //Act
            frame.Add(5); //Second Throw

            Assert.Equal(5, frame.SecondThrowPins);
        }

        [Fact]
        public void Add_SecondThrow_ShouldSetSpareTrueWhenTotalScoreEqualToTotalPins()
        {
            //Arrange
            frame.Add(5); //First Throw

            //Act
            frame.Add(5); //Second Throw

            //Assert
            Assert.Equal(5, frame.SecondThrowPins);
            Assert.True(frame.IsSpare);
        }

        [Fact]
        public void Add_SecondThrow_ShouldMarkFrameCompleted()
        {
            //Arrange
            frame.Add(5); //First Throw

            //Act
            frame.Add(5); //Second Throw

            //Assert
            Assert.Equal(5, frame.SecondThrowPins);
            Assert.True(frame.IsFrameCompleted);
            Assert.Equal(10, frame.FrameScore);
            Assert.Equal(2, frame.ThrowCount);
        }

        [Fact]
        public void Add_ShouldThrowException_WhenAddingSecondThrowIfFrameIsCompelted()
        {
            //Arrange
            frame.Add(10); //First Throw

            Assert.Throws<FrameAlreadyCompletedException>(() => frame.Add(5));
        }
    }
}
