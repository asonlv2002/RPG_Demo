namespace StatContents
{
    using UnityEngine;
    using UnityEngine.Events;

    internal abstract class StatHasMaxValue : StatBase
    {
        [SerializeField] protected int MaxStatValue;
        [SerializeField] protected int MIN_OF_MAX_VALUE;
        private UnityAction<int> OnModifyMaxValue;
        public virtual void AddMaxStatValue(int value)
        {
            MaxStatValue += value;
            OnModifyValue();
        }
        public override void AddCurrentStatValue(int value)
        {
            base.AddCurrentStatValue(value);
            if (CurrentStatValue > MaxStatValue) CurrentStatValue = MaxStatValue;
        }
        public virtual void SubMaxStatValue(int value)
        {
            MaxStatValue -= value;
            if (MaxStatValue < MIN_OF_MAX_VALUE) MaxStatValue = MIN_OF_MAX_VALUE;
            OnModifyValue();
        }

        void OnModifyValue()
        {
            OnModifyMaxValue?.Invoke(MaxStatValue);
        }

        public void AddEventMaxValueModify(UnityAction<int> eventModify)
        {
            OnModifyMaxValue += eventModify;
        }

        public void RemoveEventMaxValueModify(UnityAction<int> eventModify)
        {
            OnModifyMaxValue -= eventModify;
        }
        public int GetMaxStatValue() => MaxStatValue;

        public override void TriggerStat()
        {
            OnModifyValue();
            base.TriggerStat();

        }
    }
}
