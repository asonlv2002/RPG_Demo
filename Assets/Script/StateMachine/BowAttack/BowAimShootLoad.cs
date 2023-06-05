﻿
namespace StateContents
{
    using UnityEngine;
    internal class BowAimShootLoad : BowAttack
    {
        float TimePassed;
        public BowAimShootLoad(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = Animator.StringToHash("isShootLoad");
        }

        public override void EnterState()
        {
            base.EnterState();
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Load");
            TimePassed = Time.time + 1.33f;
        }

        public override void UpdateState()
        {
            Debug.Log("Load");
            if (Time.time > TimePassed)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.AimShootHolding)) return;
            }
            if (EnterFriendState(BowStore.AimShootReslease)) return;
            base.UpdateState();
        }
        public override void ExitState()
        {
            IsExit = true;
            Debug.Log("Exit Load");
            animator.SetBool(ActionParameter, !IsExit);
            base.ExitState();
        }
        public override bool ConditionInitChildState()
        {
            return Body.IsOnGround && InputAttack.IsHolding;
        }
    }
}


