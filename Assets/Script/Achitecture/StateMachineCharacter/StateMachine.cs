
namespace Achitecture.StateMachineCharacter
{
    internal abstract class StateMachine 
    {
        protected IState _currentState;

        public void SwitchState(IState newState)
        {
            _currentState?.ExitState();

            _currentState = newState;

            _currentState.EnterState();
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void PhysicUpdate()
        {
            _currentState?.PhysicsUpdate();
        }

        public void HandleInput()
        {
            _currentState?.HanldeInput();
        }
    }
}
