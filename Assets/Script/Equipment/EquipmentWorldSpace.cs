using UnityEngine;
using Equipments.PositionEquipments;
namespace Equipments
{
    internal abstract class EquipmentWorldSpace : MonoBehaviour
    {
        [field : SerializeField] public PositionEquipment PositionEquipment { get; protected set; }
    }
}
