namespace StatContents
{
    using UnityEngine;
    internal abstract class StatHasMaxValue : StatBase
    {
        [SerializeField] protected int MaxStatValue;
        [SerializeField] protected int MIN_OF_MAX_VALUE;

        public virtual void AddMaxStatValue(int value)
        {
            MaxStatValue += value;
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
        }

        public int GetMaxStatValue() => MaxStatValue;
    }
}
