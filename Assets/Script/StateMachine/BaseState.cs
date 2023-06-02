using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
namespace StateContents
{
    internal abstract class BaseState
    {
        protected BaseState currentParentState;
        protected BaseState currentChildState;

        protected StateCore StateContent;
        public bool IsExit = true;
        protected PhysiscalAdapter Physiscal;
        protected BodyAdapter Body;

        protected int ActionParameter;
        protected Animator animator;

        public int IndexPriorityFriend { get; protected set; }

        public BaseState(StateCore stateContent)
        {
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
        }
        public virtual void FixedUpdateState()
        {
            currentParentState?.FixedUpdateState();
        }
        public virtual void ExitState()
        {

            currentChildState?.ExitState();
            currentChildState = null;

        }

        #region ChildState
        public virtual void InitilationChildrenState()
        {

        }
        protected virtual bool EnterChildState(BaseState childState)
        {
            if (!childState.ConditionInitChildState()) return false;
            (childState as BaseState).currentParentState = this;
            currentChildState = childState;
            StateContent.EnterNextState(childState);
            return true;
        }

        public virtual bool ConditionInitChildState()
        {
            return false;
        }
        #endregion

        #region FriendState
        protected virtual bool EnterFriendState(BaseState nextState)
        {
            if (nextState == null|| !nextState.ConditionEnterState()) return false;
            if(currentParentState != null)
            {
                currentParentState.currentChildState = nextState;
                nextState.currentParentState = currentParentState;
            }

            ExitState();
            StateContent.EnterNextState(nextState);
            return true;
        }

        public virtual bool ConditionEnterState()
        {
            return false;
        }

        #endregion

    }
}
