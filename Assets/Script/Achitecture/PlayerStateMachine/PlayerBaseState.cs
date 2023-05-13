using UnityEngine;
using UnityEngine.Events;
namespace Achitecture.StateMachine
{
    internal abstract class PlayerBaseState
    {
        protected PlayerStateMachine stateControl;
        protected PlayerStateFactory factoryState;
        protected PlayerBaseState childState;
        protected PlayerBaseState parentState;
        protected int animtionHash;

        protected UnityAction OnEnter;
        protected UnityAction OnUpdate;
        protected UnityAction OnFixedUpdate;
        protected UnityAction OnExit;

        public PlayerBaseState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
        {
            InitilaztionAction();
            stateControl = playerStateMachine;
            factoryState = playerStateFactory;
        }
        public virtual void EnterState()
        {
            stateControl.CurrentState = this;
            OnEnter?.Invoke();
            EnableAnimationState();
        }

        protected virtual void SwitchState(PlayerBaseState nextState)
        {

            parentState.childState = nextState;
            nextState.parentState = parentState;
            ExitState();
            nextState.EnterState();
        }

        public virtual void UpdateState()
        {
            OnUpdate?.Invoke();
            parentState?.UpdateState();
        }
        public virtual void FixedUpdateState()
        {
            OnFixedUpdate?.Invoke();
            parentState?.FixedUpdateState();
        }

        public virtual void ExitState()
        {
            OnExit?.Invoke();
            DisableAnimationState();
            if (this is IRootState)
            {
                childState.ExitState();
                childState = null;
            }

        }
        public abstract void CheckUpdateState();
        protected virtual void SetParenForChildState(PlayerBaseState parentState)
        {
            this.parentState = parentState;
        }

        protected virtual void SetChildState(PlayerBaseState childState)
        {
            this.childState = childState;
            this.childState.SetParenForChildState(this);
        }

        protected void EnableAnimationState()
        {
            stateControl.AnimationControl.SetBool(animtionHash, true);
        }
        protected void DisableAnimationState()
        {
            stateControl.AnimationControl.SetBool(animtionHash, false);
        }
        protected virtual void InitilaztionAction() { }

    }
}
