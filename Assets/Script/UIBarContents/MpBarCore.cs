namespace UIBarContents
{
    using Achitecture;
    using System.Collections;
    using UnityEngine;
    using StatContents;
    internal class MpBarCore : UIBarCore<MPStat>
    {
        private void Start()
        {
            StartCoroutine(LoadMp());
        }
        
        IEnumerator LoadMp()
        {
            StatCore stat = null;
            yield return new WaitUntil(() => CheckOutStatCore(out stat));
            yield return new WaitUntil(() => CheckOutStatBase(stat,out StatBase));
            StatBase.AddEventCurrenValueModify(SetCurrentValue);
            StatBase.AddEventMaxValueModify(SetMaxValue);
            StatBase.TriggerStat();
        }
    }
}
