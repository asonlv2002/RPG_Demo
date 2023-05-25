namespace StateMachine
{
    internal interface IStateAnimationTrigger
    {
        void EnableTrigger(int animationParameter);
        void DisableTrigger(int animationParameter);
    }
}
