namespace OnOffUIContents
{
    using UnityEngine;
    [System.Serializable]
    internal class TransfomPresentation
    {
        [SerializeField] int IndexOnOpen;
        [SerializeField] RectTransform _closeStateContain;
        [SerializeField] RectTransform _openStateContain;
        [SerializeField] RectTransform _transformUI;

        public void OnOpen()
        {
            _transformUI.SetParent(_openStateContain);
            _transformUI.SetSiblingIndex(IndexOnOpen);
        }

        public void OnClose()
        {
            _transformUI.SetParent(_closeStateContain);
        }
    }
}
