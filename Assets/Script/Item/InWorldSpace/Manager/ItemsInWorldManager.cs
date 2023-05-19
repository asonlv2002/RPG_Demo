using UnityEngine;
using Item.ItemGameData;
namespace Item.InWorldSpace
{
    internal class ItemsInWorldManager : MonoBehaviour
    {
        //[field: SerializeField] public WeaponManager WeaponManager { get; private set; }

        //private void Awake()
        //{
        //    WeaponManager = new WeaponManager();
        //}
        public ItemDataContainer ItemDataContainer;
        public ItemWorldController ItemController;

        private void Start()
        {
            var clone = Instantiate(ItemController);
            var weapon = ItemDataContainer.EquipmentDatas.WeaponDatas.Weapons[0];
            clone.OnCreate(weapon.Information, weapon.Model);
        }
    }
}
