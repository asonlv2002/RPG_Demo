using UnityEngine;
namespace BodyCollider
{
    [System.Serializable]
    internal class CapsuleColliderData
    {
        #region Private Veriable
        [SerializeField] private CapsuleCollider _collider;
        private Vector3 _centerCapsuleInLocalSpace;
        #endregion

        #region Public Veriable
        public CapsuleCollider Collider => _collider;
        public Vector3 CenterCapsuleInLocalSpace => _collider.center;
        public Vector3 CenterCapsuleInWorldSpace => _collider.bounds.center;
        #endregion


        public void UpdateColliderData()
        {
            _centerCapsuleInLocalSpace = _collider.center;
        }

        public void SetRadius(float value)
        {
            _collider.radius = value;
        }

        public void SetCenter(float value) => _collider.center = value * Vector3.up;

        public void SetHeight(float value) => _collider.height = value;
    }
}
