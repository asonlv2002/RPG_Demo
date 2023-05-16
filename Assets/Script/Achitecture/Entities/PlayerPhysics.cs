using UnityEngine;
namespace Physical
{

    internal class PlayerPhysics : Entities.BranchContent
    {
        [field: SerializeField] public Rigidbody PhysiscHandler { get; private set; }
        [field: SerializeField] public PhysiscVariable PhysiscVariable { get; private set; }
        [SerializeField] AnimationCurve _speedTemplate;
        private Vector3 _velocity;
        public Vector3 VelocityApplie { get => _velocity; set => _velocity = value; }
        public float Y_VelocityApplie { get => _velocity.y; set => _velocity.y = value; }
        public float X_VelocityApplie { get => _velocity.x; set => _velocity.x = value; }
        public float Z_VelocityApplie { get => _velocity.z; set => _velocity.z = value; }

        public float GetSpeedOnGroundDenpeden(float angleToGround)
        {
            return _speedTemplate.Evaluate(angleToGround);
        }

        public Vector3 GetCurrentPlayerVerticalVelocity() => PhysiscHandler.velocity;

        public void MovementForceApplie()
        {
            var velocity = VelocityApplie - GetCurrentPlayerVerticalVelocity();
            PhysiscHandler.AddForce(velocity, ForceMode.VelocityChange);

        }
    }
}
