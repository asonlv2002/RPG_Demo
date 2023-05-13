using UnityEngine;

namespace Physical
{
    [System.Serializable]
    internal class PhysiscVariable
    {
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float SprintSpeed { get; private set; }
        [field: SerializeField] public float Gravity { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }

        [field: SerializeField] public float ConstFeet { get; private set; }
    }
}
