

namespace ColliderContents
{
    using UnityEngine;
    [System.Serializable]
    internal class PointWarp : ColliderComponent
    {
        [field : SerializeField] public Transform Point { get; private set; }
    }
}
