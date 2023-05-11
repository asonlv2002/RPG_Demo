using UnityEngine;

namespace Extension
{
    [System.Serializable]
    internal class SlopeData
    {
        [field: SerializeField][field: Range(0, 1f)] public float StepHeightPercentage { get; private set; } = 0.25f;
        [field: SerializeField] public float RayDistance { get; private set; } = 2f;
    }
}


