namespace StateContent
{
    internal class AttackScytheGroupState : ScytheAttack
    {
        public AttackScytheGroupState(IStateContent stateContent) : base(stateContent)
        {

        }

        public override bool ConditionEnterState()
        {
            UnityEngine.Debug.Log(2222222222222);
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
