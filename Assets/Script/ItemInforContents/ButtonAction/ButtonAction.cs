namespace ItemInforContents
{
    using UnityEngine;
    using UnityEngine.UI;
    internal abstract class ButtonAction : MonoBehaviour
    {
        [SerializeField] protected Button _button;
        protected abstract void OnClickEffect();
    }
}
