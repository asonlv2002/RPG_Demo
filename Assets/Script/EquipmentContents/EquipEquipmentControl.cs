using Item.ItemGameData;

namespace EquipmentContents
{
    internal class EquipEquipmentControl : EquipmentComponent
    {
        EquipmentCore _equipmentCore;
        WeaponEquipmentManager _weponEquipment;
        
        public EquipEquipmentControl(EquipmentCore equipmentCore)
        {
            _equipmentCore = equipmentCore;
            _weponEquipment = _equipmentCore.GetContentComponent<WeaponEquipmentManager>();
        }

        public void EquipEquipment(ItemData itemData)
        {
            switch(itemData)
            {
                case WeaponData:
                    _weponEquipment.AddWepon(itemData);
                    break;
            }

            EnableEffectItem(itemData);
        }

        public void UnequipEquipment(ItemData itemData)
        {
            DisableEffect(itemData);
            _weponEquipment.RemoveWeapon();
        }

        void EnableEffectItem(ItemData itemData)
        {
            foreach(var effect in itemData.Effects.ItemEffects)
            {
                effect.EnableEffect(_equipmentCore.MainCores);
            }
        }

        void DisableEffect(ItemData itemData)
        {
            foreach (var effect in itemData.Effects.ItemEffects)
            {
                effect.DisableEffect(_equipmentCore.MainCores);
            }
        }



    }
}
