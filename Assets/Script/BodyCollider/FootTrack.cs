using UnityEngine;

namespace BodyCollider
{
    [System.Serializable]
    internal class FeetTrack
    {
        private bool _isOnGroud;
        private bool _isFloatOnGround;
        private bool _isTerrestrial;
        private float _floatDirection;
        private float _angleFeetGround;
        private float _bodyCenter;
        public bool IsOnGround => _isOnGroud;

        public bool IsFloatGround => _isFloatOnGround;

        public bool IsTerrestrial => _isTerrestrial;

        public float FLoatDirection => _floatDirection;

        public float AngleFeetGround => _angleFeetGround;


        public void OnRayCast(Vector3 bodyCenter, float distanceRayCast)
        {
            Ray raydownward = new Ray(bodyCenter, Vector3.down);
            _isTerrestrial = Physics.Raycast(raydownward, out RaycastHit hitToGround, distanceRayCast, LayerMask.GetMask("Enviroment"), QueryTriggerInteraction.Ignore);
            TrackingFeetIsGrouded(hitToGround);
            CalculateFLoatDirection(hitToGround);
            CalculateAngle(raydownward, hitToGround);
        }

        public void GetBodyCenter(float value) => _bodyCenter = value;
        void TrackingFeetIsGrouded(RaycastHit hitToGound)
        {
            _isOnGroud = (_bodyCenter - hitToGound.distance)  >= 0f && _isTerrestrial;
        }

        void CalculateFLoatDirection(RaycastHit hitToGound)
        {
            _floatDirection = _isTerrestrial ? (_bodyCenter - hitToGound.distance) : 0;
        }
        void CalculateAngle(Ray downward, RaycastHit hitToGround)
        {
            if (_isTerrestrial) return;
            _angleFeetGround = Vector3.Angle(-downward.direction, hitToGround.normal);
        }


    }
}
