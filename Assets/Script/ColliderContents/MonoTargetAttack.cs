namespace ColliderContents
{
    using UnityEngine;
    [System.Serializable]
    class MonoTargetAttack : ColliderComponent
    {
        [field : SerializeField] public Transform Target { get; private set; }
    }
}
