using System;

namespace BowlingGame
{
    public class FrameAlreadyCompletedException : Exception
    {
        public FrameAlreadyCompletedException(string message) : base(message)
        {
        }
    }
}
