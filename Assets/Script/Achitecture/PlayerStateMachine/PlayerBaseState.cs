
namespace Achitecture
{
    internal abstract class PlayerBaseState
    {
        protected bool _isRootState = false;
        protected PlayerStateMachine _contextStateMachine;
        protected PlayerBaseState _currentSuperState;
        protected PlayerBaseState _currentSubState;
        public abstract void EnterState();

        public abstract void ExitState();

        public void UpdateState()
        {

        }
        public abstract void PhysicUpdate();
        public abstract void CheckUpdateState();

        protected void SwitchState(PlayerBaseState newState)
        {
            ExitState();

            newState.EnterState();
        }

        protected void SetSuperState(PlayerBaseState newState)
        {
            _currentSuperState = newState;
        }

        protected void SetSubState(PlayerBaseState newState)
        {
            _currentSubState = newState;
            newState.SetSuperState(this);
        }
    }
}
