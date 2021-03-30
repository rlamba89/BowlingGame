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


    }
}
