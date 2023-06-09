using Achitecture;
using EquipmentContents;
using Item.ItemGameData;

namespace ItemInforContents
{
    internal class CharacterUnequipListener : IConvertItemStationListener
    {
        public void OnConverItemStation(ItemData itemData)
        {
            CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>().UnequipItem(itemData);
        }
    }
}
