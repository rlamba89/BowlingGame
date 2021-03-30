using Xunit;

namespace BowlingGame.Tests
{
    public class TenthFrameTests
    {
        [Fact]
        public void Add_TenthThrow_ShouldAddFirstAndSecondThrows()
        {
            var tenthFrame = new TenthFrame();

            tenthFrame.Add(5);
            tenthFrame.Add(5);

            Assert.Equal(5, tenthFrame.FirstThrowPins);
            Assert.Equal(5, tenthFrame.SecondThrowPins);
        }

        [Fact]
        public void Add_TenthThrow_ShouldAddBonusWhenSpareForLastFrame()
        {
            var tenthFrame = new TenthFrame();

            tenthFrame.Add(5);
            tenthFrame.Add(5);
            tenthFrame.Add(10);

            Assert.Equal(5, tenthFrame.FirstThrowPins);
            Assert.Equal(5, tenthFrame.SecondThrowPins);
            Assert.Equal(10, tenthFrame.BonusRoll);
            Assert.Equal(20, tenthFrame.FrameScore);
        }

        [Fact]
        public void Add_TenthThrow_ShouldAddBonusWhenStrikeForLastFrame()
        {
            var tenthFrame = new TenthFrame();

            tenthFrame.Add(10);
            tenthFrame.Add(10);

            Assert.Equal(10, tenthFrame.FirstThrowPins);
            Assert.Equal(0, tenthFrame.SecondThrowPins);
            Assert.Equal(10, tenthFrame.BonusRoll);
            Assert.Equal(20, tenthFrame.FrameScore);
        }
    }
}
