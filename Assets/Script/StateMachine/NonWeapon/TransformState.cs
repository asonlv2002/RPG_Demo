namespace StateMachine
{
    internal abstract class TransformState : BaseState
    {
        protected ITransformStateStore StateContain;
        protected IStateAnimationIDAdapter AnimationID;
        
        public TransformState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext)
        {
            StateContain = stateTransition;
            AnimationID = (StateContext as IStateAnimationIDProvider).AnimationID;
        }

    }
}
