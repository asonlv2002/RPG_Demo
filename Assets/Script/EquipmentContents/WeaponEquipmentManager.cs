using UnityEngine;
namespace EquipmentContents
{
    using Item;
    using Item.InEquipment;

    using Item.ItemGameData;

    [System.Serializable]
    internal class WeaponEquipmentManager :EquipmentComponent, IEquipmentManager
    {
        [SerializeField] PlayerEquipment equipemt;
        [field: SerializeField] public Transform RightHand { get; private set; }
        [field: SerializeField] public Transform LeftHand { get; private set; }
        [field: SerializeField] public Transform Back { get; private set; }

        WeaponEquipmentFactory _weaponEquipmentFactory;

        IItem WeaponEquip;
        IItem WeaponUnequip;

        WeaponData currentWeaponData;
        public void AddWepon(IItem itemData)
        {
            if (currentWeaponData == itemData.ItemData as WeaponData) return;
            currentWeaponData = itemData.ItemData as WeaponData;
            equipemt.channel.EquipWeapon(currentWeaponData);
            WeaponUnequip = new WeaponEquipmentFactory(this).WeaponFactory(currentWeaponData);
            Equip();
        }

        public void Equip()
        {
            WeaponEquip = WeaponUnequip;
            WeaponUnequip = null;
            (WeaponEquip as IItemCreateModel).ItemRenderModel.SetTransForm(RightHand);

        }

        public void UnEquip()
        {
            WeaponUnequip = WeaponEquip;
            WeaponEquip = null;
            (WeaponUnequip as IItemCreateModel).ItemRenderModel.SetTransForm(Back);
        }


        public bool IsEquipping => WeaponEquip != null;

        public bool IsUnequipping => WeaponEquip == null;

        public bool IsWeapon => WeaponEquip != null || WeaponUnequip != null;
    }
}
