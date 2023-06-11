using Item.ItemGameData;
using UnityEngine;
using System.Collections.Generic;
using EquipmentContents;
using Achitecture;
using System.Collections;
using Item;

namespace SignItemContents
{
    [System.Serializable]
    internal class SignItemStore : SignItemComponent
    {
        [SerializeField] RectTransform _contain;
        List<SignItemDisplay> SignItems = new List<SignItemDisplay>();
        [SerializeField] SignItemDisplay _signItemPrefab;
        [SerializeField] SignItemCores _signItemCores;
        TriggerItems _triggerItems;
        public override void OnAddComponent()
        {
            _signItemCores.StartCoroutine(InitLate());
        }
        void OnEnterTriggerItem(IItem item)
        {
            if(SignItems.Count == 0) _signItemCores.gameObject.SetActive(true);
            var signItem = MonoBehaviour.Instantiate(_signItemPrefab, _contain);
            signItem.InitSignItem(item);
            AddSignItem(signItem);
        }

        public void RemoveSignItem(SignItemDisplay signItem)
        {
            SignItems.Remove(signItem);
            MonoBehaviour.Destroy(signItem.gameObject);
            if (SignItems.Count == 0)
            {
                _signItemCores.gameObject.SetActive(false);
            }
        }
        public void AddSignItem(SignItemDisplay signItem)
        {
            signItem.gameObject.SetActive(true);
            SignItems.Add(signItem);
        }

        void OnExitTriggerItem(IItem item)
        {
            var signItem = SignItems.Find(x => x.Item == item);
            if(signItem)
            {
                RemoveSignItem(signItem);
            }
        }

        IEnumerator InitLate()
        {
            yield return new WaitUntil(() =>GetItemTrigger(CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>(),out _triggerItems));
            _triggerItems.OnEnterTriggerItem += OnEnterTriggerItem;
            _triggerItems.OnExitTriggerItem += OnExitTriggerItem;
        }

        public override void OnRemoveComponent()
        {
            _triggerItems.OnExitTriggerItem -= OnEnterTriggerItem;
            _triggerItems.OnExitTriggerItem -= OnEnterTriggerItem;
        }

        bool GetItemTrigger(EquipmentCore equipmentCore, out TriggerItems triggerItems)
        {
            triggerItems = null;
            if (!equipmentCore) return false;

            return (triggerItems = equipmentCore.GetContentComponent<TriggerItems>()) != null;
        }
    }
}
