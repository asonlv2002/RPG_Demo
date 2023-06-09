using Item.ItemGameData;
using Achitecture;
using EquipmentContents;

namespace ItemInforContents
{
    internal class CharacterEquipListener : IConvertItemStationListener
    {
        public void OnConverItemStation(ItemData itemData)
        {
            CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>().EquiEquipment(itemData);
        }
    }
}
