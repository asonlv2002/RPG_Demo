using OnOffUIContents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace ItemInforContents
{
    [System.Serializable]
    internal class OpenCloseItemInfor : ItemInforComponent, IOpenClose
    {
        [SerializeField] ItemInforCores ItemInforCores;
        [field: SerializeField] public TransfomPresentation TransfomPresentation { get; private set; }
        public bool IsOpen  => ItemInforCores.gameObject.activeSelf;
        public UnityAction OnOpenAction { get ; set ; }
        public UnityAction OnCloseAction { get ; set ; }

        [SerializeField] Button _closeUI;


        public override void OnAddComponent()
        {
            _closeUI.onClick.AddListener(CloseAction);
        }
        public void OnClose()
        {
        }

        public void OnOpen()
        {
        }

        public void OpenAction()
        {
            OnOpenAction?.Invoke();
            ItemInforCores.gameObject.SetActive(true);
        }

        public void CloseAction()
        {
            OnCloseAction?.Invoke();
            ItemInforCores.gameObject.SetActive(false);
        }
    }
}
