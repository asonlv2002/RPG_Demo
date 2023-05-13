using UnityEngine;
using UnityEngine.Events;
namespace Achitecture
{
    internal abstract class PlayerBaseState
    {
        protected PlayerStateMachine _context;
        protected PlayerStateFactory _factory;
        protected PlayerBaseState _childState;
        protected PlayerBaseState _parentState;
        protected int _animtionHash;

        protected UnityAction OnEnter;
        protected UnityAction OnUpdate;
        protected UnityAction OnFixedUpdate;
        protected UnityAction OnExit;

        public PlayerBaseState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
        {
            InitilaztionAction();
            _context = playerStateMachine;
            _factory = playerStateFactory;
        }
        public virtual void EnterState()
        {
            _context.CurrentState = this;
            OnEnter?.Invoke();
            EnableAnimationState();
        }

        protected virtual void SwitchState(PlayerBaseState nextState)
        {

            _parentState._childState = nextState;
            nextState._parentState = _parentState;
            ExitState();
            nextState.EnterState();
        }

        public virtual void UpdateState()
        {
            OnUpdate?.Invoke();
            _parentState?.UpdateState();
        }
        public virtual void FixedUpdateState()
        {
            OnFixedUpdate?.Invoke();
            _parentState?.FixedUpdateState();
        }

        public virtual void ExitState()
        {
            OnExit?.Invoke();
            DisableAnimationState();
            if (this is IRootState)
            {
                _childState.ExitState();
                _childState = null;
            }

        }
        public abstract void CheckUpdateState();
        protected virtual void SetParenForChildState(PlayerBaseState parentState)
        {
            _parentState = parentState;
        }

        protected virtual void SetChildState(PlayerBaseState childState)
        {
            _childState = childState;
            _childState.SetParenForChildState(this);
        }

        protected void EnableAnimationState()
        {
            _context.AnimationControl.SetBool(_animtionHash, true);
        }
        protected void DisableAnimationState()
        {
            _context.AnimationControl.SetBool(_animtionHash, false);
        }
        protected virtual void InitilaztionAction() { }

    }
}
