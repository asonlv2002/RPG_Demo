namespace StateContents
{
    using UnityEngine;
    internal class BowAimHolding : BowAttack
    {
        InputMovementAdapter _inputMovement;
        public BowAimHolding(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = Animator.StringToHash("isShootHold");
            _inputMovement = StateContent.GetContentComponent<InputMovementAdapter>();
        }

        public override void EnterState()
        {
            base.EnterState();
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Holding");
        }

        public override void UpdateState()
        {
            if (!InputAttack.IsHolding)
            {
                if (EnterFriendState(BowStore.BowAimReslease)) return;

            }
            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Body.Rotation(_inputMovement.DirectionRotate*0.5f);
        }
        public override void ExitState()
        {
            IsExit = true;
            Debug.Log("Exit Holding");
            animator.SetBool(ActionParameter, !IsExit);
            base.ExitState();
        }
        public override bool ConditionInitChildState()
        {
            return InputAttack.IsHolding;
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.IsHolding;
        }
    }
}
