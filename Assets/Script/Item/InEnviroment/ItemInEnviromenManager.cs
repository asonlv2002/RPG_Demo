using System.Collections.Generic;
using UnityEngine;
namespace Item.InEnviroment
{
    using ItemGameData;
    internal class ItemInEnviromenManager : MonoBehaviour
    {
        [SerializeField] List<ItemData> ItemDatas;

        [SerializeField] ItemInEnviromentPrefab enviromentPrefab;

        DropItemFactory dropItemFactory;

        private void Start()
        {
            dropItemFactory = new DropItemFactory(enviromentPrefab);
            DropItem();
        }

        void DropItem()
        {
            foreach(var data in ItemDatas)
            {
                var item = Instantiate(dropItemFactory.GetItemInEnviroment(data));
                item.ItemData = data;
                item.gameObject.SetActive(true);
            }
        }
    }
}
