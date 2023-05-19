using UnityEngine;
using Item.InWorldSpace;
using Item.ItemGameData;
namespace Item.InEquipment
{
    [System.Serializable]
    internal class WeaponEquipment
    {
        [field: SerializeField] public Transform HandLeft { get; private set; }
        [field: SerializeField] public Transform HandRight { get; private set; }


        WeaponBeHaviourFactory _weaponBehaviourFActory;
        WeaponBehaviour _curentWeaponBehaviour;
        WeaponInWorldSpace curentWeaponEquipment;

        public WeaponEquipment()
        {
            _weaponBehaviourFActory = new WeaponBeHaviourFactory();
        }

        public void EquipWeaponInWorldSpace(ItemAdapter.IItemAdapter  adapter)
        {
            var weapon = adapter.TakeItemInformationID<WeaponData>();

            Debug.Log(weapon.Information.IDItem);
            GameObject weaponObject = MonoBehaviour.Instantiate(weapon.Model.Prefab, HandRight);

            Transform weaponTrasform = weaponObject.transform;
            weaponTrasform.localPosition = Vector3.zero;
        }
    }
}
