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
        //void GroundCheck()
        //{
        //    RaycastHit hit;
        //    float distance = 1f;
        //    Vector3 dir = new Vector3(0, -1);

        //    if (Physics.Raycast(transform.position, dir, out hit, distance))
        //    {
        //        isGrounded = true;
        //    }
        //    else
        //    {
        //        isGrounded = false;
        //    }
        //}
    }
}
