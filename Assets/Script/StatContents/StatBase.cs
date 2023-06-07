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
            CurrentStatValue += value;
            ModifyValue();
        }

        public virtual void SubCurrentStateValue(int value)
        {
            CurrentStatValue -= value;
            if (CurrentStatValue < MIN_STAT) CurrentStatValue = MIN_STAT;
            ModifyValue();
        }

        void ModifyValue()
        {
            OnModifyCurrentValue?.Invoke(CurrentStatValue);
        }

        public void AddEventModify(UnityAction<int> eventModify)
        {
            OnModifyCurrentValue += eventModify;
        }

        public void RemoveEventModify(UnityAction<int> eventModify)
        {
            OnModifyCurrentValue -= eventModify;
        }
        public int GetCurrentStatValue() => CurrentStatValue;
    }
}
