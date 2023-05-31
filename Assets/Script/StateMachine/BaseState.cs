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

        protected PhysiscalAdapter Physiscal;
        protected BodyAdapter Body;

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
            currentParentState?.EnterState();
        }
        public virtual void UpdateState()
        {
            currentParentState?.UpdateState();
            SwitchToFriendState();
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

        #region ChildState
        public void AddChildState(IState childSate)
        {
            childStates.Add(childSate);
        }
        public void InitilationChildrenState()
        {
            if (childStates.Count <= 0) return;
            foreach (var child in childStates)
            {
                if (child.ConditionInitChildState())
                {
                    SetChildState(child);
                    EnterChildState(currentChildState);
                    return;
                }
            }
        }
        protected virtual void EnterChildState(IState childState)
        {
            StateContent.EnterNextState(childState);
        }

        public abstract bool ConditionInitChildState();
        #endregion

        #region FriendState
        public void AddFriendState(IState friendState)
        {
            if (friendStates.IndexOf(friendState) >= 0) return;
            friendStates.Add(friendState);
            friendState.AddFriendState(this);
        }
        protected virtual void SwitchToFriendState()
        {
            if (friendStates.Count <= 0) return;
            foreach (var friend in friendStates)
            {
                if (friend.ConditionEnterState())
                {
                    EnterFriendState(friend);
                    return;
                }
            }
        }

        protected virtual void EnterFriendState(IState nextState)
        {
            if (currentParentState != null)
            {
                (currentParentState as BaseState).currentChildState = nextState;
                (nextState as BaseState).currentParentState = currentParentState;
            }
            ExitState();
            StateContent.EnterNextState(nextState);
        }

        public abstract bool ConditionEnterState();

        public virtual bool ConditionExitState()
        {
            return true;
        }
        #endregion

    }
}
