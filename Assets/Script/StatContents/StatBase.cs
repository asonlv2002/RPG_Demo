namespace StatContents
{
    using UnityEngine;
    using UnityEngine.Events;
    internal abstract class StatBase : StatComponent
    {
        protected const int MIN_STAT = 0;
        [SerializeField] protected int CurrentStatValue;

        private UnityAction<int> OnModifyCurrentValue;

        public virtual void AddCurrentStatValue(int value)
        {
            if (value <= 0) return;
            CurrentStatValue += value;
            OnModifyValue();
        }

        public virtual void SubCurrentStateValue(int value)
        {
            if (value <= 0) return;
            CurrentStatValue -= value;
            if (CurrentStatValue < MIN_STAT) CurrentStatValue = MIN_STAT;
            OnModifyValue();
        }

        void OnModifyValue()
        {
            OnModifyCurrentValue?.Invoke(CurrentStatValue);
        }

        public void AddEventCurrenValueModify(UnityAction<int> eventModify)
        {
            OnModifyCurrentValue += eventModify;
        }

        public void RemoveEventCurrentValueModify(UnityAction<int> eventModify)
        {
            OnModifyCurrentValue -= eventModify;
        }
        public int GetCurrentStatValue() => CurrentStatValue;

        public virtual void TriggerStat()
        {
            OnModifyValue();
        }
    }
}
