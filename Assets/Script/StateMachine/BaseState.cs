using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
namespace StateMachine
{
    internal abstract class BaseState : IState
    {
        protected IState currentParentState;
        protected IState currentChildState;
        protected IStateContext StateContext;
        protected IStatePhysicAdapter Physiscal;
        protected IStateBodyAdapter Body;
        protected int animtionID;

        protected List<IState> friendStates;
        protected List<IState> childStates;

        private IStateAnimationTrigger AnimationTrigger;
        public BaseState(IStateContext stateContext)
        {
            friendStates = new List<IState>();
            childStates = new List<IState>();
            StateContext = stateContext;
            AnimationTrigger = (StateContext as IStateAnimationIDProvider).AnimationIDProvider as IStateAnimationTrigger;
            Physiscal = (StateContext as IStatePhysiscalProvider).PhysiscalProvider;
            Body = (StateContext as IStateBodyProvider).Body;

        }
        public virtual void EnterState()
        {
            AnimationTrigger.EnableTrigger(this.animtionID);
            StateContext.CurrentState = this;
            InitilationChildrenState();
        }
        public virtual void UpdateState()
        {
            SwitchToFriendState();
            currentParentState?.UpdateState();
        }
        public virtual void FixedUpdateState()
        {
            currentParentState?.FixedUpdateState();
        }
        public virtual void ExitState()
        {
            AnimationTrigger.DisableTrigger(this.animtionID);
            if (currentChildState != null)
            {
                currentChildState.ExitState();
                currentChildState = null;
            }

        }
        protected virtual void SetChildState(IState _childState)
        {
            this.currentChildState = _childState;
            (currentChildState as BaseState).currentParentState = this;
        }

        #region Condition
        public abstract bool ConditionEnterState();
        public abstract bool ConditionInitChildState();
        #endregion;

        #region TransState
        protected virtual void SwitchState(IState nextState)
        {
            (currentParentState as BaseState).currentChildState = nextState;
            (nextState as BaseState).currentParentState = currentParentState;
            ExitState();
            nextState.EnterState();
        }
        protected virtual void SwitchToFriendState()
        {
            if (friendStates.Count <= 0) return;
            foreach (var friend in friendStates)
            {
                if (friend.ConditionEnterState())
                {
                    //Debug.Log(friend);
                    SwitchState(friend);
                    return;
                }
            }
        }
        protected void InitilationChildrenState()
        {
            if(childStates.Count <=0 ) return;
            foreach (var child in childStates)
            {
                if (child.ConditionInitChildState())
                {
                    SetChildState(child);
                    //Debug.Log(child);
                    currentChildState.EnterState();
                    return;
                }
            }
        }
        #endregion;

        #region Community
        public void AddFriendState(IState friendState)
        {
            if (friendStates.IndexOf(friendState) >= 0) return;
            friendStates.Add(friendState);
            friendState.AddFriendState(this);
        }

        public void AddChildState(IState childSate)
        {
            childStates.Add(childSate);
        }
        #endregion

    }
}
