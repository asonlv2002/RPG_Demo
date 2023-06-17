using UnityEngine;
using System.Collections;

namespace StatContents
{
    [System.Serializable]
    internal class HealMpPerSecond : StatBase
    {
        [SerializeField] StatCore _statCore;
        public override void OnAddComponent()
        {
            base.OnAddComponent();
            _statCore.StartCoroutine(Handle());
        }

        IEnumerator Handle()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _statCore.GetContentComponent<MPStat>().AddCurrentStatValue(CurrentStatValue);
            }
        }
        public override void OnRemoveComponent()
        {
            _statCore.StopCoroutine(Handle());
        }
    }
}
