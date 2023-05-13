using UnityEngine;

namespace Achitecture
{
    [System.Serializable]
    internal class StepBoxCast
    {
        private bool _isGrouded;
        private bool _isFloatOnGround;
        private bool _isExitGrounded;
        private float _floatDirection;
        private float _angleBodyWitHitGround;
        public void OnRayCast(Vector3 bodyCenter, float distanceRayCast)
        {
            Ray raydownward = new Ray(bodyCenter, Vector3.down);
            var trackingRaycast = Physics.Raycast(raydownward, out RaycastHit hitToGround, distanceRayCast, LayerMask.GetMask("Enviroment"), QueryTriggerInteraction.Ignore);

            CalculateFLoatDirection(bodyCenter.y, hitToGround);
            TrackingExitGroud(!trackingRaycast);
            TrackingIsGrouded(bodyCenter.y, hitToGround);
            TrackingFloatGround();
            CalculateAngle(raydownward, hitToGround);
        }


        void TrackingIsGrouded(float bodyCenter, RaycastHit hitToGound)
        {
            _isGrouded = 1.25f - hitToGound.distance  >= 0f && !_isExitGrounded;
        }

        void TrackingFloatGround()
        {
            _isFloatOnGround = !_isGrouded && !_isExitGrounded;
        }

        void TrackingExitGroud(bool isExitGround)
        {
            _isExitGrounded = isExitGround;
        }

        void CalculateFLoatDirection(float top, RaycastHit hitToGound)
        {
            _floatDirection = 1.25f - hitToGound.distance;
        }
        void CalculateAngle(Ray downward, RaycastHit hitToGround)
        {
            _angleBodyWitHitGround = Vector3.Angle(-downward.direction, hitToGround.normal);
        }
        public bool IsGrounded => _isGrouded;

        public bool IsFloatGround => _isFloatOnGround;

        public bool IsExitGrounded => _isExitGrounded;

        public float FLoatDirection => _floatDirection;

        public float AngleBodyWitHitGround => _angleBodyWitHitGround;

    }
}
