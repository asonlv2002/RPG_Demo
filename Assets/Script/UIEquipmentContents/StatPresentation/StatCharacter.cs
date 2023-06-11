namespace UIEquipmentContents
{
    using UnityEngine;
    using System.Collections;
    using StatContents;
    using Achitecture;
    using System.Threading.Tasks;
    using System;

    [System.Serializable]
    internal class StatCharacter : UIEquipmentComponent
    {
        [SerializeField] UIEquipmentCores _UIEquipmentCores;
        [SerializeField] BaseStatPresentation Hp;
        [SerializeField] BaseStatPresentation Mp;
        [SerializeField] BaseStatPresentation Atk;
        [SerializeField] BaseStatPresentation Def;
        StatCore _startCore;
        public override void OnAddComponent()
        {
            Init();
        }



        void InitStat<T>(StatCore statCore, BaseStatPresentation statPresentation) where T : StatBase
        {
            var statControl = statCore.GetContentComponent<T>();
            statControl.AddEventCurrenValueModify(statPresentation.SetCurrentValue);
            StatHasMaxValue statHasMaxvalue = statControl is StatHasMaxValue ? statControl as StatHasMaxValue : null;
            statHasMaxvalue?.AddEventMaxValueModify(statPresentation.SetMaxValue);
            statControl.TriggerStat();
        }

        async void Init()
        {
            await Task.Run(() => Wait());
            InitStat<HPStat>(_startCore, Hp);
            InitStat<MPStat>(_startCore, Mp);
            InitStat<ATKStat>(_startCore, Atk);
            InitStat<DEFStat>(_startCore, Def);
        }

        async void Wait()
        {
            while(_startCore == null)
            {
                _startCore = CharacterSingletonIntance.Instance.MainCore.GetCore<StatCore>();
                await Task.Delay(1);
            }
        }
    }
}
