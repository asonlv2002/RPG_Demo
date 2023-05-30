using Achitecture;
using System.Collections.Generic;
namespace StateContents
{
    internal class PlayerStateMachine : StateCore
    {
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            var input = MainCores.GetCore<InputContents.InputCore>();
            var animator = MainCores.GetCore<AnimatorContent.AnimatorCore>();
            var physic = MainCores.GetCore<PhysicContents.PhysicCore>();
            var collider = MainCores.GetCore<ColliderContents.ColliderCore>();
            AddContentComponent(new PhysiscalAdapter(physic));
            AddContentComponent(new BodyAdapter(collider));

            AddContentComponent(new InputMovementAdapter(input));
            AddContentComponent(new ActionRender(animator));

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
    }
}