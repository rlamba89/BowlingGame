namespace BowlingGame
{
    public class Game
    {
        public Frame[] Frames;
        private int frameIndex;
        private const int MaxFrame = 10;

        public Game()
        {
            Frames = new Frame[MaxFrame];
        }

        private Frame GetFrame()
        {
            var frame = Frames[frameIndex];

            if (frame == null)
            {
                frame = frameIndex == MaxFrame - 1 ? new TenthFrame() : new Frame();

                Frames[frameIndex] = frame;
            }

            return frame;
        }

        public void Roll(int pins)
        {
            var frame = GetFrame();

            frame.Add(pins);

            if (frame.IsFrameCompleted && frameIndex < MaxFrame - 1)
            {
                frameIndex++;
            }
        }

        public int Score()
        {
            int score = 0;
            int i = 0;
            foreach (var frame in Frames)
            {
                if (frame == null) continue;

                if (frame.IsSpare && i < Frames.Length - 1)
                {
                    score += Frames[i + 1].FirstThrowPins;
                }
                else if (frame.IsStrike && i < Frames.Length - 1)
                {
                    score += Frames[i + 1].FirstThrowPins + Frames[i + 1].SecondThrowPins;
                }

                score += frame.FrameScore;
                i++;
            }

            return score;
        }

    }
}
