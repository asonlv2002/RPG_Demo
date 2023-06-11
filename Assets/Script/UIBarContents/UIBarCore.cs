using UnityEngine;
using UnityEngine.UI;
namespace UIBarContents
{
    using Achitecture;
    using StatContents;
    internal abstract class UIBarCore<Stat> : CoreContain<UIBarComponent> where Stat : StatBase
    {
        [SerializeField] Slider Slider;
        protected Stat StatBase;
        protected void SetMaxValue(int value)
        { 
            Slider.maxValue = value;
        }

        protected void SetCurrentValue(int value)
        {
            Slider.value = value;
        }

        protected bool CheckOutStatCore(out StatCore statCore)
        {
            return (statCore = CharacterSingletonIntance.Instance.MainCore.GetCore<StatCore>()) != null;
        }

        protected bool CheckOutStatBase(StatCore statCore,out Stat statbase)
        {
            statbase = statCore.GetContentComponent<Stat>();
            return statbase != null;
        }
    }
}
