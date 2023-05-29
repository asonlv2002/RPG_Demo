
using AnimatorContent;

namespace StateContent
{
    internal class MovementParameterAdapter : StateComponent, IMovementParameter
    {
        MovementAnimatorParameter movementAnimatorParameter;
        public MovementParameterAdapter(IAnimatorContent animatorContent)
        {
            movementAnimatorParameter = animatorContent.GetContentComponent<MovementAnimatorParameter>();
        }

        public int IsGroundHash => movementAnimatorParameter.IsGroundHash;
        public int IsIdleHash => movementAnimatorParameter.IsIdleHash;
        public int IsMoveHash => movementAnimatorParameter.IsMoveHash;
        public int IsRunHash => movementAnimatorParameter.IsRunHash;
        public int IsSprintHash => movementAnimatorParameter.IsSprintHash;

        public int IsAirborneHash => movementAnimatorParameter.IsAirborneHash;
        public int IsJumpRiseHash => movementAnimatorParameter.IsJumpRiseHash;
        public int IsJumpFallHash => movementAnimatorParameter.IsJumpFallHash;
        public int IsFallHash => movementAnimatorParameter.IsFallHash;
        public int IsStopOnGround => movementAnimatorParameter.IsStopOnGround;
        public int IsSprintToStop => movementAnimatorParameter.IsSprintToStop;
    }
}
