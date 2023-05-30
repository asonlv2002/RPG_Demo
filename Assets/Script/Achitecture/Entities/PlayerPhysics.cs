using UnityEngine;
namespace PhysicContents
{

    internal class PlayerPhysics : PhysicCore
    {
        [SerializeField] PhysicInAir PhysicInAir;
        [SerializeField] PhysicOnGround PhysicOnGround;
        protected override void Awake()
        {
            base.Awake();

            AddContentComponent(PhysicInAir);
            AddContentComponent(PhysicOnGround);

        }

        private void FixedUpdate()
        {
            this.ApplyVelocity();
        }

    }
}
