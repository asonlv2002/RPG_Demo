using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
namespace StateContents
{
    internal abstract class BaseState : IState
    {
        protected IState currentParentState;
        protected IState currentChildState;

        protected StateCore StateContent;

        protected IPhysicAdapter Physiscal;
        protected IBodyAdapter Body;

        protected List<IState> friendStates;
        protected List<IState> childStates;

        protected int ActionParameter;
        protected Animator animator;

        public BaseState(StateCore stateContent)
        {
            friendStates = new List<IState>();
            childStates = new List<IState>();

            StateContent = stateContent;
            animator = StateContent.GetContentComponent<ActionRender>().Animator;
            Physiscal = StateContent.GetContentComponent<PhysiscalAdapter>();
            Body = StateContent.GetContentComponent<BodyAdapter>();

        }
        public virtual void EnterState()
        {
            StateContent.CurrentState = this;
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
            if(currentParentState != null)
            {
                (currentParentState as BaseState).currentChildState = nextState;
                (nextState as BaseState).currentParentState = currentParentState;
            }

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
