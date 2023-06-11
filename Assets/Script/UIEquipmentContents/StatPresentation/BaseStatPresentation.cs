namespace UIEquipmentContents
{
    using UnityEngine;
    using TMPro;
    [System.Serializable]
    internal class BaseStatPresentation
    {
        protected int MaxValue;
        protected int CurrentValue;
        [SerializeField] string NameStat;
        [SerializeField] TextMeshProUGUI _statText;

        public void OnModify()
        {
            string text = NameStat+": " + CurrentValue.ToString();
            if (MaxValue > 0)
            {
                text += "/" + MaxValue.ToString();
            }
            _statText.text = text;

        }

        public void SetCurrentValue(int value)
        {
            CurrentValue = value;
            OnModify();
        }

        public void SetMaxValue(int value)
        {
            MaxValue = value;
            OnModify();
        }
    }
}
