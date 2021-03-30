using System;

namespace BowlingGame
{
    public class Game
    {
        public Frame[] Frames;

        const int MaxFrame = 10;

        public Game()
        {
            Frames = new Frame[MaxFrame];
        }

        public void Roll(int pins)
        {
            throw new NotImplementedException();
        }
    }
}
