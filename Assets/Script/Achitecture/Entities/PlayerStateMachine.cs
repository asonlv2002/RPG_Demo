using Achitecture;
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
            var equipmen = MainCores.GetCore<EquipmentContents.EquipmentCore>();
            AddContentComponent(new PhysiscalAdapter(physic));
            AddContentComponent(new BodyAdapter(collider));

            AddContentComponent(new InputMovementAdapter(input));
            AddContentComponent(new MovementAnimatorControllerAdapter(animator));
            AddContentComponent(new AttackControllerAdapter(animator));
            AddContentComponent(new ActionRender(animator));
            AddContentComponent(new StatusEquipAdapter(equipmen));

            AddContentComponent(new MovementStateStore(this));
            var sate = GetContentComponent<MovementStateStore>().Movement;
            EnterNextState(sate);
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