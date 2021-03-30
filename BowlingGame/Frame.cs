namespace BowlingGame
{
    public class Frame
    {
        private readonly int PinsCount = 10;

        public void Add(int pins)
        {
            AddFirstThrow(pins);
        }


        private void AddFirstThrow(int firstKnockPins)
        {
            FirstThrowPins = firstKnockPins;
            
            if (FirstThrowPins == PinsCount)
            {
                IsFrameCompleted = true;
                IsStrike = true;
            }
        }

        public bool IsStrike { get; private set; }

        public bool IsFrameCompleted { get; private set; }
        
        public int FirstThrowPins { get; private set; }

    }
}
