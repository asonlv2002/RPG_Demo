using UnityEngine;
using System.Collections.Generic;
namespace StateContent
{
    internal class PlayerStateMachine : Entities.BranchContent,IStateContent
    {
        protected List<StateComponent> stateComponents;
        
        public IState CurrentState { get ; set ; }

        public override void InitMainContent(Entities.PlayerRootContent mainContent)
        {
            base.InitMainContent(mainContent);
            stateComponents = new List<StateComponent>();
            AddContentComponent(new PhysiscalAdapter(MainContent.Physiscal));
            AddContentComponent(new BodyAdapter(MainContent.Body));

            AddContentComponent(new InputMovementAdapter(MainContent.InputAction));
            AddContentComponent(new ActionRender(MainContent.Animator));
            AddContentComponent(new MovementStateStore(this));
            CurrentState = GetContentComponent<MovementStateStore>().Movement;
            CurrentState.EnterState();
        }

        private void Update()
        {
            CurrentState.UpdateState();
        }

        private void FixedUpdate()
        {
            CurrentState.FixedUpdateState();
        }

        public T GetContentComponent<T>() where T : StateComponent
        {
            foreach(var component in stateComponents)
            {
                if(component is T)
                    return component as T;
            }

            return null;
        }

        public void AddContentComponent(StateComponent component)
        {
            stateComponents.Add(component);
        }
    }
}
