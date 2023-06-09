namespace OnOffUIContents
{
    using DG.Tweening;
    using UnityEngine;
    [System.Serializable]
    internal class TransfomPresentation
    {
        [SerializeField] RectTransform _transformUI;
        [Header("=== Open ===")]
        [SerializeField] int SiblingIndex;
        [SerializeField] RectTransform _openStateContain;
        [SerializeField] float _durationOpen;
        [SerializeField] Ease _easeOpen;
        [field: SerializeField] public Vector2 StartAnchoredPositionOpen { get; private set; }
        [field: SerializeField] public Vector2 EndAnchoredPositionOpen { get; private set; }


        [Header("=== Close ===")]
        [SerializeField] RectTransform _closeStateContain;
        [SerializeField] float _durationClose;
        [SerializeField] Ease _easeClose;
        [field: SerializeField] public Vector2 EndAnchoredPositionClose { get; private set; }

        public void OnOpen()
        {
            _transformUI.anchorMin = _transformUI.anchorMax = Vector2.one * 0.5f;
            _transformUI.anchoredPosition = StartAnchoredPositionOpen;
            _transformUI.gameObject.SetActive(true);
            _transformUI.DOAnchorPos(EndAnchoredPositionOpen, _durationOpen).SetEase(_easeOpen).OnComplete(() => {
                _transformUI.SetParent(_openStateContain);
                _transformUI.SetSiblingIndex(SiblingIndex);
            });

        }

        public void OnClose()
        {
            _transformUI.SetParent(_closeStateContain);
            var end = _transformUI.anchoredPosition + EndAnchoredPositionClose;
            _transformUI.DOAnchorPos(end, _durationClose).SetEase(_easeClose).OnComplete(() =>
            {
                _transformUI.gameObject.SetActive(false);
            });

        }
    }
}
