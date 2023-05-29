namespace StateContent
{
    internal interface IMovementParameter
    {
        public int IsGroundHash { get; }
        public int IsIdleHash { get; }
        public int IsMoveHash { get; }
        public int IsRunHash { get; }
        public int IsSprintHash { get; }

        public int IsAirborneHash { get; }
        public int IsJumpRiseHash { get; }
        public int IsJumpFallHash { get; }
        public int IsFallHash { get; }
        public int IsStopOnGround { get; }
        public int IsSprintToStop { get; }
    }
}
