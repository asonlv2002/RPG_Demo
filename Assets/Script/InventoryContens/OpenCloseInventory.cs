
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
        [field: SerializeField] public TransfomPresentation TransfomPresentation { get; private set; }
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

        public void OpenAction()
        {
            if (IsOpen) return;
            _openInventory.gameObject.SetActive(false);
            OnOpenAction?.Invoke();
            TransfomPresentation.OnOpen();
        }
        public void CloseAction()
        {
            _openInventory.gameObject.SetActive(true);
            TransfomPresentation.OnClose();
            OnCloseAction?.Invoke();

        }
    }
}
