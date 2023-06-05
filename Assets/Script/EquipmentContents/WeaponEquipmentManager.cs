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
            (WeaponEquip as IItemCreateModel).ItemRenderModel.OnEquipWeapon();

        }

        public void UnEquip()
        {
            equipemt.channel.RemoveWeapon();
            (WeaponEquip as IItemCreateModel).ItemRenderModel.SetTransForm(null);
            WeaponUnequip = null;
            WeaponEquip = null;
            currentWeaponData = null;   
            //WeaponUnequip = WeaponEquip;
            //WeaponEquip = null;
            //(WeaponUnequip as IItemCreateModel).ItemRenderModel.SetTransForm(Back);
        }

        public void RemoveWeapon()
        {
            equipemt.channel.RemoveWeapon();
            (WeaponEquip as IItemCreateModel).ItemRenderModel.SetTransForm(null);
            WeaponUnequip = null;
            WeaponEquip = null;
            currentWeaponData = null;
        }

        public bool IsEquipping => WeaponEquip != null && WeaponUnequip == null;

        public bool IsUnequipping => WeaponEquip == null && WeaponUnequip != null;

        public bool IsWeapon => WeaponEquip != null || WeaponUnequip != null;
    }
}
