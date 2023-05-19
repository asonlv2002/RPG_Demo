
namespace ItemAdapter
{
    internal interface IItemAdapter
    {
        T TakeItemInformationID<T>() where T : Item.ItemGameData.WeaponData;
    }
}
