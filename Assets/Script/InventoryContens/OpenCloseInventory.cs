
using OnOffUIContents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace InventoryContents
{
    [System.Serializable]
    internal class OpenCloseInventory : InventoryComponent, IOpenClose
    {
        [SerializeField] InventoryCore InventoryCore;
        public bool IsOpen => InventoryCore.gameObject.activeSelf;
        public UnityAction OnOpenAction { get ; set ; }
        public UnityAction OnCloseAction { get ; set ; }

        [SerializeField] Button _openInventory;
        [SerializeField] Button _closeInventory;

        public override void OnAddComponent()
        {
            _openInventory?.onClick.AddListener(OpenAction);
            _closeInventory?.onClick.AddListener(CloseAction);
        }

        public void OnOpen()
        {
        }

        public void OnClose()
        {
        }


        public void OpenAction()
        {
            InventoryCore.gameObject.SetActive(true);
            OnOpenAction?.Invoke();
        }
        public void CloseAction()
        {
            InventoryCore.gameObject.SetActive(false);
            OnCloseAction?.Invoke();

        }
    }
}
