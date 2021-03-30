using System;
using System.Collections.Generic;
using System.Text;
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

        [Fact]
        public void Add_ForFirstThrow_ShouldAddFirstThrowPins()
        {
            frame.Add(5);

            Assert.Equal(5, frame.FirstThrowPins);
        }

        [Fact]
        public void Add_WhenFirstThrowIsStrike_ShouldMarkIsStrikeTruthy()
        {
            frame.Add(10);

            Assert.Equal(10, frame.FirstThrowPins);
            Assert.True(frame.IsStrike);
        }

        [Fact]
        public void Add_WhenFirstThrowIsStrike_ShouldCompleteTheFrame()
        {
            frame.Add(10);

            Assert.True(frame.IsFrameCompleted);
        }

        [Fact]
        public void Add_WhenFirstThrowIsNotStrike_ShouldNotCompleteTheFrame()
        {
            frame.Add(5);

            Assert.True(!frame.IsFrameCompleted);
            Assert.True(!frame.IsStrike);
        }
    }
}
