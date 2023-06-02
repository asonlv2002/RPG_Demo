
namespace StateContents
{
    internal class PlayerRunState : MovementState
    {
        public PlayerRunState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsRunPressed && !InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsRunPressed;
        }
    }
}
