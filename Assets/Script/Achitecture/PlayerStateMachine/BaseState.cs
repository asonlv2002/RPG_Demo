using UnityEngine;
using UnityEngine.Events;
namespace StateMachine
{
    internal abstract class BaseState : IState
    {
        protected IState parentState;
        protected IState childState;
        protected IStateContext StateContext;

        protected IStatePhysicAdapter Physiscal;
        protected IStateBodyAdapter Body;
        protected IStateInputAdapter Input;
        protected int animtionID;

        private IStateAnimationTrigger AnimationTrigger;


        public BaseState(IStateContext stateContext)
        {
            StateContext = stateContext;
            AnimationTrigger = (StateContext as IStateAnimationIDProvider).AnimationID as IStateAnimationTrigger;
            Physiscal = (StateContext as IStatePhysiscalProvider).Physiscal;
            Body = (StateContext as IStateBodyProvider).Body;
            Input = (StateContext as IStateInputProvider).Input;
        }
        public virtual void EnterState()
        {
            AnimationTrigger.EnableTrigger(this.animtionID);
            StateContext.CurrentState = this;
        }

        protected virtual void SwitchState(IState nextState)
        {
            (parentState as BaseState).childState = nextState;
            (nextState as BaseState).parentState = parentState;
            ExitState();
            nextState.EnterState();
        }

        public virtual void UpdateState()
        {
            SwitchToOtherRoot();
            parentState?.UpdateState();
        }
        public virtual void FixedUpdateState()
        {
            parentState?.FixedUpdateState();
        }

        public virtual void ExitState()
        {
            AnimationTrigger.DisableTrigger(this.animtionID);
            if (this is IRootState)
            {
                childState?.ExitState();
                childState = null;
            }

        }
        public virtual void SwitchToOtherRoot()
        {

        }
        protected virtual void SetParenForChildState(IState _parentState)
        {
            this.parentState = _parentState as BaseState;
        }

        protected virtual void SetChildState(IState _childState)
        {
            this.childState = _childState;
            (childState as BaseState).parentState = this;
        }
    }
}
