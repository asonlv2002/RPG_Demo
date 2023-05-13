using UnityEngine;

namespace Achitecture
{
    internal class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidbody;
        public Rigidbody Physics => _rigidbody;
        [SerializeField] float _maxJumpHeight;
        [SerializeField] float _maxTimeJump;
        [SerializeField] AnimationCurve _speedTemplate;
        [SerializeField] AnimationCurve _floatForceOnGround;
        private Vector3 _velocity;
        private float _gravity = -9.8f;
        private float _groundedGravity = -0.05f;
        private float _initialJumpVelocity;

        public float SpeedMovement;

        public float GroundGravity => _groundedGravity;
        public float Gravity { get => _gravity; set => _gravity = value; }
        public Vector3 VelocityApplie { get => _velocity; set => _velocity = value; }
        public float VelocityY { get => _velocity.y; set => _velocity.y = value; }
        public float VelocityX { get => _velocity.x; set => _velocity.x = value; }
        public float VelocityZ { get => _velocity.z; set => _velocity.z = value; }

        public float InitialJumpVelocity => _initialJumpVelocity;

        private void Awake()
        {
            SetJumpVariabes();
        }
        private void SetJumpVariabes()
        {
            float timeToApex = _maxTimeJump / 2;

            _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);

            _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
        }

        public float GetSpeedOnGroundDenpeden(float angleToGround)
        {
            return _speedTemplate.Evaluate(angleToGround);
        }

        public float GetForceFloatOnGround(float floatDirection)
        {
            return _floatForceOnGround.Evaluate(Mathf.Abs(floatDirection)) * floatDirection;
        }

        public Vector3 GetCurrentPlayerVerticalVelocity() => _rigidbody.velocity;

        public void MovementForceApplie()
        {
            var velocity = VelocityApplie - GetCurrentPlayerVerticalVelocity();
            _rigidbody.AddForce(velocity, ForceMode.VelocityChange);

        }
    }
}
