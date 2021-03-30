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
        [InlineData(5, false, false)]
        [InlineData(10, true, true)]
        public void Add_ForFirstThrow_ShouldAddFirstThrowPins(int pins, bool isStrike, bool isFrameCompelted)
        {
            frame.Add(pins);

            Assert.Equal(pins, frame.FirstThrowPins);
            Assert.Equal(isStrike, frame.IsStrike);
            Assert.Equal(isFrameCompelted, frame.IsFrameCompleted);
        }
    }
}
