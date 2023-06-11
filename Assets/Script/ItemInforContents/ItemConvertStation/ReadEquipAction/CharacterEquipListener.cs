using Item.ItemGameData;
using Achitecture;
using EquipmentContents;

namespace ItemInforContents
{
    internal class CharacterEquipListener : IConvertItemStationListener
    {
        EquipEquipmentControl _equipEquipment;
        public void OnConverItemStation(ItemData itemData)
        {
            LateInit();
            _equipEquipment.EquipEquipment(itemData);
        }

        void LateInit()
        {
            if(_equipEquipment == null)
            {
                _equipEquipment = CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>().GetContentComponent<EquipEquipmentControl>();
            }
        }
    }
}
