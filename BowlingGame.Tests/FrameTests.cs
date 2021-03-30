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

        [Theory]
        [InlineData(5, 5, true, true, 2, 10)]
        [InlineData(1, 5, false, true, 2, 6)]
        public void Add_SecondThrow_ShouldSetSecondCorrectProperties(int firstThrowPins, int secondThrowPins, bool isSpare, bool isFrameCompelted, int throwCount, int frameScore)
        {
            //Arrange
            frame = new Frame();
            frame.Add(firstThrowPins); //First Throw

            //Act
            frame.Add(secondThrowPins); //Second Throw

            //Assert
            Assert.Equal(secondThrowPins, frame.SecondThrowPins);
            Assert.Equal(isSpare, frame.IsSpare);
            Assert.Equal(isFrameCompelted, frame.IsFrameCompleted);
            Assert.Equal(throwCount, frame.ThrowCount);
            Assert.Equal(frameScore, frame.FrameScore);
        }

        [Fact]
        public void Add_ShouldThrowException_WhenAddingSecondThrowIfFrameIsCompelted()
        {
            //Arrange
            frame.Add(10); //First Throw

            //Act and Assert
            Assert.Throws<FrameAlreadyCompletedException>(() => frame.Add(5));
        }
    }
}
