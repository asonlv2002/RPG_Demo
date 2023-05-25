using UnityEngine;
namespace StateMachine
{
    internal class PlayerStateMachine : Entities.BranchContent
    {
        IStateContext stateContext;
        public override void InitMainContent(Entities.PlayerRootContent mainContent)
        {
            base.InitMainContent(mainContent);
            stateContext = new StateContext(MainContent);

        }
        private void Awake()
        {

        }
        

        private void Update()
        {
            stateContext.CurrentState.UpdateState();
        }

        private void FixedUpdate()
        {
            stateContext.CurrentState.FixedUpdateState();
        }

    }
}
