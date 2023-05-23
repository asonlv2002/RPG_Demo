using UnityEngine;

namespace Item.InEquipment
{
    internal interface IWeaponEquipPosition : IProviderPosition
    {
        Transform HandLeft();
        Transform HandRight();
    }
}
