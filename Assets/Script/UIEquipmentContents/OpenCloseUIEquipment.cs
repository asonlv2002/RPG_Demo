using OnOffUIContents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace UIEquipmentContents
{
    [System.Serializable]
    class OpenCloseUIEquipment : UIEquipmentComponent, IOpenClose
    {
        [SerializeField] UIEquipmentCores UIEquipmentCores;
        public bool IsOpen => UIEquipmentCores.gameObject.activeSelf;
        public UnityAction OnOpenAction { get ; set ; }
        public UnityAction OnCloseAction { get ; set; }

        [SerializeField] Button _openEquipment;
        [SerializeField] Button _closeEquipment;

        public override void OnAddComponent()
        {
            _openEquipment?.onClick.AddListener(OpenAction);
            _closeEquipment?.onClick.AddListener(CloseAction);
        }
        public void OnClose()
        {
            
        }

        public void OnOpen()
        {
            
        }

        public void OpenAction()
        {
            OnOpenAction.Invoke();
            UIEquipmentCores.gameObject.SetActive(true);
        }

        public void CloseAction()
        {
            UIEquipmentCores.gameObject.SetActive(false);
            OnCloseAction.Invoke();

        }
    }
}
