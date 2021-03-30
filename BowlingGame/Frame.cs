using System.Collections.Generic;

namespace BowlingGame
{
    public class Frame
    {
        private readonly int TotalPins = 10;

        public void Add(int pins)
        {
            if (ThrowCount == 0)
            {
                AddFirstThrow(pins);
            }
            else if(ThrowCount == 1)
            {
                AddSecondThrow(pins);
            }
        }


        private void AddFirstThrow(int firstKnockPins)
        {
            FirstThrowPins = firstKnockPins;
            
            if (FirstThrowPins == TotalPins)
            {
                IsFrameCompleted = true;
                IsStrike = true;
            }

            ThrowCount++;
        }

        private void AddSecondThrow(int secondKnockPins)
        {
            if (IsFrameCompleted) throw new FrameAlreadyCompletedException("Can not add more pins.");

            SecondThrowPins = secondKnockPins;

            if (FrameScore == TotalPins)
            {
                IsSpare = true; 
            }

            IsFrameCompleted = true;
            ThrowCount++;
        }

        public bool IsStrike { get; private set; }

        public bool IsSpare { get; private set; }

        public bool IsFrameCompleted { get; private set; }
        
        public int FirstThrowPins { get; private set; }

        public int SecondThrowPins { get; private set; }

        public int ThrowCount { get; private set; }

        public int FrameScore => FirstThrowPins + SecondThrowPins;
    }
}
