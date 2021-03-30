using System.Collections.Generic;

namespace BowlingGame
{
    public class Frame
    {
        protected readonly int TotalPins = 10;

        public virtual void Add(int pins)
        {
            if (IsFrameCompleted) throw new FrameAlreadyCompletedException("Can not add more pins.");

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
                ThrowCount += 2;
            }
            else
            {
                ThrowCount += 1;
            }
        }

        private void AddSecondThrow(int secondKnockPins)
        {
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

        public virtual int FrameScore => FirstThrowPins + SecondThrowPins;
    }
}
