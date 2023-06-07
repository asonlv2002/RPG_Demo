using UnityEngine;
namespace Achitecture
{
    using StateContents;
    using PhysicContents;
    using ColliderContents;
    using AnimatorContent;
    using InputContents;
    using EquipmentContents;
    using StatContents;
    internal class PlayerCore : MainCores
    {
        [SerializeField] StateCore StateMachine;
        [SerializeField] PhysicCore Physic;
        [SerializeField] ColliderCore Body;
        [SerializeField] AnimatorCore Animator;
        [SerializeField] InputCore InputAction;
        [SerializeField] EquipmentCore Equipment;
        [SerializeField] StatCore Stat;

        private void Start()
        {
            AddCore(StateMachine);
            AddCore(Physic);
            AddCore(Body);
            AddCore(Animator);
            AddCore(InputAction);
            AddCore(Stat);
            AddCore(Equipment);

            Equipment.InitMainCore(this);
            InputAction.InitMainCore(this);
            Physic.InitMainCore(this);
            Body.InitMainCore(this);
            Animator.InitMainCore(this);
            Stat.InitMainCore(this);
            StateMachine.InitMainCore(this);
        }

    }
}
