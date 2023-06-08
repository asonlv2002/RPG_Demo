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

        public void OnOpenItemInformation(ItemData itemData)
        {
            var effects = itemData.Effects;
            Debug.Log(effects.ItemEffects.Count);
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
    }
}
