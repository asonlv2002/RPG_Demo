namespace StatContents
{
    using UnityEngine;
    using UnityEngine.Events;
    [System.Serializable]
    internal class HPStat : StatHasMaxValue
    {
        public UnityAction OnZeroHp;

        public override void SubCurrentStateValue(int value)
        {
            base.SubCurrentStateValue(value);
            if(CurrentStatValue ==0)
            {
                OnZeroHp.Invoke();
            }
        }
    }
}
