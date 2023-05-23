using System.Collections.Generic;
using UnityEngine;
using Item.Type;
namespace Item.InEquipment
{
    internal class WeaponPrefabFactory
    {
        private IStoreWeapon _storeWeapon;
        public WeaponPrefabFactory(IStoreWeapon storeWeapon)
        {
            _storeWeapon = storeWeapon;
        }


    }
}
