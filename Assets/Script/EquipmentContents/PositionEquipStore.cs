using UnityEngine;

namespace EquipmentContents
{
    [System.Serializable]
    internal class PositionEquipStore : EquipmentComponent
    {
        [field: SerializeField] public Transform RightHand { get; private set; }
        [field: SerializeField] public Transform LeftHand { get; private set; }
        [field: SerializeField] public Transform Back { get; private set; }
    }
}
