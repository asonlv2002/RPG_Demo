namespace ColliderContents
{
    using UnityEngine;
    [System.Serializable]
    internal class TransFormContent : ColliderComponent
    {
        [field: SerializeField] public Transform PlayerTransform { get; private set; }
        [SerializeField] float _speedRotation;
        public void Rotation(float directionRotation)
        {
            PlayerTransform.Rotate(Vector3.up *_speedRotation * directionRotation* Time.fixedDeltaTime);
        }
    }
}
