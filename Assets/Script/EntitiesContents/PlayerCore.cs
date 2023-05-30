using UnityEngine;
namespace Achitecture
{
    using StateContents;
    using PhysicContents;
    using ColliderContents;
    using AnimatorContent;
    using InputContents;
    using EquipmentContents;
    internal class PlayerCore : MainCores
    {
        [SerializeField] StateCore StateMachine;
        [SerializeField] PhysicCore Physic;
        [SerializeField] ColliderCore Body;
        [SerializeField] AnimatorCore Animator;
        [SerializeField] InputCore InputAction;
        [SerializeField] EquipmentCore Equipment;

        private void Start()
        {
            AddCore(StateMachine);
            AddCore(Physic);
            AddCore(Body);
            AddCore(Animator);
            AddCore(InputAction);
            AddCore(Equipment);

            Equipment.InitMainCore(this);
            InputAction.InitMainCore(this);
            Animator.InitMainCore(this);
            Physic.InitMainCore(this);
            StateMachine.InitMainCore(this);
        }
    }
}
