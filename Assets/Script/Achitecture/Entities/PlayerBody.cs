using UnityEngine;
using Extension;
namespace Achitecture
{
    internal class PlayerBody : MonoBehaviour
    {
        [field: SerializeField] public CapsuleCollider CapsuleCollider { get; private set; }
        [field: SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }
        [field: SerializeField] public SlopeData SlopeData { get; private set; }
        [field: SerializeField] public StepBoxCast TrackingBodyOnGround { get; private set; }


        public Vector3 CenterCapsuleInLocalSpace => CapsuleCollider.center;
        public Vector3 CenterCapsuleInWorldSpace => CapsuleCollider.bounds.center;

        private void OnValidate()
        {
            CalculateCapsuleColliderDimensions();
        }
        private void Update()
        {
            TrackingBodyOnGround.OnRayCast(CenterCapsuleInWorldSpace+ Vector3.down, SlopeData.RayDistance);
        }
        private void FixedUpdate()
        {
            
        }

        public void CalculateCapsuleColliderDimensions()
        {
            SetCapsuleColliderRadius(DefaultColliderData.Radius);
            SetCaptureCollierHeight(DefaultColliderData.Height *(1 - SlopeData.StepHeight));
            ReclationCapsuleColliderCenter();
            float halfCapsule = CapsuleCollider.height / 2f;
            if (halfCapsule < CapsuleCollider.radius)
            {
                SetCapsuleColliderRadius(halfCapsule);
            }
        }

        private void SetCaptureCollierHeight(float height)
        {
            CapsuleCollider.height = height;
        }

        private void SetCapsuleColliderRadius(float radius)
        {
            CapsuleCollider.radius = radius;
        }
        private void ReclationCapsuleColliderCenter()
        {
            float colliderHeightDeffernce = DefaultColliderData.Height - CapsuleCollider.height;
            float newCenterY = DefaultColliderData.CenterY + colliderHeightDeffernce / 2;
            CapsuleCollider.center = Vector3.up * newCenterY;
        }

    }
}
