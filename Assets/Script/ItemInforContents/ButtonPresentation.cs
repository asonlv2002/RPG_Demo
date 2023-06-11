namespace ItemInforContents 
{
    using Item.ItemGameData;
    using UnityEngine;
    [System.Serializable]
    internal class ButtonPresentation : ItemInforComponent, ISubOpenItemInformation
    {
        [SerializeField] ItemInforCores ItemInforCores;
        [field : SerializeField] public EquipAction Equip { get; private set; }
        [field : SerializeField] public UnequipAction Unequip { get; private set; }
        [field : SerializeField] public UseAction UseAction { get; private set; }
        [field : SerializeField] public AddQuickUseAction AddQuickUseAction { get; private set; }

        public override void OnAddComponent()
        {
            Init(ItemInforCores);
        }

        public void Init(ItemInforCores itemInforCores)
        {
            Equip.Init(itemInforCores);
            Unequip.Init(itemInforCores);
            UseAction.Init(itemInforCores);
            AddQuickUseAction.Init(itemInforCores);
        }

        public void OnOpenItemInformation(ItemData itemData)
        {
            
        }
    }
}
