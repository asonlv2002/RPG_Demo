namespace StateMachine
{
    internal abstract class TransformState : BaseState
    {
        protected ITransformStateStore StateContain;
        protected ITransfomAnimationID AnimationID;
        protected ITransformInput InputTransform;
        
        public TransformState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext)
        {
            StateContain = stateTransition;
            AnimationID = (StateContext as IStateAnimationIDProvider).AnimationIDProvider as ITransfomAnimationID;
            InputTransform = (StateContext as IStateInputProvider).InputProvider as ITransformInput;
        }

    }
}
