using UnityEngine;
namespace Achitecture
{
    internal class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] CapsuleCollider _colider;
        private bool _isGrounded;
        public Rigidbody Physics => _rigidbody;
        public CapsuleCollider Body => _colider;
        public bool IsGrounded => _isGrounded;

        private void OnCollisionEnter(Collision collision)
        {
            _isGrounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            _isGrounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            _isGrounded = true;
        }
    }
}
