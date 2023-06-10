namespace ItemInforContents
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections.Generic;
    using TMPro;
    using Item.ItemGameData;

    [System.Serializable]
    internal class ItemEffectsPresentation : ItemInforComponent,ISubOpenItemInformation
    {
        [SerializeField] Transform _effectDirectionContain;
        [SerializeField] TextMeshProUGUI _effectDirectionPrefab;
        [SerializeField] List<TextMeshProUGUI> _effectDirections;
        ItemData currentItemData;
        public void OnOpenItemInformation(ItemData itemData)
        {
            if (currentItemData != null && itemData == currentItemData) return;
            ClearEffect();
            currentItemData = itemData;
            var effects = currentItemData.Effects;
            foreach (var effect in effects.ItemEffects)
            {
                var effectDirection = MonoBehaviour.Instantiate(_effectDirectionPrefab);
                effectDirection.gameObject.SetActive(true);
                effectDirection.transform.SetParent(_effectDirectionContain);
                effectDirection.transform.localScale = Vector3.one;
                effectDirection.SetText(effect.Description);
                _effectDirections.Add(effectDirection);
            }
        }

        void ClearEffect()
        {
            foreach(var effect in _effectDirections)
            {
                MonoBehaviour.Destroy(effect.gameObject);
            }
            _effectDirections = new List<TextMeshProUGUI>();
        }
    }
}
