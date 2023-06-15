using UnityEngine;
namespace EquipmentContents
{
    using Item;
    using Item.InEquipment;

    using Item.ItemGameData;

    [System.Serializable]
    internal class WeaponEquipmentManager :EquipmentComponent
    {
        [SerializeField] EquipmentCore _equipmentCore;
        PositionEquipStore _positionEquipStore;
        ComponentOnEquipWeaponSetter _componentSetter;
        WeaponEquipmentFactory _weaponEquipFactory;
        IItem WeaponEquip;
        IItem WeaponUnequip;

        WeaponData currentWeaponData;
        public override void OnAddComponent()
        {
            _positionEquipStore = _equipmentCore.GetContentComponent<PositionEquipStore>();
            _componentSetter = new ComponentOnEquipWeaponSetter(_equipmentCore.MainCores);
            _weaponEquipFactory = new WeaponEquipmentFactory(_positionEquipStore);
        }
        public void AddWepon(ItemData itemData)
        {
            if (currentWeaponData == itemData as WeaponData) return;
            currentWeaponData = itemData as WeaponData;
            _componentSetter.EquipWeapon(currentWeaponData);
            WeaponUnequip = _weaponEquipFactory.WeaponFactory(currentWeaponData);
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
            WeaponUnequip = WeaponEquip;
            WeaponEquip = null;
            (WeaponUnequip as IItemCreateModel).ItemRenderModel.SetTransForm(_positionEquipStore.Back);
        }

        public void RemoveWeapon()
        {
            if (!currentWeaponData) return;
            _componentSetter.RemoveWeapon();
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
