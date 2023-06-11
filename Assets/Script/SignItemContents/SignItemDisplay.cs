using Item.ItemGameData;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InventoryContents;
using Item.InEnviroment;

namespace SignItemContents
{
    internal class SignItemDisplay : MonoBehaviour
    {
        [SerializeField] Button _addItem;
        [SerializeField] Button _removeItem;
        [SerializeField] Image _icon;
        [SerializeField] TextMeshProUGUI _name;
        [SerializeField] SignItemCores _signItemCores;
        public ItemInEnviroment Item { get; private set; }

        public void InitSignItem(ItemInEnviroment item)
        {
            Item = item;
            _icon.sprite = Item.ItemData.Information.Sprite;
            _name.text = Item.ItemData.Information.Name;
            _addItem.onClick.AddListener(AddItem);
        }

        void AddItem()
        {
            _signItemCores.MainCores.GetCore<InventoryCore>().GetContentComponent<ItemInventoryStore>().AddItemData(Item.ItemData);
            _signItemCores.GetContentComponent<SignItemStore>().RemoveSignItem(this);
            MonoBehaviour.Destroy(Item.gameObject);
        }    
    }
}
