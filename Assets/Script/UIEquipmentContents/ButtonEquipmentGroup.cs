namespace UIEquipmentContents
{
    using UnityEngine;
    [System.Serializable]
    class ButtonEquipmentGroup : UIEquipmentComponent
    {
        [SerializeField] UIEquipmentCores UIEquipmentCores;
        [SerializeField] WeaponButton Weapon;


        public void Init()
        {
            Weapon.SetCore(UIEquipmentCores);
        }
    }
}
