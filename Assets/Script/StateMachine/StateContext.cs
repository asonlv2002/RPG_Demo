
namespace StateMachine
{
    internal class StateContext : IStateContext, IStatePhysiscalProvider, IStateBodyProvider, IStateInputProvider,IStateAnimationIDProvider
    {
        public StateContain StateProvider { get; private set; }
        public IState CurrentState { get; set; }
        public IStateBodyAdapter Body { get; private set; }
        public IStatePhysicAdapter PhysiscalProvider { get; private set; }
        public StateInputAdapter InputProvider { get; private set; }
        public AnimationIDAdapter AnimationIDProvider { get; private set; }


        public StateContext(Entities.PlayerRootContent mainContext)
        {
            PhysiscalProvider = new StatePhysicAdapter(mainContext.Physiscal);
            InputProvider = new StateInputUnequipAdapter(mainContext.InputAction);
            Body = new StateBodyAdapter(mainContext.Body);
            AnimationIDProvider = new AnimationIdUnequipStore(mainContext.Animator);
            StateProvider = new StateContainIntance(this);
            SetUpState();
        }
        void SetUpState()
        {
            CurrentState = (StateProvider as ITransformStateStore).Movement;
            CurrentState.EnterState();
        }
    }
}
