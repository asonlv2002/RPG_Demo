namespace ItemInforContents 
{
    using Item.ItemGameData;
    using UnityEngine;
    [System.Serializable]
    internal class ButtonPresentation : ItemInforComponent, ISubOpenItemInformation
    {
        [field : SerializeField] public EquipAction EquipAction { get; private set; }
        [field : SerializeField] public UseAction UseAction { get; private set; }

        public void OnOpenItemInformation(ItemData itemData)
        {
            
        }
    }
}
