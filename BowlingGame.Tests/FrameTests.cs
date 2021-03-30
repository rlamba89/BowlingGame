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
        public void Add_ForFirstThrow_ShouldAddFirstThrowPins(int pins, bool isStrike, bool isFrameCompelted, int throwCount)
        {
            frame.Add(pins);

            Assert.Equal(pins, frame.FirstThrowPins);
            Assert.Equal(isStrike, frame.IsStrike);
            Assert.Equal(isFrameCompelted, frame.IsFrameCompleted);
            Assert.Equal(throwCount, frame.ThrowCount);
        }
    }
}
