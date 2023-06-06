namespace StatContents
{
    using UnityEngine;
    internal abstract class StatBase : StatComponent
    {
        protected const int MIN_STAT = 0;
        [SerializeField] protected int CurrentStatValue;

        public virtual void AddCurrentStatValue(int value)
        {
            CurrentStatValue += value;
        }

        public virtual void SubCurrentStateValue(int value)
        {
            CurrentStatValue -= value;
            if (CurrentStatValue < MIN_STAT) CurrentStatValue = MIN_STAT;
        }

        public int GetCurrentStatValue() => CurrentStatValue;
    }
}
