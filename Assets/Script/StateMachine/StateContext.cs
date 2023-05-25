
namespace StateMachine
{
    internal class StateContext : IStateContext, IStatePhysiscalProvider, IStateBodyProvider, IStateInputProvider,IStateAnimationIDProvider
    {
        public IStateContain StateProvider { get; private set; }
        public IStateBodyAdapter Body { get; private set; }
        public IStateInputAdapter Input { get; private set; }
        public IState CurrentState { get; set ; }
        public IStateAnimationIDAdapter AnimationID { get; private set; }
        public IStatePhysicAdapter Physiscal { get; private set; }

        public StateContext(Entities.PlayerRootContent mainContext)
        {
            Physiscal = new StatePhysicAdapter(mainContext.Physiscal);
            Input = new StateInputAdapter(mainContext.InputAction);
            Body = new StateBodyAdapter(mainContext.Body);
            AnimationID = new AnimationParameterUnequipIntance(mainContext.Animator);
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
