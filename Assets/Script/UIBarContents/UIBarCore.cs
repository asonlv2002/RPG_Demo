using UnityEngine;
using UnityEngine.UI;
namespace UIBarContents
{
    internal abstract class UIBarCore : Achitecture.CoreContain<UIBarComponent>
    {
        [SerializeField] protected Slider Slider;

        void SetMaxValue(int value)
        {
            Slider.maxValue += value;
        }

        void SetCurrentValue(int value)
        {
            Slider.value = value;
        }
    }
}
