﻿
namespace Achitecture
{
    internal abstract class PlayerBaseState
    {
        protected PlayerStateMachine _context;
        protected PlayerStateFactory _factory;
        protected PlayerBaseState _childState;
        protected PlayerBaseState _parentState;
        protected int _animtionHash;

        public PlayerBaseState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
        {
            _context = playerStateMachine;
            _factory = playerStateFactory;
        }
        public virtual void EnterState()
        {
            _context.CurrentState = this;
            EnableAnimationState();
        }

        public virtual void ExitState()
        {
            DisableAnimationState();
            if (this is IRootState)
            {
                _childState.ExitState();
                _childState = null;
            }    

        }

        public virtual void UpdateState()
        {
            _parentState?.UpdateState();
        }
        public virtual void FixedUpdateState()
        {
            _parentState?.FixedUpdateState();
        }
        public abstract void CheckUpdateState();

        protected virtual void SwitchState(PlayerBaseState nextState)
        {

            _parentState._childState = nextState;
            nextState._parentState = _parentState;
            ExitState();
            nextState.EnterState();
        }

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


    }
}
