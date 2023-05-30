using UnityEngine;
namespace ColliderContents
{
    [System.Serializable]
    internal class CalculateCapsuleUtility
    {
        [field : SerializeField] public CapsuleColliderData CapsuleColliderData { get; private set; }
        [field : SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }
        [field : SerializeField] public SlopeData SlopeData { get; private set; }


        public void CalculateCapsuleColliderDimensions()
        {
            if (CapsuleColliderData.Collider == null) return;
            SetCapsuleColliderRadius(DefaultColliderData.Radius);
            SetCaptureCollierHeight(DefaultColliderData.Height*(1- SlopeData.StepHeight));
            ReclationCapsuleColliderCenter();
            float halfCapsule = CapsuleColliderData.Collider.height / 2f;
            if (halfCapsule < CapsuleColliderData.Collider.radius)
            {
                SetCapsuleColliderRadius(halfCapsule);
            }
            CapsuleColliderData.UpdateColliderData();
        }

        private void SetCaptureCollierHeight(float height)
        {
            CapsuleColliderData.SetHeight(height);
        }

        public void SetCapsuleColliderRadius(float radius)
        {
            CapsuleColliderData.SetRadius(radius);
        }

        public void ReclationCapsuleColliderCenter()
        {
            float colliderHeightDeffernce = DefaultColliderData.Height - CapsuleColliderData.Collider.height;
            float newCenterY = DefaultColliderData.CenterY + colliderHeightDeffernce / 2;
            CapsuleColliderData.SetCenter(newCenterY);
        }


    }
}
