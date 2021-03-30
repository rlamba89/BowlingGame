namespace BowlingGame
{
    public class TenthFrame :Frame
    {
        public override void Add(int pins)
        {
            if (ThrowCount == 2 && (IsSpare || IsStrike))
            {
                BonusRoll = pins;
            }
            else
            {
                base.Add(pins);
            }
        }

        public int BonusRoll { get; protected set; }

        public override int FrameScore => FirstThrowPins + SecondThrowPins + BonusRoll;
    }
}
