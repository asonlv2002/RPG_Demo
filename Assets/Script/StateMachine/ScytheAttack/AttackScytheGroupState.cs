namespace StateContents
{
    internal class AttackScytheGroupState : ScytheAttack
    {
        float time;
        ScytheAnimatorControllerAdapter AnimatorController;
        public AttackScytheGroupState(StateCore stateContent) : base(stateContent)
        {
            AnimatorController = stateContent.GetContentComponent<ScytheAnimatorControllerAdapter>();
        }
        public override void EnterState()
        {
            AnimatorController.EnterAttackController();
            base.EnterState();
            time = 2.067f;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            time -= UnityEngine.Time.deltaTime;
        }
        protected override void SwitchToFriendState()
        {
            if(time <=0)
            base.SwitchToFriendState();
        }
        public override bool ConditionEnterState()
        {
            if (childStates.Count <= 0) return false;
            foreach (var _child in childStates)
            {
                if (_child.ConditionInitChildState())
                    return true;
            }

            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}
