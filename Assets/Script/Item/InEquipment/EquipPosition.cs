using UnityEngine;
namespace Item.InEquipment
{
    internal abstract class EquipPosition
    {
        protected IWeaponEquipPosition _providerPosition;

        public EquipPosition(IProviderPosition providerPosition)
        {
            _providerPosition = providerPosition as IWeaponEquipPosition;
        }
    }
}
