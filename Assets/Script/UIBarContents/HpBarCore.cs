using StatContents;
using System.Collections;
using UnityEngine;

namespace UIBarContents
{
    internal class HpBarCore : UIBarCore<HPStat>
    {
        private void Start()
        {
            StartCoroutine(LoadMp());
        }

        IEnumerator LoadMp()
        {
            StatCore stat = null;
            yield return new WaitUntil(() => CheckOutStatCore(out stat));
            yield return new WaitUntil(() => CheckOutStatBase(stat, out StatBase));
            StatBase.AddEventCurrenValueModify(SetCurrentValue);
            StatBase.AddEventMaxValueModify(SetMaxValue);
            StatBase.TriggerStat();
        }
    }
}
