
using OnOffUIContents;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

namespace QuickUseItemContents
{
    [System.Serializable]
    internal class OpenCloseQuickUseItem : QuickUseComponent, IOpenClose
    {
        [SerializeField] QuickUseCores QuickUseCores;
        [SerializeField] Button _openAction;
        [SerializeField] Button _closeAction;
        public bool IsOpen => QuickUseCores.gameObject.activeSelf;

        [field : SerializeField] public TransfomPresentation TransfomPresentation { get; private set; }

        public UnityAction OnOpenAction { get ; set ; }
        public UnityAction OnCloseAction { get; set; }


        public override void OnAddComponent()
        {
            _openAction.onClick.AddListener(OpenAction);
            _closeAction.onClick.AddListener(CloseAction);

        }
        public void OnClose()
        {
            
        }

        public void OnOpen()
        {

        }

        public void OpenAction()
        {
            _openAction.gameObject.SetActive(false);
            TransfomPresentation.OnOpen();
        }

        public void CloseAction()
        {
            _openAction.gameObject.SetActive(true);
            TransfomPresentation.OnClose();
        }
    }
}
