using UnityEngine;
using UnityEngine.UI;

public class BossUIHp : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        Debug.Log(2222);
    }

    public void SetCurrentValue(int value)
    {
        slider.value = value;
    }
}
