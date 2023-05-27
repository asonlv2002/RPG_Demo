using UnityEngine;

namespace AnimatorContent
{
    internal class AnimationIntHashs
    {
        const string _isGround = "isGround";
        const string _isIdle = "isIdle";
        const string _isRun = "isRun";
        const string _isMove = "isMove";
        const string _isSprint = "isSprint";
        const string _isAirborne = "isAirBorne";
        const string _isFall = "isFall";
        const string _isJumpRise = "isJumpRise";
        const string _isJumpFall = "isJumpFall";
        const string _isStopOnGround = "isStopOnGround";
        const string _isSprintToStop = "isSprintToStop";

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

        public AnimationIntHashs()
        {
            IsGroundHash = Animator.StringToHash(_isGround);
            IsIdleHash = Animator.StringToHash(_isIdle);
            IsMoveHash = Animator.StringToHash(_isMove);
            IsRunHash = Animator.StringToHash(_isRun);
            IsSprintHash = Animator.StringToHash(_isSprint);

            IsAirborneHash = Animator.StringToHash(_isAirborne);
            IsJumpRiseHash = Animator.StringToHash(_isJumpRise);
            IsJumpFallHash = Animator.StringToHash(_isJumpFall);
            IsFallHash = Animator.StringToHash(_isFall);

            IsStopOnGround = Animator.StringToHash(_isStopOnGround);
            IsSprintToStop = Animator.StringToHash(_isSprintToStop);

        }
    }
}
