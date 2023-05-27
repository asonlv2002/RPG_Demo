namespace StateMachine
{
    using AnimatorContent;
    using UnityEngine;
    internal class AnimationIdUnequipStore : AnimationIDAdapter, ITransfomAnimationID
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

        public AnimationIdUnequipStore(PlayerAnimator playerAnimator ) : base(playerAnimator)
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

        public int IsGroundHash {get; private set;}

        public int IsIdleHash {get; private set;}

        public int IsMoveHash {get; private set;}

        public int IsRunHash {get; private set;}

        public int IsSprintHash {get; private set;}

        public int IsAirborneHash {get; private set;}

        public int IsJumpRiseHash {get; private set;}

        public int IsJumpFallHash {get; private set;}

        public int IsFallHash {get; private set;}

        public int IsStopOnGround {get; private set;}

        public int IsSprintToStop {get; private set;}
    }
}
