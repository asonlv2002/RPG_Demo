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

        public int IndexPriorityFriend { get; protected set; }

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

        #region ChildState
        public void AddChildState(IState childSate)
        {
            childStates.Add(childSate);
            (childSate as BaseState).currentParentState = this;

        }
        public void InitilationChildrenState()
        {
            if (childStates.Count <= 0) return;
            EnterChildState(childStates.Find(x => x.ConditionInitChildState() == true));
        }
        protected virtual void EnterChildState(IState childState)
        {
            if (childState == null) return;
            currentChildState = childState;
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
            if (friendStates.Count <= 0 || !ConditionExitState()) return;
            EnterFriendState(friendStates.Find(x => x.ConditionEnterState() == true));
        }

        protected virtual void EnterFriendState(IState nextState)
        {
            if (nextState == null) return;
            var parent = (nextState as BaseState).currentParentState;
            if (parent != null)
            {
                if (parent == currentParentState)
                    (currentParentState as BaseState).currentChildState = nextState;
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
