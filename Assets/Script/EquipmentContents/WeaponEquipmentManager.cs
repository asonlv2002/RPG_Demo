using UnityEngine;
namespace Item.InEquipment
{
    using EquipmentContents;
    using Item.ItemGameData;

    [System.Serializable]
    internal class WeaponEquipmentManager : IEquipmentManager
    {
        [SerializeField] PlayerEquipment equipemt;
        [field: SerializeField] public Transform RightHand { get; private set; }
        [field: SerializeField] public Transform LeftHand { get; private set; }
        [field: SerializeField] public Transform Back { get; private set; }

        WeaponEquipmentFactory _weaponEquipmentFactory;

        IItem WeaponEquip;
        IItem WeaponUnequip;
       

        public void AddWepon(IItem itemData)
        {
            var weaponData = itemData.ItemData as WeaponData;
            equipemt.channel.EquipWeapon(weaponData);
            WeaponUnequip = new WeaponEquipmentFactory(this).WeaponFactory(weaponData);
            Equip();
            //var weaponEquip = _weaponEquipmentFactory.WeaponFactory(weaponData);
            //(weaponEquip as IItemCreateModel).ItemRenderModel.RenderModel();
        }

        public void Equip()
        {
            WeaponEquip = WeaponUnequip;
            WeaponUnequip = null;
            (WeaponEquip as IItemCreateModel).ItemRenderModel.SetTransForm(Back);
        }

        public void UnEquip()
        {

        }


        public bool IsEquipping => WeaponEquip != null;

        public bool IsUnequipping => WeaponUnequip != null;

        public bool IsWeapon => WeaponEquip != null || WeaponUnequip != null;
    }
}
