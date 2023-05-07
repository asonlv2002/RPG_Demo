
namespace Achitecture
{
    internal abstract class PlayerBaseState
    {
        protected bool _isRootState = false;
        protected PlayerStateMachine _context;
        protected PlayerStateFactory _factory;
        protected PlayerBaseState _currentSuperState;
        protected PlayerBaseState _currentSubState;
        protected int _animtionHash;

        public PlayerBaseState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
        {
            _context = playerStateMachine;
            _factory = playerStateFactory;
        }
        public virtual void EnterState()
        {
            EnableAnimationState();
        }

        public virtual void ExitState()
        {
            _currentSubState?.ExitState();
            DisableAnimationState();
        }

        public virtual void UpdateState()
        {
            _currentSubState?.UpdateState();
        }
        public abstract void CheckUpdateState();

        protected virtual void SwitchState(PlayerBaseState newState)
        {
            ExitState();

            newState.EnterState();

            if (_isRootState) _context.CurrentState = newState;
            _currentSuperState?.SetSubState(newState);
        }

        protected virtual void SetSuperState(PlayerBaseState newState)
        {
            _currentSuperState = newState;
        }

        protected virtual void SetSubState(PlayerBaseState newState)
        {
            _currentSubState = newState;
            newState.SetSuperState(this);
        }
        protected virtual void InitializationSubState()
        {

        }

        protected void EnableAnimationState()
        {
            _context.AnimationControl.SetBool(_animtionHash, true);
        }
        protected void DisableAnimationState()
        {
            _context.AnimationControl.SetBool(_animtionHash, false);
        }


    }
}
