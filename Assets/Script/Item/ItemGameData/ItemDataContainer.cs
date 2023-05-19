using UnityEngine;
namespace Item.ItemGameData
{
    class ItemDataContainer : MonoBehaviour
    {
        public static ItemDataContainer Intance;
        [field: SerializeField] public EquipmentDataContainer EquipmentDatas;

        private void Awake()
        {
            Intance = this;
        }

    }
}
