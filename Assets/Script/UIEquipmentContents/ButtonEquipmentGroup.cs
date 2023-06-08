namespace UIEquipmentContents
{
    using UnityEngine;
    [System.Serializable]
    class ButtonEquipmentGroup : UIEquipmentComponent
    {
        [SerializeField] UIEquipmentCores UIEquipmentCores;
        [field :SerializeField] public WeaponButton Weapon { get; private set; }


        public void Init()
        {
            Weapon.SetCore(UIEquipmentCores);
        }
    }
}
