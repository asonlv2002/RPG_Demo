using UnityEngine;
using System.Collections.Generic;
using EquipmentContents;
using Achitecture;
using System.Collections;
using Item.InEnviroment;
using System.Threading.Tasks;

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
            InitLate();
        }
        void OnEnterTriggerItem(ItemInEnviroment item)
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

        void OnExitTriggerItem(ItemInEnviroment item)
        {
            var signItem = SignItems.Find(x => x.Item == item);
            if(signItem)
            {
                RemoveSignItem(signItem);
            }
        }

        public override void OnRemoveComponent()
        {
            _triggerItems.OnExitTriggerItem -= OnEnterTriggerItem;
            _triggerItems.OnExitTriggerItem -= OnEnterTriggerItem;
        }


        async void InitLate()
        {
            EquipmentCore equipmentCore = null;
            while (equipmentCore == null)
            {
                equipmentCore = CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>();
                await Task.Delay(1);
            }
            _triggerItems = equipmentCore.GetContentComponent<TriggerItems>();
            _triggerItems.OnEnterTriggerItem += OnEnterTriggerItem;
            _triggerItems.OnExitTriggerItem += OnExitTriggerItem;
        }

        //async void Wait(EquipmentCore equipmentCore)
        //{
        //    while (equipmentCore == null)
        //    {
        //        equipmentCore = CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>();
        //        Debug.Log(2);
        //        await Task.Delay(1);
        //    }
        //    _triggerItems = equipmentCore.GetContentComponent<TriggerItems>();
        //    _triggerItems.OnEnterTriggerItem += OnEnterTriggerItem;
        //    _triggerItems.OnExitTriggerItem += OnExitTriggerItem;
        //}
    }
}
